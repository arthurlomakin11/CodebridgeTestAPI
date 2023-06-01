using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI.Controllers;

[ApiController]
public abstract class DogsController : ControllerBase
{
    protected readonly IQueryable<Dog> _initialPipe;
    protected DogsController(DogsDbContext dbContext) => _initialPipe = dbContext.Dogs.AsNoTracking().OrderBy(d => d.Id);
}


public enum OrderType { Asc, Desc }