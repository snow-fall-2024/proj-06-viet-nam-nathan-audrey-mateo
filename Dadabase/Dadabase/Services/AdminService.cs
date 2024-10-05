using Dadabase.data;

namespace Dadabase.Services;

public class AdminService(Dbf25TeamNamContext context) : IAdminService
{
    public void ResetData()
    {
        foreach (var joke in context.Jokes)
        {
            context.Jokes.Remove(joke);
        }
        foreach (var audience in context.Audiences)
        {
            context.Audiences.Remove(audience);
        }

        context.SaveChanges();
    }
}
