
using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace LMService
{
    public interface ILeagueGroupService : IService<Season>
    {
    }
    public class LeagueGroupService : Service<Season>, ILeagueGroupService
    {
        public LeagueGroupService(IRepositoryAsync<Season> seasonRepository):base(seasonRepository)
        {
        }
    }
}
