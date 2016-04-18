
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Linq;
using System.Data.Entity;
using System.Xml.Schema;


namespace LMService
{
    public interface IScheduleService : IService<Schedule>
    {
        IDbSet<Team> Teams { get; }
        IDbSet<Ground> Grounds { get; }
        IDbSet<Season> Seasons { get; }
        IDbSet<User> Users { get; }

        List<Schedule> GetSchedule_ForUser(int userId);

        List<Schedule> GetSchedules_forGround(int groundId);
    }

    public class seasonServiceService : Service<Schedule>, IScheduleService
    {
        readonly SportsSiteContext _dbContext = new SportsSiteContext();

        public seasonServiceService(IRepositoryAsync<Schedule> respository) : base(respository)
        {
        }

        public override Task<List<Schedule>> GetAsync()
        {
            var result = Task.Run(() => Schedules);
            return result;
        }

        public List<Schedule> Schedules
        {
            get
            {
                return
                    _dbContext.Schedules.Include(c => c.Ground)
                        .Include(c => c.Team)
                        .Include(c => c.Team1)
                        .Include(c => c.Season)
                        .Include(c => c.Year)
                        .Include(c => c.Umpire)
                        .ToList();
            }
        }

        public override Schedule Find(params object[] keyValues)
        {
            Schedule schedule = base.Find(Convert.ToInt32(keyValues[0]));
            schedule.Team =
                (Team) (from a in _dbContext.Teams where a.Id == schedule.HomeTeamId select a).SingleOrDefault();
            schedule.Team1 =
                (Team) (from a in _dbContext.Teams where a.Id == schedule.VisitorTeamId select a).SingleOrDefault();
            schedule.Ground =
                (Ground) (from a in _dbContext.Grounds where a.Id == schedule.GroundId select a).SingleOrDefault();
            schedule.Season =
                (Season) (from a in _dbContext.Seasons where a.Id == schedule.SeasonId select a).SingleOrDefault();
            schedule.Umpire =
                (User) (from a in _dbContext.Users where a.Id == schedule.UmpireId select a).SingleOrDefault();
            return schedule;
        }

        public IDbSet<Team> Teams => _dbContext.Teams;

        public IDbSet<Ground> Grounds => _dbContext.Grounds;

        public IDbSet<User> Users => _dbContext.Users;
        public List<Schedule> GetSchedule_ForUser(int userId)
        {
          return  _dbContext.Schedules.Where(a => a.UmpireId == userId).ToList();
        }

        public List<Schedule> GetSchedules_forGround(int groundId)
        {
            return _dbContext.Schedules.Where(a => a.GroundId == groundId).ToList();
        }

        public IDbSet<Season> Seasons => _dbContext.Seasons;
    }
}