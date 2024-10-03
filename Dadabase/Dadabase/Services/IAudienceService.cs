using Dadabase.data;

namespace Dadabase.Services;

public interface IAudienceService
{
    
    public Task<Audience> GetAudienceByIdAsync(int id);
    public Task AddAudienceAsync(Audience audience);

    public Task DeleteAudienceByIdAsync(int id);
    public Task<ICollection<Audience>> GetAllAudiencesAsync();
    
}

