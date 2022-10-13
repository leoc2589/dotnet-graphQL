using App.GraphQL;
using App.GraphQL.MutationResolver;
using App.GraphQL.QueryResolvers;
using App.GraphQL.Types;
using App.Models;
using App.Services;
using HotChocolate.Execution.Configuration;

namespace App.Extensions;

public static class GraphQLServerExtension
{
    public static IRequestExecutorBuilder RegisterDbContext(this IRequestExecutorBuilder builder)
    {
        return builder
            .RegisterDbContext<LibraryContext>(DbContextKind.Pooled);
    }

    public static IRequestExecutorBuilder RegisterServices(this IRequestExecutorBuilder builder)
    {
        return builder
            .RegisterService<IAuthorService>()
            .RegisterService<IBookService>();
    }

    public static IRequestExecutorBuilder RegisterQueries(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddQueryType<Query>()
            .AddTypeExtension<AuthorQueryResolver>()
            .AddTypeExtension<BookQueryResolver>();
    }

    public static IRequestExecutorBuilder RegisterMutations(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddMutationType<Mutation>()
            .AddTypeExtension<AuthorMutationResolver>()
            .AddTypeExtension<BookMutationResolver>();
    }

    public static IRequestExecutorBuilder RegisterTypes(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<AuthorType>()
            .AddType<BookType>();
    }
}