using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace CodebridgeTestAPI.Controllers;

[ApiController]
public class DogsController : ControllerBase
{
    private readonly DogsDbContext _dbContext;
    public DogsController(DogsDbContext dbContext) => _dbContext = dbContext;

    [HttpGet("dogs")]
    public async Task<IEnumerable<Dog>> Dogs()
    {
        var initialPipe = _dbContext.Dogs.AsNoTracking();
        return await initialPipe.ToListAsync();
    }

    public class SortingModel: ISortingModel
    {
        public OrderType order { get; set; }
        [RegularExpression("name|color|tail_length|weight", ErrorMessage = "Invalid value for attribute")]
        public string attribute { get; set; }
    }

    [HttpGet("dogs")]
    [QueryParameterConstraintAttribute("attribute", "pageNumber")]
    public async Task<IEnumerable<Dog>> Dogs([FromQuery] SortingModel query)
    {
        var initialPipe = _dbContext.Dogs.AsNoTracking();
        var orderByPipe = QueryPipes.OrderByPipe(initialPipe, query);
        return await orderByPipe.ToListAsync();
    }

    public class PagingModel: IPagingModel
    {
        public int pageNumber { get; set; }
        
        public int pageSize { get; set; }
        
        public int? limit { get; set; }
    }
    
    [HttpGet("dogs")]
    [QueryParameterConstraintAttribute("pageNumber", "attribute")]
    public async Task<IEnumerable<Dog>> Dogs([FromQuery] PagingModel query)
    {
        var initialPipe = _dbContext.Dogs.AsNoTracking().OrderBy(d => d.Id);
        var pagingPipe = QueryPipes.PagingPipe(initialPipe, query);
        
        return await pagingPipe.ToListAsync();
    }
    
    public class PagingAndSortingModel: IPagingModel, ISortingModel
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int? limit { get; set; }
        public OrderType order { get; set; }
        [RegularExpression("name|color|tail_length|weight", ErrorMessage = "Invalid value for attribute")]
        public string attribute { get; set; }
    }
    
    [HttpGet("dogs")]
    [QueryParameterConstraintAttribute("pageNumber")]
    [QueryParameterConstraintAttribute("attribute")]
    public async Task<IEnumerable<Dog>> Dogs([FromQuery] PagingAndSortingModel query)
    {
        var initialPipe = _dbContext.Dogs.AsNoTracking();
        var orderByPipe = QueryPipes.OrderByPipe(initialPipe, query);
        var pagingPipe = QueryPipes.PagingPipe(orderByPipe, query);
        
        return await pagingPipe.ToListAsync();
    }
}

public interface IPagingModel
{
    public int pageNumber { get; set; }
        
    public int pageSize { get; set; }
        
    public int? limit { get; set; }
}

public interface ISortingModel
{
    public OrderType order { get; set; }
    public string attribute { get; set; }
}

public enum OrderType { Asc, Desc }

public static class QueryPipes
{
    public static IQueryable<Dog> OrderByPipe(IQueryable<Dog> previousPipe, ISortingModel query)
    {
        return previousPipe.OrderBy($"{query.attribute} {query.order.ToString()}");
    }
    
    public static IQueryable<Dog> PagingPipe(IQueryable<Dog> previousPipe, IPagingModel query)
    {
        return previousPipe.Skip((query.pageNumber - 1) * query.pageSize).Take(query.limit ?? query.pageSize);
    }
}