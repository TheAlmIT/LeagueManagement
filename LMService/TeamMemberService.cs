using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LMService
{
    public interface ITeamMemeberService : IService<TeamMember>
    {
        List<SkillSpeciality> SkillSpecialities { get; }
        List<Team> Teams { get; }
    }
    public class TeamMemberService : Service<TeamMember>, ITeamMemeberService
    {
        readonly SportsSiteContext _dbSportsSiteContext = new SportsSiteContext();
        
        public TeamMemberService(IRepositoryAsync<TeamMember> respository):base(respository)
        {
        }
        public override Task<List<TeamMember>> GetAsync()
        {
            var result = Task.Run(() => GetTeams());
            return result;
        }

        private List<TeamMember> GetTeams()
        {
            return _dbSportsSiteContext.TeamMembers.Include(c => c.Team).ToList();
        }

        public List<SkillSpeciality> SkillSpecialities => _dbSportsSiteContext.SkillSpecialities.ToList();

        public List<Team> Teams => _dbSportsSiteContext.Teams.ToList();

    }
}


