using Dadabase.data;

namespace Dadabase.Services;

public interface IJokeService
{
    public Task<Joke> CreateJokeAsync();
    public Task<Joke> GetJokeByIdAsync(int id);
    public Task<Joke> GetRandomJokeAsync();
}
