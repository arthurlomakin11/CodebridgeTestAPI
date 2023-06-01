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

    [HttpGet("ping")]
    public string Ping()
    {
        return "Dogs house service. Version 1.0.1";
    }
    
    [HttpGet("dogs")]
    public async Task<IEnumerable<Dog>> Dogs()
    {
        return await _dbContext.Dogs.AsNoTracking().ToListAsync();
    }

    public enum OrderType { Asc, Desc }

    private interface ISortingModel
    {
        public OrderType order { get; set; }
        public string attribute { get; set; }
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
        var orderByPipe = initialPipe.OrderBy($"{query.attribute} {query.order.ToString()}");
        return await orderByPipe.ToListAsync();
    }

    private interface IPagingModel
    {
        public int pageNumber { get; set; }
        
        public int pageSize { get; set; }
        
        public int? limit { get; set; }
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
        var pagingPipe = initialPipe.Skip((query.pageNumber - 1) * query.pageSize).Take(query.limit ?? query.pageSize);
        
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
        var orderByPipe = initialPipe.OrderBy($"{query.attribute} {query.order.ToString()}");
        var pagingPipe = orderByPipe.Skip((query.pageNumber - 1) * query.pageSize).Take(query.limit ?? query.pageSize);
        
        return await pagingPipe.ToListAsync();
    }

    [HttpPost("dog")]
    public async Task AddDog(Dog newDog)
    {
        await _dbContext.Dogs.AddAsync(newDog);
        await _dbContext.SaveChangesAsync();
    }
}