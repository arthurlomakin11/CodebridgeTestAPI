using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Features;

public class OrderedAndPagedDogsController: DogsController
{
    public OrderedAndPagedDogsController(DogsDbContext dbContext) : base(dbContext) { }

    [HttpGet("dogs")]
    [QueryParameterConstraint("pageNumber")]
    [QueryParameterConstraint("attribute")]
    public IQueryable<Dog> Dogs([FromQuery] PagingAndOrderingModel query)
    {
        var orderByPipe = QueryPipes.OrderByPipe(_initialPipe, query);
        var pagingPipe = QueryPipes.PagingPipe(orderByPipe, query);
        
        return pagingPipe;
    }
}

public class PagingAndOrderingModel: IPagingModel, IOrderingModel
{
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
    public int? limit { get; set; }
    public OrderType order { get; set; }
    [RegularExpression("name|color|tail_length|weight", ErrorMessage = "Invalid value for attribute")]
    public string attribute { get; set; }
}