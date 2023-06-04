using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI.Features;

public class AddDogController: ControllerBase
{
    private readonly DogsDbContext _dbContext;
    public AddDogController(DogsDbContext dbContext) => _dbContext = dbContext;
    
    [HttpPost("dog")]
    public async Task<IActionResult> AddDog([FromBody] Dog newDog)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var dogExists = await _dbContext.Dogs.AnyAsync(dog => dog.Name == newDog.Name);
        if (dogExists) return BadRequest($"Dog with name {newDog.Name} already exists");
        
        await _dbContext.Dogs.AddAsync(newDog);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}