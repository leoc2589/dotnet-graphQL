using App.Models;

namespace App.Services;

public interface IBookService
{
    Task<Book> GetAsync(Guid id);
    Task<IQueryable<Book>> ListAsync();
    Task<Book> CreateAsync(Book input);
    Task<Book> UpdateAsync(Book input);
    Task<Book> DeleteAsync(Book input);
}