using TestLibraryBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestLibraryBackend.Repositories {
    public class BookRepository : IBookRepository {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync() {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id) {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddBookAsync(Book book) {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBookAsync(Book book) {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id) {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}