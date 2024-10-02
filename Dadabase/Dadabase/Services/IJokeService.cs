using Dadabase.data;

namespace Dadabase.Services;

public interface IJokeService
{
    public Task<Joke> CreateJokeAsync(Joke joke);
    public Task<Joke> GetJokeByIdAsync(int id);
    public Task<Joke> GetRandomJokeAsync();
    public Task<IEnumerable<Joke>> GetAllJokes();
}
