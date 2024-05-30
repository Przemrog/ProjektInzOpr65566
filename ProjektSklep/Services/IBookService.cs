using ProjektSklep.Dtos;

namespace ProjektSklep.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task UpdateBookAsync(int id, BookDto bookDto);
        Task DeleteBookAsync(int id);
    }
}
