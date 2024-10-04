using Microsoft.AspNetCore.Mvc;
using Dadabase.data;
using Dadabase.Services;

namespace Dadabase.Controllers;

[ApiController]
[Route("[controller]")]
public class JokeController(IJokeService jokeService) : ControllerBase
{
    [HttpGet("{id}")]
    [EndpointName("GetJokeById")]
    [EndpointSummary("Retrieves a joke from the dadabase, based on the requested ID")]
    public async Task<Joke> GetJokeById(int id)
    {
        var result = await jokeService.GetJokeByIdAsync(id);
        return result;
    }

    [HttpGet]
    [EndpointName("GetAllJokes")]
    [EndpointSummary("Retrieves a list of all jokes in the dadabase")]
    [Route("all")]
    public async Task<IEnumerable<Joke>> GetAllJokesAsync()
    {
        var result = await jokeService.GetAllJokes();
        return result;
    }


    [HttpGet]
    [EndpointName("GetRandomJoke")]
    [EndpointSummary("Retrieves a random joke from the dadabase")]
    [Route("random")]
    public async Task<Joke> GetRandomJoke()
    {
        var result = await jokeService.GetRandomJokeAsync();
        return result;
    }


    [HttpPost]
    [EndpointName("AddJoke")]
    [EndpointSummary("Adds a joke to the dadabase")]
    [Route("add")]
    public async Task<IActionResult> AddJoke([FromBody] JokeDto jokeDto)
    {
        var joke = new Joke
        {
            Jokename = jokeDto.JokeName,
            Joketext = jokeDto.JokeText
        };

        var result = await jokeService.CreateJokeAsync(joke);
        return Ok();
    }

}

public class JokeDto
{
    public int Id { get; set; }
    public  string JokeName { get; set; }
    public  string JokeText { get; set; }   
}