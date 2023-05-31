using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI.Controllers;

[ApiController]
public class DogsController : ControllerBase
{
    private readonly DogsDbContext _dbContext;

    public DogsController(DogsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("ping")]
    public string Ping()
    {
        return "Dogs house service. Version 1.0.1";
    }
    
    [HttpGet("dogs")]
    public async Task<IEnumerable<Dog>> Dogs()
    {
        return await _dbContext.Dogs.AsNoTracking().ToListAsync();
    }

    public enum OrderType { Asc, Desc }

    [HttpGet("dogs")]
    [QueryParameterConstraintAttribute("order", "pageNumber")]
    public async Task<IEnumerable<Dog>> Dogs(OrderType order, string attribute)
    {
        return await _dbContext.Dogs
            .AsNoTracking()
            .OrderBy(d => d.Name)
            .ToListAsync();
    }
    
    [HttpGet("dogs")]
    [QueryParameterConstraintAttribute("pageNumber", "order")]
    public async Task<IEnumerable<Dog>> Dogs(int pageNumber, int? limit, int pageSize)
    {
        return await _dbContext.Dogs
            .AsNoTracking()
            .OrderBy(d => d.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(limit ?? pageSize)
            .ToListAsync();
    }
    
    [HttpGet("dogs")]
    [QueryParameterConstraintAttribute("pageNumber")]
    [QueryParameterConstraintAttribute("order")]
    public async Task<IEnumerable<Dog>> Dogs(OrderType order, string attribute, int pageNumber, int? limit, int pageSize)
    {
        return await _dbContext.Dogs
            .AsNoTracking()
            .OrderBy(d => d.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(limit ?? pageSize)
            .ToListAsync();
    }

    [HttpPost("dog")]
    public async Task AddDog(Dog newDog)
    {
        await _dbContext.Dogs.AddAsync(newDog);
        await _dbContext.SaveChangesAsync();
    }
}