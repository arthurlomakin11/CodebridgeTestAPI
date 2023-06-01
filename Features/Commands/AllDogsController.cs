using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Controllers;

public class AllDogsController: DogsController
{
    public AllDogsController(DogsDbContext dbContext) : base(dbContext) { }
    
    [HttpGet("dogs")]
    public IQueryable<Dog> Dogs() => _initialPipe;
}