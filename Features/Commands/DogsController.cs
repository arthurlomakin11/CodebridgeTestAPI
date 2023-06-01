using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI.Features;

[ApiController]
public abstract class DogsController : ControllerBase
{
    protected readonly IQueryable<Dog> _initialPipe;
    protected DogsController(DogsDbContext dbContext) => _initialPipe = dbContext.Dogs.AsNoTracking().OrderBy(d => d.Id);
}
