using MyBooks.Data;
using MyBooks.DTOs;
using MyBooks.Models;

namespace MyBooks.Services
{
    public class BookService
    {
        private readonly DataFieldRepository dataFieldRepository;
        private readonly BookmarkRepository bookmarkRepository;
        private readonly BookMetadataRepository bookMetadataRepository;
        private readonly BookRepository bookRepository;
        private readonly BookDataFieldRepository bookDataFieldRepository;
        private readonly ViewService viewService = new ViewService();
        private static readonly List<BookDto> BookCacheList = new List<BookDto>();

        public BookService()
        {
            dataFieldRepository = new DataFieldRepository();
            bookmarkRepository = new BookmarkRepository();
            bookMetadataRepository = new BookMetadataRepository();
            bookRepository = new BookRepository();
            bookDataFieldRepository = new BookDataFieldRepository();

            if (BookCacheList.Count == 0)
            {
                var books = bookRepository.GetAll().ToList();
                foreach (var book in books)
                {
                    var bookDto = GetBookById(book.Id);
                    if (bookDto != null)
                    {
                        BookCacheList.Add(bookDto);
                    }
                }
            }
        }
        public BookCard CreateCard(BookDto dto)
        {
            Image? cover = null;

            if (!string.IsNullOrEmpty(dto.Book.CoverPath))
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(dto.Book.CoverPath);
                    using var ms = new MemoryStream(bytes);
                    cover = Image.FromStream(ms);
                }
                catch
                {
                    cover = null;
                }
            }
            var path = dto.Metadatas.FirstOrDefault()?.FilePath;

