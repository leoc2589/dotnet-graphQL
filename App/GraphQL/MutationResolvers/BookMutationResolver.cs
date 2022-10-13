using App.Models;
using App.Services;

namespace App.GraphQL.MutationResolver;

[ExtendObjectType(typeof(Mutation))]
public class BookMutationResolver
{
    /// <summary>
    /// Create book.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="input"></param>
    /// <returns>The book.</returns>
    public Task<Book> CreateBook([Service] IBookService service, Book input) =>
        service.CreateAsync(input);

    /// <summary>
    /// Update author.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="input"></param>
    /// <returns>The book.</returns>
    public Task<Book> UpdateBook([Service] IBookService service, Book input) =>
        service.UpdateAsync(input);

    /// <summary>
    /// Delete book.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="input"></param>
    /// <returns>The book.</returns>
    public Task<Book> DeleteBook([Service] IBookService service, Book input) =>
        service.DeleteAsync(input);
}