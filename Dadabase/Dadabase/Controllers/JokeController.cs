using Microsoft.AspNetCore.Mvc;
using Dadabase.data;
using Dadabase.Services;

namespace Dadabase.Controllers;

[ApiController]
[Route("[controller]")]

public class JokeController(IJokeService jokeService) : ControllerBase
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


    [HttpPost]
    [EndpointName("AddJoke")]
    [EndpointSummary("Adds a joke to the dadabase")]
    public async Task<IActionResult> AddJoke([FromBody] JokeDto jokeDto)
    {
        var joke = new Joke
        {
            Jokename = jokeDto.JokeName,
            Joketext = jokeDto.JokeText
        };

        var result = await jokeService.CreateJokeAsync(joke);
        return Ok(result);
    }

}

public class JokeDto
{
    public int Id { get; set; }
    public  string JokeName { get; set; }
    public  string JokeText { get; set; }   
}