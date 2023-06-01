using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Features;

public class OrderedDogsController: DogsController
{
    public OrderedDogsController(DogsDbContext dbContext) : base(dbContext) { }

    [HttpGet("dogs")]
    [QueryParameterConstraint("attribute")]
    [QueryParameterExclusion("pageNumber")]
    public IQueryable<Dog> Dogs([FromQuery] OrderingModel query)
    {
        var orderByPipe = QueryPipes.OrderByPipe(_initialPipe, query);
        return orderByPipe;
    }
}

public interface IOrderingModel
{
    public OrderType order { get; set; }
    public string attribute { get; set; }
}

public class OrderingModel: IOrderingModel
{
    public OrderType order { get; set; }
    [RegularExpression("name|color|tail_length|weight", ErrorMessage = "Invalid value for attribute")]
    public string attribute { get; set; }
}