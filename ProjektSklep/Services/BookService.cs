using Microsoft.EntityFrameworkCore;
using ProjektSklep.Dtos;
using ProjektSklep.Models;

namespace ProjektSklep.Services
{
    public class BookService : IBookService
    {
        private readonly BookstoreDbContext _context;

        public BookService(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Select(b => new BookDto
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    CategoryId = b.CategoryId
                })
                .ToListAsync();
        }

        public async Task<BookDto> GetBookAsync(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return null;
            }

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId
            };
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Title = createBookDto.Title,
                AuthorId = createBookDto.AuthorId,
                CategoryId = createBookDto.CategoryId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId
            };
        }

        public async Task UpdateBookAsync(int id, BookDto bookDto)
        {
            if (id != bookDto.BookId)
            {
                throw new ArgumentException("Id missmatch");
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            book.Title = bookDto.Title;
            book.AuthorId = bookDto.AuthorId;
            book.CategoryId = bookDto.CategoryId;

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
