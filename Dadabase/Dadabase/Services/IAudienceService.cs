using Dadabase.data;

namespace Dadabase.Services;

public interface IAudienceService
{
    
    public Task<Audience> GetAudienceByIdAsync(int id);
    public Task<Audience> AddAudienceAsync(Audience audience);

    public Task<IResult> DeleteAudienceByIdAsync(int id);
    public Task<ICollection<Audience>> GetAllAudiencesAsync();
    
}

