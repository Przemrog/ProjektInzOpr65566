using ProjektSklep.Dtos;

namespace ProjektSklep.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
        Task<AuthorDto> GetAuthorAsync(int id);
        Task<AuthorDto> CreateAuthorAsync(AuthorDto authorDto);
        Task UpdateAuthorAsync(int id, AuthorDto authorDto);
        Task DeleteAuthorAsync(int id);
    }
}
