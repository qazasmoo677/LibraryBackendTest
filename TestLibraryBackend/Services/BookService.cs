using TestLibraryBackend.DTOs;
using TestLibraryBackend.Repositories;
using TestLibraryBackend.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestLibraryBackend.Services {
    public class BookService : IBookService {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper) {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync() {
            var books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int id) {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> AddBookAsync(BookDto bookDto) {
            var book = _mapper.Map<Book>(bookDto);
            var addedBook = await _bookRepository.AddBookAsync(book);
            return _mapper.Map<BookDto>(addedBook);
        }

        public async Task UpdateBookAsync(BookDto bookDto) {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(int id) {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}