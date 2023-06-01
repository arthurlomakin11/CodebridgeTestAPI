using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Controllers;

public class PagesDogsController: DogsController
{
    public PagesDogsController(DogsDbContext dbContext) : base(dbContext) { }

    [HttpGet("dogs")]
    [QueryParameterConstraintAttribute("pageNumber", "attribute")]
    public IQueryable<Dog> Dogs([FromQuery] PagingModel query)
    {
        var pagingPipe = QueryPipes.PagingPipe(_initialPipe, query);
        
        return pagingPipe;
    }
}

public interface IPagingModel
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