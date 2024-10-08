﻿using Dadabase.data;
using Microsoft.EntityFrameworkCore;

namespace Dadabase.Services;

public class JokeService(Dbf25TeamNamContext context) : IJokeService
{
    public async Task<Joke> CreateJokeAsync(Joke joke)
    {
        if(joke == null)
            throw new ArgumentException("You cannot create a joke without any content.");
        
        context.Jokes.Add(joke);
        await context.SaveChangesAsync();

        return joke;
    }

    public async Task<ICollection<Joke>> GetAllJokes()
    {
        return await context.Jokes.ToListAsync();
    }

    public async Task<Joke> GetJokeByIdAsync(int id)
    {
        return await context.Jokes
            .Where(j => j.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Joke> GetRandomJokeAsync()
    {
        Random random = new Random();
        int randomId = random.Next(context.Jokes.ToList().Min(j => j.Id), context.Jokes.ToList().Max(j => j.Id));
        return await GetJokeByIdAsync(randomId);
    }
}