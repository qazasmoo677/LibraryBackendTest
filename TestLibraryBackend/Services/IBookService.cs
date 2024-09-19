using TestLibraryBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestLibraryBackend.Services {
    public interface IBookService {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> AddBookAsync(BookDto bookDto);
        Task UpdateBookAsync(BookDto bookDto);
        Task DeleteBookAsync(int id);
    }
}