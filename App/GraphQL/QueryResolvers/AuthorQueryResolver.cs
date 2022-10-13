using App.Models;
using App.Services;

namespace App.GraphQL.QueryResolvers;

[ExtendObjectType(typeof(Query))]
public class AuthorQueryResolver
{
    /// <summary>
    /// Gets all authors.
    /// </summary>
    /// <param name="service"></param>
    /// <returns>The auhtors.</returns>
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IQueryable<Author>> Authors([Service] IAuthorService service) =>
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
    public Task<IQueryable<Author>> PagedAuthors([Service] IAuthorService service) =>
        service.ListAsync();

    /// <summary>
    /// Gets author.
    /// </summary>
    /// <param name="service"></param>
    /// <returns>The auhtor.</returns>
    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public Task<IQueryable<Author>> Author([Service] IAuthorService service) =>
        service.ListAsync();

}