using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Features;

public class AllDogsController: BaseDogsController
{
    public AllDogsController(DogsDbContext dbContext) : base(dbContext) { }
    
    [HttpGet("dogs")]
    public IQueryable<Dog> Dogs() => _initialPipe;
}