using System;
using System.CodeDom;
using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Repository.Pattern.UnitOfWork;

namespace LMService
{
    public interface ITeamService : IService<Team>
    {
        Team GetTeam();
        void CreateTeam(Team team, List<string> teamMembers);
        void UpdateTeam(Team team, List<string> teamMembers);
    }
    public class TeamService : Service<Team>, ITeamService
    {
        readonly SportsSiteContext _dbContext = new SportsSiteContext();
        public ITeamMemeberService TeamMemeberService { get; }
        public IScheduleService ScheduleService { get; }
        public IUnitOfWork UnitOfWork { get; }

       public TeamService(IRepositoryAsync<Team> respository, IUnitOfWork unitOfWork, ITeamMemeberService teamMemeberService, IScheduleService scheduleService):base(respository)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            UnitOfWork = unitOfWork;
            TeamMemeberService = teamMemeberService;
            ScheduleService = scheduleService;
        }

        public override Task<List<Team>> GetAsync()
        {
            var result = Task.Run(() => GetTeams());
            return result;
        }

        public List<Team> GetTeams()
        {
            return _dbContext.Teams.ToList(); //.Include(c => c.User).Include(c => c.Organizations).ToList();
        }

        public override Team Find(params object[] keyValues)
        {
            Team team = base.Find(keyValues);
            team.Organizations = _dbContext.Organizations.ToList();
            team.Users = _dbContext.Users.Include(a => a.SkillSpeciality).ToList();
           
            team.Users = (from u in _dbContext.Users
                where !(from tm in _dbContext.TeamMembers
                    select tm.UserId)
                    .Contains(u.Id)
                select u).ToList();
            return team;
        }
       

        public override void Delete(object teamid)
        {
            int id = Convert.ToInt32(teamid);
            List<Schedule> homeTeamSchedules = _dbContext.Schedules.Where(a => a.HomeTeamId == id).ToList();

            foreach (Schedule schedule in homeTeamSchedules)
            {
                ScheduleService.Delete(schedule);
                UnitOfWork.SaveChanges();
            }

            List<Schedule> visitorTeamSchedules = _dbContext.Schedules.Where(a => a.VisitorTeamId == id).ToList();
            foreach (Schedule schedule in visitorTeamSchedules)
            {
                ScheduleService.Delete(schedule);
                UnitOfWork.SaveChanges();
            }

            List<TeamMember> listmembers = _dbContext.TeamMembers.Where(a => a.TeamId == id).ToList();

            foreach (TeamMember tm in listmembers)
            {
                TeamMemeberService.Delete(tm);
                UnitOfWork.SaveChanges();
            }

            base.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public Team GetTeam()
        {
            Team team = new Team
            {
                Users = (from u in _dbContext.Users
                    where !(from tm in _dbContext.TeamMembers
                        select tm.UserId)
                        .Contains(u.Id)
                    select u).ToList(),

                Organizations = _dbContext.Organizations.ToList(),

             //    TeamMembers  = _dbContext.TeamMembers.Include(a => a.SkillSpeciality).Where(a => a.TeamId == ).ToList()
        };
            return team;
        }

        public void CreateTeam(Team team,List<string> teamMembers )
        {
            Insert(team);
            UnitOfWork.SaveChanges();

            for (var i = 0; i < teamMembers.Count(); i++)
            {
                var val = teamMembers[i].Split('-');
                var userid = Convert.ToInt32(val[1].ToString());
                User user =  _dbContext.Users.Find(userid);
                TeamMember tm = new TeamMember
                {
                    Name = user.UserName,
                    UserId = user.Id,
                    TeamId = team.Id,
                    OrganizationId = 1
                };

                TeamMemeberService.Insert(tm);
                UnitOfWork.SaveChanges();
            }
        }

        public void UpdateTeam(Team team, List<string> teamMembers)
        {
           
            for (var i = 0; i < teamMembers.Count(); i++)
            {
                var val = teamMembers[i].Split('-');
                var userid = Convert.ToInt32(val[1].ToString());
                User user = _dbContext.Users.Find(userid);
                TeamMember tm = new TeamMember
                {
                    Name = user.UserName,
                    UserId = user.Id,
                    TeamId = team.Id,
                    OrganizationId = 1
                };

                TeamMemeberService.Insert(tm);
                UnitOfWork.SaveChanges();
            }
        }

    }
}
