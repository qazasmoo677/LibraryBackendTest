using TestLibraryBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestLibraryBackend.Repositories {
    public interface IBookRepository {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}