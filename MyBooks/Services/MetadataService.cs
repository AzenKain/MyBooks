using iText.Kernel.Pdf;
using MyBooks.DTOs;
using MyBooks.Models;
using VersOne.Epub;

namespace MyBooks.Services
{
    public class MetadataService
    {

        public async Task<ServiceResponse<BookDto>> ReadMetadataAsync(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            var response = new ServiceResponse<BookDto>();
            try
            {
                BookDto dto;
                if (extension == ".epub")
                {
                    dto = await ReadEpubMetadata(filePath);
                }
                else if (extension == ".pdf")
                {
                    dto = ReadPdfMetadata(filePath);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Unsupported file format.";
                    return response;
                }
                response.Success = true;
                response.Data = dto;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error reading metadata: {ex.Message}";
            }

            return response;

        }


        private async Task<BookDto> ReadEpubMetadata(string epubPath)
        {
            EpubBook book = await EpubReader.ReadBookAsync(epubPath);

            var meta = new BookDetail();

            meta.Title = book.Title ?? "";

            meta.Subtitle = book.Schema?.Package?.Metadata?.Titles?.FirstOrDefault()?.Title ?? "";
            meta.Description = book.Description ?? "";
            meta.ISBN = book.Schema?.Package?.Metadata?.Identifiers?
                .FirstOrDefault(id => id.Scheme?.ToLower() == "isbn")?.Identifier ?? "";

            string? date = book.Schema?.Package?.Metadata?.Dates?.FirstOrDefault()?.Date;
            if (DateTime.TryParse(date, out var publishedDate))
                meta.PublishedYear = publishedDate;

            if (book.CoverImage != null)
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "epub_cover.jpg");
                File.WriteAllBytes(tempPath, book.CoverImage);
                meta.CoverPath = tempPath;
            }
            var seriesList = new List<DataField>();

            if (book.Schema?.Package?.Collections != null)
            {
                foreach (var collection in book.Schema.Package.Collections)
                {
                    if (collection.Metadata?.Titles != null)
                    {
                        foreach (var title in collection.Metadata.Titles)
                        {
                            seriesList.Add(new DataField
                            {
                                Name = title.Title,
                                DataType = "series"
                            });
                        }
                    }
                }
            }
            var dto = new BookDto
            {
                book = meta,
                authors = book.AuthorList?
                    .Select(a => new DataField { Name = a, DataType = "authors" })
                    .ToList() ?? new List<DataField>(),
                tags = book.Schema?.Package?.Metadata?.Subjects?
                    .Select(s => new DataField { Name = s.Subject, DataType = "tags" })
                    .ToList() ?? new List<DataField>(),
                publisher = book.Schema?.Package?.Metadata?.Publishers?
                    .Select(p => new DataField { Name = p.Publisher, DataType = "publishers" })
                    .ToList() ?? new List<DataField>(),
                series = seriesList,
                languages = book.Schema?.Package?.Metadata?.Languages?
                    .Select(l => new DataField { Name = l.Language, DataType = "languages" })
                    .ToList() ?? new List<DataField>(),
            };


            return dto;
        }


        private BookDto ReadPdfMetadata(string pdfPath)
        {
            var meta = new BookDetail();

            using (PdfReader reader = new PdfReader(pdfPath))
            using (PdfDocument pdf = new PdfDocument(reader))
            {
                var info = pdf.GetDocumentInfo();

                meta.Title = info.GetTitle() ?? "";
                meta.Description = info.GetMoreInfo("Description") ?? "";
                meta.ISBN = info.GetMoreInfo("ISBN") ?? "";
                string creationDate = info.GetMoreInfo("CreationDate");
                if (!string.IsNullOrEmpty(creationDate))
                {
                    if (ParsePdfDate(creationDate, out DateTime dt))
                        meta.PublishedYear = dt;
                }
            }

            var dto = new BookDto
            {
                book = meta,
                authors = new List<DataField>(),
                tags = new List<DataField>(),
                publisher = new List<DataField>(),
                series = new List<DataField>(),
                languages = new List<DataField>(),
            };

            return dto;
        }

        private bool ParsePdfDate(string value, out DateTime dt)
        {
            dt = default;

            if (value.StartsWith("D:"))
                value = value.Substring(2);

            string format = "yyyyMMddHHmmss";

            if (value.Length >= 14 &&
                DateTime.TryParseExact(value.Substring(0, 14), format, null,
                System.Globalization.DateTimeStyles.None, out dt))
            {
                return true;
            }

            return false;
        }


    }

}
