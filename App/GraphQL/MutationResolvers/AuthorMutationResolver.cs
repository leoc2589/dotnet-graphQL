using App.Models;
using App.Services;

namespace App.GraphQL.MutationResolver;

[ExtendObjectType(typeof(Mutation))]
public class AuthorMutationResolver
{
    /// <summary>
    /// Create author.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="input"></param>
    /// <returns>The auhtor.</returns>
    public Task<Author> CreateAuthor([Service] IAuthorService service, Author input) =>
        service.CreateAsync(input);

    /// <summary>
    /// Update author.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="input"></param>
    /// <returns>The auhtor.</returns>
    public Task<Author> UpdateAuthor([Service] IAuthorService service, Author input) =>
        service.UpdateAsync(input);

    /// <summary>
    /// Delete author.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="input"></param>
    /// <returns>The auhtor.</returns>
    public Task<Author> DeleteAuthor([Service] IAuthorService service, Author input) =>
        service.DeleteAsync(input);
}