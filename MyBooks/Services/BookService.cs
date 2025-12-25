using MyBooks.Data;
using MyBooks.DTOs;
using MyBooks.Models;
using MyBooks.State;
using System.Net;

namespace MyBooks.Services
{
    public class BookService
    {
        private readonly DataFieldRepository dataFieldRepository = new DataFieldRepository();
        private readonly BookmarkRepository bookmarkRepository = new BookmarkRepository();
        private readonly BookMetadataRepository bookMetadataRepository = new BookMetadataRepository();
        private readonly BookRepository bookRepository =new BookRepository();
        private readonly BookDataFieldRepository bookDataFieldRepository = new BookDataFieldRepository();
        private readonly BookProfileRepository bookProfileRepository = new BookProfileRepository();
        private static readonly List<BookDto> BookCacheList = new List<BookDto>();

        public BookService()
        {
            if (BookCacheList.Count == 0)
                UpdateBookCacheList();
        }

        public static List<BookDto> GetBookCacheList()
        {
            return BookCacheList;
        }

        public void UpdateBookCacheList()
        {
            var lisIds = bookProfileRepository.GetBookIdsByProfileid(AppStore.States.Setting.currentProfile.Id);
            BookCacheList.Clear();
            var books = bookRepository.GetByIds(lisIds).ToList();
            foreach (var book in books)
            {
                var bookDto = GetBookById(book.Id);
                if (bookDto != null)
                {
                    BookCacheList.Add(bookDto);
                }
            }
        }
        public BookCard CreateCard(BookDto dto)
        {
            var card = new BookCard
            {
                BookName = dto.Book.Title,
                BookCover = null,
                ButtonClickAction = async void () =>
                {
                    try
                    {
                        new BookControl(dto).ShowDialog();
                    }
                    catch (Exception e)
                    {
                        RJMessageBox.Show($@"Lỗi: {e}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
                Margin = new Padding(10)
            };

            _ = LoadCoverAsync(dto, card);

            return card;
        }
        public async Task LoadCoverAsync(BookDto dto, BookCard card)
        {
            if (string.IsNullOrEmpty(dto.Book.CoverPath))
                return;

            try
            {
                var img = await Task.Run(() =>
                {
                    byte[] bytes = Convert.FromBase64String(dto.Book.CoverPath);
                    using var ms = new MemoryStream(bytes);
                    return Image.FromStream(ms);
                });

                if (card.InvokeRequired)
                    card.Invoke(() => card.BookCover = img);
                else
                    card.BookCover = img;
            }
            catch
            {
            }
        }

        public BookDto? GetBookById(int bookId)
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
            var authors = dataFieldRepository.GetListByBookId(bookId, DataFieldType.Authors.ToDbValue()).ToList();
            var tags = dataFieldRepository.GetListByBookId(bookId, DataFieldType.Tags.ToDbValue()).ToList();
            var publishers = dataFieldRepository.GetListByBookId(bookId, DataFieldType.Publishers.ToDbValue()).ToList();
            var series = dataFieldRepository.GetListByBookId(bookId, DataFieldType.Series.ToDbValue()).ToList();
            var languages = dataFieldRepository.GetListByBookId(bookId, DataFieldType.Languages.ToDbValue()).ToList();
            var metadatas = bookMetadataRepository.GetByBookId(bookId).ToList();
            var bookmarks = bookmarkRepository.GetByBookId(bookId);

            return new BookDto
            {
                Book = book,
                Authors = authors,
                Tags = tags,
                Publisher = publishers,
                Series = series,
                Languages = languages,
                Metadatas = metadatas,
                Bookmarks = bookmarks != null ? bookmarks : new Bookmark
                {
                    BookId = bookId,
                    ElementIndex = 0,
                    Percentage = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
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
                var lisIds = bookProfileRepository.GetBookIdsByProfileid(AppStore.States.Setting.currentProfile.Id);
                var books = bookRepository.GetByIds(lisIds).ToList();
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

        private void BindingAddDataField(List<DataField> listField, int bookId, DataFieldType type)
        {
            var dataType = type.ToDbValue();
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


        public ServiceResponse<BookDto> AddABook(BookDto book)
        {
            var booksDir = Path.Combine(AppContext.BaseDirectory, "books");
            Directory.CreateDirectory(booksDir);

            var response = new ServiceResponse<BookDto>();
            try
            {   
                book.Book.CreatedAt = DateTime.Now;
                book.Book.UpdatedAt = DateTime.Now;
                var bookId = bookRepository.Insert(book.Book);

                bookProfileRepository.AddBookToProfile(bookId, AppStore.States.Setting.currentProfile.Id);

                BindingAddDataField(book.Authors, bookId, DataFieldType.Authors);
                BindingAddDataField(book.Tags, bookId, DataFieldType.Tags);
                BindingAddDataField(book.Publisher, bookId, DataFieldType.Publishers);
                BindingAddDataField(book.Series, bookId, DataFieldType.Series);
                BindingAddDataField(book.Languages, bookId, DataFieldType.Languages);
                foreach (var metadata in book.Metadatas)
                {
                    var oldPath = metadata.FilePath;

                    if (string.IsNullOrWhiteSpace(oldPath) || !File.Exists(oldPath))
                        continue;

                    var ext = Path.GetExtension(oldPath);
                    var newFileName = $"{Guid.NewGuid():N}{ext}";
                    var newPath = Path.Combine(booksDir, newFileName);

                    File.Copy(oldPath, newPath, overwrite: true);

                    metadata.FilePath = newPath;
                    metadata.BookId = bookId;
                    metadata.CreatedAt = DateTime.Now;
                    metadata.UpdatedAt = DateTime.Now;
                    bookMetadataRepository.Insert(metadata);


                }

                book.Bookmarks.BookId = bookId;
                book.Bookmarks.UpdatedAt = DateTime.Now;
                bookmarkRepository.Upsert(book.Bookmarks);
                

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
                foreach (var metadata in book.Metadatas)
                {
                    var filePath = metadata.FilePath;
                    if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                bookMetadataRepository.DeleteByBookId(bookId);
                bookmarkRepository.DeleteByBookId(bookId);

                bookDataFieldRepository.RemoveAllFieldsFromBook(bookId);
                bookProfileRepository.RemoveBookFromProfile(bookId, AppStore.States.Setting.currentProfile.Id);
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

                dto.Book.UpdatedAt = DateTime.Now;

    
                var isOk = bookRepository.Update(dto.Book);
                if (!isOk)
                {
                    response.Success = false;
                    response.Message = "Failed to update the book.";
                    response.Data = null;
                    return response;
                }

                bookDataFieldRepository.RemoveAllFieldsFromBook(dto.Book.Id);
                BindingAddDataField(book.Authors, dto.Book.Id, DataFieldType.Authors);
                BindingAddDataField(book.Tags, dto.Book.Id, DataFieldType.Tags);
                BindingAddDataField(book.Publisher, dto.Book.Id, DataFieldType.Publishers);
                BindingAddDataField(book.Series, dto.Book.Id, DataFieldType.Series);
                BindingAddDataField(book.Languages, dto.Book.Id, DataFieldType.Languages);

                foreach (var metadata in book.Metadatas)
                {
                    metadata.BookId = dto.Book.Id;
                    metadata.CreatedAt = DateTime.Now;
                    metadata.UpdatedAt = DateTime.Now;
                    bookMetadataRepository.Upsert(metadata);
                }

                book.Bookmarks.BookId = dto.Book.Id;
                book.Bookmarks.UpdatedAt = DateTime.Now;
                bookmarkRepository.Upsert(book.Bookmarks);

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
