using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class BookService : IBookService, IAsyncDisposable
    {
        private readonly LibraryContext _dbContext;

        public BookService(IDbContextFactory<LibraryContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public Task<Book> GetAsync(Guid id)
        {
            var item = _dbContext.Books.FirstOrDefaultAsync(a => a.Id == id);
            return Task.FromResult(item.Result);
        }

        public Task<IQueryable<Book>> ListAsync()
        {
            return Task.FromResult(_dbContext.Books.AsQueryable());
        }

        public Task<Book> CreateAsync(Book input)
        {
            var item = _dbContext.Books.AddAsync(input);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(item.Result.Entity);
        }

        public Task<Book> UpdateAsync(Book input)
        {
            var item = GetAsync(input.Id).Result;
            item.Title = input?.Title ?? item.Title;
            item.AuthorId = input?.AuthorId ?? item.AuthorId;
            _dbContext.Books.Update(item);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(item);
        }

        public Task<Book> DeleteAsync(Book input)
        {
            var item = GetAsync(input.Id).Result;
            _dbContext.Books.Remove(item);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(item);
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}