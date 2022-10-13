using App.Models;
using App.Services;

namespace App.GraphQL.QueryResolvers;

[ExtendObjectType(typeof(Query))]
public class BookQueryResolver
{
    /// <summary>
    /// Gets all authors.
    /// </summary>
    /// <param name="service"></param>
    /// <returns>The auhtors.</returns>
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IQueryable<Book>> Books([Service] IBookService service) =>
        service.ListAsync();

    /// <summary>
    /// Gets paged authors.
    /// </summary>
    /// <param name="service"></param>
    /// <returns>The auhtors.</returns>
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IQueryable<Book>> PagedBooks([Service] IBookService service) =>
        service.ListAsync();

    /// <summary>
    /// Gets author.
    /// </summary>
    /// <param name="service"></param>
    /// <returns>The auhtor.</returns>
    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public Task<IQueryable<Book>> Book([Service] IBookService service) =>
        service.ListAsync();
}