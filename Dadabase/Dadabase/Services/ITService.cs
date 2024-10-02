using Dadabase.data;

namespace Dadabase.Services
{
    public interface ITService<T> where T : class
    {
        
        public Task<T> GetAudience(int id);
        public Task PostAudience(T audience);

        public Task DeleteAudience(int id);
        public Task<ICollection<T>>GetAllAudiences();
        
    }
}
