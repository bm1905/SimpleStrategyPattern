using StrategyPattern.Models;

namespace StrategyPattern.Strategy
{
    public interface IFeeStrategy
    {
        FeeModel Calculate(DataInput model);
    }
}
