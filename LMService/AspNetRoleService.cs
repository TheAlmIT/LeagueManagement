

using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;


namespace LMService
{
    public interface IAspNetRoleService : IService<AspNetRole>
    {
    }
    public class AspNetRoleService : Service<AspNetRole>, IAspNetRoleService
    {
        public AspNetRoleService(IRepositoryAsync<AspNetRole> respository):base(respository)
        {
        }
    }
}


