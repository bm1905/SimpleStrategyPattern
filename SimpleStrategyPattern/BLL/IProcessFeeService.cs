using System.Threading.Tasks;
using StrategyPattern.Models;

namespace StrategyPattern.BLL
{
    public interface IProcessFeeService
    {
        Task<FeeModel> CalculateCharges(DataInput inputFees);
    }
}
