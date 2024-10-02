using Microsoft.AspNetCore.Mvc;

namespace Dadabase.Controllers;

[ApiController]
[Route("[controller]")]

public class JokeController() : ControllerBase
{


    [HttpGet]
    [EndpointName("GetJokeById")]
    [EndpointSummary("Retrieves a joke from the dadabase, based on the requested ID")]
    public string GetJokeById()
    {
        throw new NotImplementedException();
    }
    [HttpGet]
    [EndpointName("GetRandomJoke")]
    [EndpointSummary("Retrieves a random joke from the dadabase")]
    public string GetRandomJoke()
    {
        throw new NotImplementedException();
    }
}

public class JokeDto
{
    public int Id { get; set; }
    public  string JokeName { get; set; }
    public  string JokeText { get; set; }   
}