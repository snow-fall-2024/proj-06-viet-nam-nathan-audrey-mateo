using Dadabase.data;
using Microsoft.EntityFrameworkCore;

namespace Dadabase.Services;

public class AudienceService(Dbf25TeamNamContext context) : IAudienceService
{
    public async Task<IResult> DeleteAudienceByIdAsync(int id)
    {
           var audience = context.Audiences.Where(audience => audience.Id == id).FirstOrDefault();
        if (audience != null)
            context.Audiences.Remove(audience);
        await context.SaveChangesAsync();
        return Results.Ok();
    }

    public async Task<ICollection<Audience>> GetAllAudiencesAsync()
    {
        return await context.Audiences.ToListAsync();
    }

    public async Task<Audience> GetAudienceByIdAsync(int id)
    {
        return await context.Audiences
                   .Where(aud => aud.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Audience> AddAudienceAsync(Audience audience)
    {
        if (audience == null)
            throw new ArgumentException("You cannot create an audience without any content.");

        context.Audiences.Add(audience);
        await context.SaveChangesAsync();

        return audience;
    }
}
