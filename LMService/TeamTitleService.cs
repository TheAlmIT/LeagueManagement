using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LMService
{
    public interface ITeamTitleService : IService<TeamTitle>
    {
        List<Organization> Organizations { get; }
        List<User> Users { get; }

    }

    public class TeamTitleService : Service<TeamTitle>, ITeamTitleService
    {
        private readonly SportsSiteContext _dbspSportsSiteContext = new SportsSiteContext();

        public TeamTitleService(IRepositoryAsync<TeamTitle> respository) : base(respository)
        {
        }

        public List<Organization> Organizations => _dbspSportsSiteContext.Organizations.ToList();

        public List<User> Users => _dbspSportsSiteContext.Users.ToList();
    }
}


