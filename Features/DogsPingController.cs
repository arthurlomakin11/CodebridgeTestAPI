using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTestAPI.Features;

[ApiController]
public class DogsPingController
{
    [HttpGet("ping")]
    public string Ping() => "Dogs house service. Version 1.0.1";
}