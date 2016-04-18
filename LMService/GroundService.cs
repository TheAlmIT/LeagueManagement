
using LMEntities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;


namespace LMService
{
    public interface IGroundService : IService<Ground>
    {
    }
    public class GroundService : Service<Ground>, IGroundService
    {
        public GroundService(IRepositoryAsync<Ground> respository):base(respository)
        {
        }
    }
}
