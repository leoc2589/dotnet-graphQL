using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class AuthorService : IAuthorService, IAsyncDisposable
    {
        private readonly LibraryContext _dbContext;

        public AuthorService(IDbContextFactory<LibraryContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public Task<Author> GetAsync(Guid id)
        {
            var item = _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            return Task.FromResult(item.Result);
        }

        public Task<IQueryable<Author>> ListAsync()
        {
            return Task.FromResult(_dbContext.Authors.AsQueryable());
        }

        public Task<Author> CreateAsync(Author input)
        {
            var item = _dbContext.Authors.AddAsync(input);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(item.Result.Entity);
        }

        public Task<Author> UpdateAsync(Author input)
        {
            var item = GetAsync(input.Id).Result;
            item.Name = input?.Name ?? item.Name;
            _dbContext.Authors.Update(item);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(item);
        }

        public Task<Author> DeleteAsync(Author input)
        {
            var item = GetAsync(input.Id).Result;
            _dbContext.Authors.Remove(item);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(item);
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}