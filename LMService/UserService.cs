
using System;
using System.Collections.Generic;
using System.Linq;
using LMEntities.Models;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Service.Pattern;
using Repository.Pattern.UnitOfWork;

namespace LMService
{
    public interface IUserService : IService<User>
    {
        List<User> GetUmpiresList();
        List<User> GetUsers_NotUmpires();
        void SaveUmpires(List<string> umpireList);
        void DeleteUmpire(int id);
        List<Gender> Genders { get; }
        List<Organization> Organizations { get; }
        List<UserType> UserTypes { get; }
        List<User> Users { get; }
            
    }
    public class UserService : Service<User>, IUserService
    {
        readonly SportsSiteContext _dbSportsSiteContext = new SportsSiteContext();
        readonly IUnitOfWork _unitOfWork;

        public UserService(IRepositoryAsync<User> respository, IUnitOfWork unitOfWork):base(respository)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> GetUmpiresList()
        {
            return _dbSportsSiteContext.Users.Where(a => a.UserTypeId == 2).ToList();
        }

        public List<User> GetUsers_NotUmpires()
        {
            return _dbSportsSiteContext.Users.Where(a => a.UserTypeId != 2).ToList();
        }

        public void SaveUmpires(List<string> umpireList)
        {
            for (int i = 0; i < umpireList.Count(); i++)
            {
                string[] val = umpireList[i].Split('-');
                int userid = Convert.ToInt32(val[1]);
                User user = Find(userid);
                user.UserTypeId = 2;
                user.ObjectState = ObjectState.Modified;
                Update(user);
                _unitOfWork.SaveChanges();
            }
        }

        public void DeleteUmpire(int id)
        {
            User user = Find(id);
            user.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
            user.UserTypeId = 3;
            Update(user);
            _unitOfWork.SaveChanges();
        }

        public List<Gender> Genders => _dbSportsSiteContext.Genders.ToList();
        public List<Organization> Organizations => _dbSportsSiteContext.Organizations.ToList();
        public List<UserType> UserTypes => _dbSportsSiteContext.UserTypes.ToList();
        public List<User> Users => _dbSportsSiteContext.Users.ToList();
    }
}
