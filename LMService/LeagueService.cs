
using System.Collections.Generic;
using System.Threading.Tasks;
using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Linq;
using System.Data.Entity;
using System;

namespace LMService
{
    public interface ILeagueService : IService<League>
    {
    }
    public class LeagueService : Service<League>, ILeagueService
    {
        SportsSiteContext db = new SportsSiteContext();
        public LeagueService(IRepositoryAsync<League> respository) : base(respository)
        {
        }

        public override Task<List<League>> GetAsync()
        {
            var result = Task.Run(() => getLeagues());
            return result;
        }

        private List<League> getLeagues()
        {
            return db.Leagues.Include(c => c.Organization).ToList();
        }

        public override League Find(params object[] keyValues)
        {
            League league = base.Find(Convert.ToInt32(keyValues[0]));
            league.Organization = (Organization)(from a in db.Organizations where a.Id == league.OrganizationId select a).SingleOrDefault();
            return league;
        }
        public IDbSet<Organization> Organizations => db.Organizations;

    }
}

