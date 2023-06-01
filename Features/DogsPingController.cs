using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Controllers;

[ApiController]
public class DogsPingController
{
    [HttpGet("ping")]
    public string Ping()
    {
        return "Dogs house service. Version 1.0.1";
    }
}