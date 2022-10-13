using App.Models;

namespace App.Services;

public interface IAuthorService
{
    Task<Author> GetAsync(Guid id);
    Task<IQueryable<Author>> ListAsync();
    Task<Author> CreateAsync(Author input);
    Task<Author> UpdateAsync(Author input);
    Task<Author> DeleteAsync(Author input);
}