using MyBooks.Data;
using MyBooks.DTOs;
using MyBooks.Models;
using MyBooks.Services;
using System.Net;
using System.Security.Policy;


namespace MyBooks.Services
{
    public class BookService
    {
        private readonly UserRepository userRepository;
        private readonly DataFieldRepository dataFieldRepository;
        private readonly BookmarkRepository bookmarkRepository;
        private readonly BookMetadataRepository bookMetadataRepository;
        private readonly BookRepository bookRepository;
        private readonly BookUserRepository bookUserRepository;
        private readonly BookDataFieldRepository bookDataFieldRepository;

        private static List<BookDto> bookCacheList = new List<BookDto>();

        public BookService()
        {
            dataFieldRepository = new DataFieldRepository();
            userRepository = new UserRepository();
            bookmarkRepository = new BookmarkRepository();
            bookMetadataRepository = new BookMetadataRepository();
            bookRepository = new BookRepository();
            bookUserRepository = new BookUserRepository();
            bookDataFieldRepository = new BookDataFieldRepository();

            if (bookCacheList.Count == 0)
            {
                var books = bookRepository.GetAll().ToList();
                foreach (var book in books)
                {
                    var bookDto = GetBookById(book.Id);
                    if (bookDto != null)
                    {
                        bookCacheList.Add(bookDto);
                    }
                }
            }
        }

        private BookDto? GetBookById(int bookId)
        {
            var bookCache = bookCacheList.Find(it => it.book.Id == bookId);
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
                book = book,
                authors = authors,
                tags = tags,
                publisher = publishers,
                series = series,
                languages = languages,
                metadatas = metadatas,
                bookmarks = bookmarks
            };

        }

        public ServiceResponse<List<BookDto>> GetAllBook()
        {
            if (bookCacheList.Count > 0)
            {
                return new ServiceResponse<List<BookDto>>()
                {
                    Data = bookCacheList,
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

        private void BindingAddDataField(List<DataField> listField, int bookId, string data_type)
        {
            foreach (var field in listField)
            {
                var tmpField = dataFieldRepository.GetByNameAndType(field.Name, data_type);
                if (tmpField == null)
                {
                    field.DataType = data_type;
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
        public ServiceResponse<List<BookDto>> SearchBook(FilterDto dto)
        {
            var newListBook =  bookCacheList
                .Where(book =>
                    (string.IsNullOrEmpty(dto.book.Title) ||
                        (book.book?.Title ?? "").Contains(dto.book.Title, StringComparison.OrdinalIgnoreCase)) &&

                    (string.IsNullOrEmpty(dto.book.ISBN) ||
                        (book.book?.ISBN ?? "").Contains(dto.book.ISBN, StringComparison.OrdinalIgnoreCase)) &&

                    (dto.authors.Count == 0 ||
                        dto.authors.All(author =>
                            (book.authors ?? Enumerable.Empty<DataField>())
                                .Any(bAuthor => bAuthor.Name.Equals(author.Name, StringComparison.OrdinalIgnoreCase))
                        )) &&

                    (dto.tags.Count == 0 ||
                        dto.tags.All(tag =>
                            (book.tags ?? Enumerable.Empty<DataField>())
                                .Any(bTag => bTag.Name.Equals(tag.Name, StringComparison.OrdinalIgnoreCase))
                        )) &&

                    (dto.publisher.Count == 0 ||
                        dto.publisher.All(pub =>
                            (book.publisher ?? Enumerable.Empty<DataField>())
                                .Any(bPub => bPub.Name.Equals(pub.Name, StringComparison.OrdinalIgnoreCase))
                        )) &&

                    (dto.series.Count == 0 ||
                        dto.series.All(ser =>
                            (book.series ?? Enumerable.Empty<DataField>())
                                .Any(bSer => bSer.Name.Equals(ser.Name, StringComparison.OrdinalIgnoreCase))
                        )) &&

                    (dto.languages.Count == 0 ||
                        dto.languages.All(lang =>
                            (book?.languages ?? Enumerable.Empty<DataField>())
                                .Any(bLang => bLang.Name.Equals(lang.Name, StringComparison.OrdinalIgnoreCase))
                        ))
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
                book.book.CreatedAt = DateTime.Now;
                book.book.UpdatedAt = DateTime.Now;
                var bookId = bookRepository.Insert(book.book);

                BindingAddDataField(book.authors, bookId, "authors");
                BindingAddDataField(book.tags, bookId, "tags");
                BindingAddDataField(book.publisher, bookId, "publishers");
                BindingAddDataField(book.series, bookId, "series");
                BindingAddDataField(book.languages, bookId, "languages");
                foreach (var metadata in book.metadatas)
                {
                    metadata.BookId = bookId;
                    metadata.CreatedAt = DateTime.Now;
                    metadata.UpdatedAt = DateTime.Now;
                    bookMetadataRepository.Insert(metadata);
                }
                foreach (var bookmark in book.bookmarks)
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
                bookCacheList.Add(newBook);
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
                bookCacheList.RemoveAll(it => it.book.Id == bookId);
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
            var book = GetBookById(dto.book.Id);
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
                bookmarkRepository.DeleteByBookId(dto.book.Id);
                bookMetadataRepository.DeleteByBookId(dto.book.Id);
                bookDataFieldRepository.RemoveAllFieldsFromBook(dto.book.Id);
                dto.book.UpdatedAt = DateTime.Now;
                bookRepository.Update(dto.book);

                BindingAddDataField(book.authors, dto.book.Id, "authors");
                BindingAddDataField(book.tags, dto.book.Id, "tags");
                BindingAddDataField(book.publisher, dto.book.Id, "publishers");
                BindingAddDataField(book.series, dto.book.Id, "series");
                BindingAddDataField(book.languages, dto.book.Id, "languages");
                foreach (var metadata in book.metadatas)
                {
                    metadata.BookId = dto.book.Id;
                    metadata.CreatedAt = DateTime.Now;
                    metadata.UpdatedAt = DateTime.Now;
                    bookMetadataRepository.Insert(metadata);
                }
                foreach (var bookmark in book.bookmarks)
                {
                    bookmark.BookId = dto.book.Id;
                    bookmark.CreatedAt = DateTime.Now;
                    bookmark.UpdatedAt = DateTime.Now;
                    bookmarkRepository.Insert(bookmark);
                }

                bookCacheList.RemoveAll(it => it.book.Id == dto.book.Id);
                var newBook = GetBookById(dto.book.Id);
                if (newBook == null)
                {
                    response.Success = false;
                    response.Message = "Failed to retrieve the updated book.";
                    response.Data = null;
                    return response;
                }
                bookCacheList.Add(newBook);
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
