using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Controllers;

public class AddDogController
{
    private readonly DogsDbContext _dbContext;
    public AddDogController(DogsDbContext dbContext) => _dbContext = dbContext;
    
    [HttpPost("dog")]
    public async Task AddDog(Dog newDog)
    {
        await _dbContext.Dogs.AddAsync(newDog);
        await _dbContext.SaveChangesAsync();
    }
}