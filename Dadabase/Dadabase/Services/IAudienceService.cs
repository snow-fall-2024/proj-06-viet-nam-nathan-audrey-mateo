using Dadabase.data;

namespace Dadabase.Services
{
    public interface IAudienceService
    {
        
        public Task<Audience> GetAudience(int id);
        public Task PostAudience(Audience audience);

        public Task DeleteAudience(int id);
        public Task<ICollection<Audience>>GetAllAudiences();
        
    }
}
