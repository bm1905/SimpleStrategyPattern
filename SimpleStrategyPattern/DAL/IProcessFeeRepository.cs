using System.Threading.Tasks;

namespace StrategyPattern.DAL
{
    public interface IProcessFeeRepository
    {
        Task<string> InsertFee<T>(T entity);
        Task<T> GetFee<T>(string key);
    }
}
