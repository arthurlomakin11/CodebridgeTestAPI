using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI.Features;

[ApiController]
public abstract class BaseDogsController : ControllerBase
{
    protected readonly IQueryable<Dog> _initialPipe;
    protected BaseDogsController(DogsDbContext dbContext) => 
        _initialPipe = dbContext.Dogs.AsNoTracking().OrderBy(d => d.Id);
}
