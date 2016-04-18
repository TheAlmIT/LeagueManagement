using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Linq;
using System.Data.Entity;

namespace LMService
{
    public interface ISeasonService : IService<Season>
    {
        List<League> Leagues { get; }
        List<Organization> Organizations { get; }  
    }
    public class SeasonService : Service<Season>, ISeasonService
    {
        readonly SportsSiteContext _dbContext = new SportsSiteContext();
        public SeasonService(IRepositoryAsync<Season> respository):base(respository)
        {
        }

        public override Task<List<Season>> GetAsync()
        {
            var result = Task.Run(() => Seasons);
            return result;
        }

        public List<Season> Seasons
        {
            get
            {
                return
                    _dbContext.Seasons.Include(a=>a.League)
                        .ToList();
            }
        }
        public override Season Find(params object[] keyValues)
        {
            Season season = base.Find(Convert.ToInt32(keyValues[0]));

            season.League = (League)(from a in _dbContext.Leagues where a.Id == season.LeagueId select a).SingleOrDefault();
            season.Organization = (Organization)(from a in _dbContext.Organizations where a.Id == season.OrganizationId select a).SingleOrDefault();
            return season;
        }
        public IDbSet<League> Leagues => _dbContext.Leagues;
        public IDbSet<Organization> Organizations => _dbContext.Organizations;

        List<League> ISeasonService.Leagues => _dbContext.Leagues.ToList();

        List<Organization> ISeasonService.Organizations => _dbContext.Organizations.ToList();
    }
}
