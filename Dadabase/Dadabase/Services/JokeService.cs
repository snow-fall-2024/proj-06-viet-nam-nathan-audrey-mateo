using Dadabase.data;
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

    public Task<Joke> GetJokeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Joke> GetRandomJokeAsync()
    {
        throw new NotImplementedException();
    }
}


//public async Task<Checkout> CreateCheckoutAsync(Checkout checkout)
//{
//    if (checkout == null || checkout.StoreCheckoutItems.Count <= 0)
//        throw new ArgumentException("You cannot complete a checkout without any items.");

//    context.StoreCheckouts.Add(checkout);
//    await context.SaveChangesAsync();

//    return checkout;
//}
