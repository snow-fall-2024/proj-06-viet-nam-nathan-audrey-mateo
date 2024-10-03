using Dadabase.data;
using Microsoft.EntityFrameworkCore;

namespace Dadabase.Services
{
    public class AudienceService(Dbf25TeamNamContext context) :IAudienceService
    {
        public async Task DeleteAudienceByIdAsync(int id)
        {
               var audience = context.Audiences.Where(audience => audience.Id == id).FirstOrDefault();
            if (audience != null)
                context.Audiences.Remove(audience);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Audience>> GetAllAudiencesAsync()
        {
            return await context.Audiences.ToListAsync();
        }

        public async Task<Audience> GetAudienceByIdAsync(int id)
        {
            var audience = context.Audiences.Where(aud => aud.Id == id).FirstOrDefault();
            if (audience != null)
                return audience;
            throw new InvalidOperationException();
        }

        public async Task AddAudienceAsync(Audience audience)
        {
            context.Audiences.Add(audience);
            await context.SaveChangesAsync();
        }
    }
}
