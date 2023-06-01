﻿using System.Linq.Dynamic.Core;

namespace CodebridgeTestAPI.Features;

public static class QueryPipes
{
    public static IQueryable<Dog> OrderPipe(this IQueryable<Dog> previousPipe, IOrderingModel query)
    {
        return previousPipe.OrderBy($"{query.attribute} {query.order.ToString()}"); // using Dynamic LINQ for property access
    }
    
    public static IQueryable<Dog> PagingPipe(this IQueryable<Dog> previousPipe, IPagingModel query)
    {
        return previousPipe
            .Skip((query.pageNumber - 1) * query.pageSize)
            .Take(query.limit ?? query.pageSize);
    }
}
