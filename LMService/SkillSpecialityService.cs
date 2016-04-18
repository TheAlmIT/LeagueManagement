using LMEntities.Models;
using System.Collections.Generic;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Linq;

namespace LMService
{
    public interface ISkillSpecialityService : IService<SkillSpeciality>
    {
        List<Organization> Organizations { get; }
        List<User> Users { get; }
    }
    public class SkillSpecialityService : Service<SkillSpeciality>, ISkillSpecialityService
    {
        readonly SportsSiteContext _dbSportsSiteContext = new SportsSiteContext();
        public SkillSpecialityService(IRepositoryAsync<SkillSpeciality> respository):base(respository)
        {
        }

        public List<Organization> Organizations => _dbSportsSiteContext.Organizations.ToList();

        public List<User> Users => _dbSportsSiteContext.Users.ToList();
    }
}