            return new BookCard
            {
                BookName = dto.Book.Title,
                BookCover = cover,
                ButtonText = "Đọc ngay",
                ButtonClickAction = async void () =>
                {
                    try
                    {
                        var rsp = await viewService.ViewFileAsync(path ?? "");
                        if (rsp.Success == false)
                        {
                            MessageBox.Show($@"Lỗi: {rsp.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($@"Lỗi: {e}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
                Margin = new Padding(10)
            };
        }
        private BookDto? GetBookById(int bookId)
        {
            var bookCache = BookCacheList.Find(it => it.Book.Id == bookId);
            if (bookCache != null)
            {
                return bookCache;
            }
            var book = bookRepository.GetById(bookId);
            if (book == null)
            {
                return null;
            }
            var authors = dataFieldRepository.GetListByBookId(bookId, "authors").ToList();
            var tags = dataFieldRepository.GetListByBookId(bookId, "tags").ToList();
            var publishers = dataFieldRepository.GetListByBookId(bookId, "").ToList();
            var series = dataFieldRepository.GetListByBookId(bookId, "publishers").ToList();
            var languages = dataFieldRepository.GetListByBookId(bookId, "languages").ToList();
            var metadatas = bookMetadataRepository.GetByBookId(bookId).ToList();
            var bookmarks = bookmarkRepository.GetByBookId(bookId).ToList();

            return new BookDto
            {
                Book = book,
                Authors = authors,
                Tags = tags,
                Publisher = publishers,
                Series = series,
                Languages = languages,
                Metadatas = metadatas,
                Bookmarks = bookmarks
            };

        }

        public ServiceResponse<List<BookDto>> GetAllBook()
        {
            if (BookCacheList.Count > 0)
            {
                return new ServiceResponse<List<BookDto>>()
                {
                    Data = BookCacheList,
                    Success = true,
                    Message = "Books retrieved successfully from cache."
                };
            }

            var response = new ServiceResponse<List<BookDto>>();
            try
            {
                var books = bookRepository.GetAll().ToList();
                var bookDtos = new List<BookDto>();
                foreach (var book in books)
                {
                    var bookDto = GetBookById(book.Id);
                    if (bookDto != null)
                    {
                        bookDtos.Add(bookDto);
                    }
                }
                response.Data = bookDtos;
                response.Success = true;
                response.Message = "Books retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
                response.Data = null;
            }
            return response;
        }

        private void BindingAddDataField(List<DataField> listField, int bookId, string dataType)
        {
            foreach (var field in listField)
            {
                var tmpField = dataFieldRepository.GetByNameAndType(field.Name, dataType);
                if (tmpField == null)
                {
                    field.DataType = dataType;
                    field.CreatedAt = DateTime.Now;
                    field.UpdatedAt = DateTime.Now;
                    field.Id = dataFieldRepository.Insert(field);
                    bookDataFieldRepository.AddFieldToBook(bookId, field.Id);
                }
                else
                {
                    field.Id = tmpField.Id;
                    bookDataFieldRepository.AddFieldToBook(bookId, field.Id);
                }
            }
        }
        
        static bool ContainsAny(IEnumerable<DataField>? source, IEnumerable<DataField>? required)
        {
            if (required == null) return false;
            var dataFields = required as DataField[] ?? required.ToArray();
            if (dataFields.Length == 0)
                return false;

            if (source == null) return false;
            var enumerable = source as DataField[] ?? source.ToArray();
            if (enumerable.Length == 0)
                return false;

            var reqNames = new HashSet<string>(
                dataFields
                    .Where(r => !string.IsNullOrWhiteSpace(r.Name))
                    .Select(r => r.Name.Trim()),
                StringComparer.OrdinalIgnoreCase
            );

            return enumerable.Any(s => !string.IsNullOrWhiteSpace(s.Name) && reqNames.Contains(s.Name.Trim()));

        }
        
        public ServiceResponse<List<BookDto>> SearchBook(FilterDto dto)
        {
            var newListBook =  BookCacheList
                .Where(book =>
                    (string.IsNullOrEmpty(dto.Book.Title) ||
                        (book.Book.Title).Contains(dto.Book.Title, StringComparison.OrdinalIgnoreCase)) &&

                    (string.IsNullOrEmpty(dto.Book.ISBN) ||
                        (book.Book.ISBN).Contains(dto.Book.ISBN, StringComparison.OrdinalIgnoreCase)) &&

                    (dto.Authors.Count == 0 || ContainsAny(book.Authors, dto.Authors)) &&

                    (dto.Tags.Count == 0 || ContainsAny(book.Tags, dto.Tags)) &&

                    (dto.Publisher.Count == 0 || ContainsAny(book.Publisher, dto.Publisher)) &&

                    (dto.Series.Count == 0 || ContainsAny(book.Series, dto.Series)) &&

                    (dto.Languages.Count == 0 || ContainsAny(book.Languages, dto.Languages))
                ).ToList();
            return new ServiceResponse<List<BookDto>>()
            {
                Data = newListBook,
                Success = true,
                Message = "Books search successfully."
            };
        }
        public ServiceResponse<BookDto> AddABook(BookDto book)
        {
            var response = new ServiceResponse<BookDto>();
            try
            {   
                book.Book.CreatedAt = DateTime.Now;
                book.Book.UpdatedAt = DateTime.Now;
                var bookId = bookRepository.Insert(book.Book);

                BindingAddDataField(book.Authors, bookId, "authors");
                BindingAddDataField(book.Tags, bookId, "tags");
                BindingAddDataField(book.Publisher, bookId, "publishers");
                BindingAddDataField(book.Series, bookId, "series");
                BindingAddDataField(book.Languages, bookId, "languages");
                foreach (var metadata in book.Metadatas)
                {
                    metadata.BookId = bookId;
                    metadata.CreatedAt = DateTime.Now;
                    metadata.UpdatedAt = DateTime.Now;
                    bookMetadataRepository.Insert(metadata);
                }
                foreach (var bookmark in book.Bookmarks)
                {
                    bookmark.BookId = bookId;
                    bookmark.CreatedAt = DateTime.Now;
                    bookmark.UpdatedAt = DateTime.Now;
                    bookmarkRepository.Insert(bookmark);
                }
                var newBook = GetBookById(bookId);
                if (newBook == null)
                {
                    response.Success = false;
                    response.Message = "Failed to retrieve the newly added book.";
                    response.Data = null;
                    return response;
                }
                BookCacheList.Add(newBook);
                response.Data = newBook;
                response.Success = true;
                response.Message = "Book added successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
                response.Data = null;
            }
            return response;
        }


        public ServiceResponse<bool> DeleteABook(int bookId)
        {

            var book = GetBookById(bookId);
            if (book == null)
            {
                return new ServiceResponse<bool>()
                {
                    Data = false,
                    Success = false,
                    Message = "Book not found."
                };
            }

            var response = new ServiceResponse<bool>();
            try
            {
                bookmarkRepository.DeleteByBookId(bookId);
                bookMetadataRepository.DeleteByBookId(bookId);
                bookDataFieldRepository.RemoveAllFieldsFromBook(bookId);
                bookRepository.Delete(bookId);
                BookCacheList.RemoveAll(it => it.Book.Id == bookId);
                response.Data = true;
                response.Success = true;
                response.Message = "Book deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
                response.Data = false;
            }

            return response;
        }

        public ServiceResponse<BookDto?> UpdateABook(BookDto dto)
        {
            var book = GetBookById(dto.Book.Id);
            if (book == null)
            {
                return new ServiceResponse<BookDto?>()
                {
                    Data = null,
                    Success = false,
                    Message = "Book not found."
                };
            }

            var response = new ServiceResponse<BookDto?>();
            try
            {
                bookmarkRepository.DeleteByBookId(dto.Book.Id);
                bookMetadataRepository.DeleteByBookId(dto.Book.Id);
                bookDataFieldRepository.RemoveAllFieldsFromBook(dto.Book.Id);
                dto.Book.UpdatedAt = DateTime.Now;
                bookRepository.Update(dto.Book);

                BindingAddDataField(book.Authors, dto.Book.Id, "authors");
                BindingAddDataField(book.Tags, dto.Book.Id, "tags");
                BindingAddDataField(book.Publisher, dto.Book.Id, "publishers");
                BindingAddDataField(book.Series, dto.Book.Id, "series");
                BindingAddDataField(book.Languages, dto.Book.Id, "languages");
                foreach (var metadata in book.Metadatas)
                {
                    metadata.BookId = dto.Book.Id;
                    metadata.CreatedAt = DateTime.Now;
                    metadata.UpdatedAt = DateTime.Now;
                    bookMetadataRepository.Insert(metadata);
                }
                foreach (var bookmark in book.Bookmarks)
                {
                    bookmark.BookId = dto.Book.Id;
                    bookmark.CreatedAt = DateTime.Now;
                    bookmark.UpdatedAt = DateTime.Now;
                    bookmarkRepository.Insert(bookmark);
                }

                BookCacheList.RemoveAll(it => it.Book.Id == dto.Book.Id);
                var newBook = GetBookById(dto.Book.Id);
                if (newBook == null)
                {
                    response.Success = false;
                    response.Message = "Failed to retrieve the updated book.";
                    response.Data = null;
                    return response;
                }
                BookCacheList.Add(newBook);
                response.Data = newBook;
                response.Data = newBook;
                response.Success = true;
                response.Message = "Book update successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
                response.Data = null;
            }

            return response;
        }

    }
}
