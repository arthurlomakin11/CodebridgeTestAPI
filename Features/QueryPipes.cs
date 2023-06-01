using System.Linq.Dynamic.Core;

namespace CodebridgeTestAPI.Controllers;

public static class QueryPipes
{
    public static IQueryable<Dog> OrderByPipe(IQueryable<Dog> previousPipe, IOrderingModel query)
    {
        return previousPipe.OrderBy($"{query.attribute} {query.order.ToString()}");
    }
    
    public static IQueryable<Dog> PagingPipe(IQueryable<Dog> previousPipe, IPagingModel query)
    {
        return previousPipe.Skip((query.pageNumber - 1) * query.pageSize).Take(query.limit ?? query.pageSize);
    }
}