using Dadabase.data;
using Microsoft.EntityFrameworkCore;

namespace Dadabase.Services
{
    public class AudienceService(Dbf25TeamNamContext context) : ITService<Audience>
    {
        public async Task DeleteAudience(int id)
        {
               var audience = context.Audiences.Where(audience => audience.Id == id).FirstOrDefault();
            if (audience != null)
                context.Audiences.Remove(audience);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Audience>> GetAllAudiences()
        {
            return await context.Audiences.ToListAsync();
        }

        public async Task<Audience> GetAudience(int id)
        {
            var audience = context.Audiences.Where(aud => aud.Id == id).FirstOrDefault();
            if (audience != null)
                return audience;
            throw new InvalidOperationException();
        }

        public async Task PostAudience(Audience audience)
        {
            context.Audiences.Add(audience);
            await context.SaveChangesAsync();
        }
    }
}
