using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Features;

public class OrderedDogsController: BaseDogsController
{
    public OrderedDogsController(DogsDbContext dbContext) : base(dbContext) { }

    [HttpGet("dogs")]
    [QueryParameterConstraint("attribute")]
    [QueryParameterExclusion("pageNumber")]
    public IQueryable<Dog> Dogs([FromQuery] OrderingModel query) => 
        _initialPipe.OrderPipe(query);
}