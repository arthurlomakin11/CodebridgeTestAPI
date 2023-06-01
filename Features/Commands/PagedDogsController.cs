using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Features;

public class PagesDogsController: BaseDogsController
{
    public PagesDogsController(DogsDbContext dbContext) : base(dbContext) { }

    [HttpGet("dogs")]
    [QueryParameterConstraint("pageNumber")]
    [QueryParameterExclusion("attribute")]
    public IQueryable<Dog> Dogs([FromQuery] PagingModel query) => 
        _initialPipe.PagingPipe(query);
}