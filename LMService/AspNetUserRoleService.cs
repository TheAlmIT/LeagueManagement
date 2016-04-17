

using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;


namespace LMService
{
    public interface IAspNetUserRoleService : IService<AspNetUserRoles>
    {
    }
    public class AspNetUserRoleService : Service<AspNetUserRoles>, IAspNetUserRoleService
    {
        public AspNetUserRoleService(IRepositoryAsync<AspNetUserRoles> respository):base(respository)
        {
        }
    }
}


