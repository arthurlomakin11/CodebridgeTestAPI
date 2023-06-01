using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Features;

public class OrderedAndPagedDogsController: BaseDogsController
{
    public OrderedAndPagedDogsController(DogsDbContext dbContext) : base(dbContext) { }

    [HttpGet("dogs")]
    [QueryParameterConstraint("pageNumber")]
    [QueryParameterConstraint("attribute")]
    public IQueryable<Dog> Dogs([FromQuery] PagingAndOrderingModel query) => 
        _initialPipe
            .OrderPipe(query)
            .PagingPipe(query);
}