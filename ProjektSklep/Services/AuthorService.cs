using Microsoft.EntityFrameworkCore;
using ProjektSklep.Dtos;
using ProjektSklep.Models;

namespace ProjektSklep.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookstoreDbContext _context;

        public AuthorService(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
        {
            return await _context.Authors
                .Select(a => new AuthorDto
                {
                    AuthorId = a.AuthorId,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<AuthorDto> GetAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return null;
            }

            return new AuthorDto
            {
                AuthorId = author.AuthorId,
                Name = author.Name
            };
        }

        public async Task<AuthorDto> CreateAuthorAsync(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            authorDto.AuthorId = author.AuthorId;
            return authorDto;
        }

        public async Task UpdateAuthorAsync(int id, AuthorDto authorDto)
        {
            if (id != authorDto.AuthorId)
            {
                throw new ArgumentException("Id missmatch");
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            author.Name = authorDto.Name;

            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
