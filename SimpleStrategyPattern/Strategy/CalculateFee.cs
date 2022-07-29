using StrategyPattern.Models;

namespace StrategyPattern.Strategy
{
    public class CalculateFee
    {
        private readonly IFeeStrategy _feeStrategy;

        public CalculateFee(IFeeStrategy feeStrategy)
        {
            _feeStrategy = feeStrategy;
        }

        public FeeModel Calculate(DataInput model)
        {
            return _feeStrategy.Calculate(model);
        }
    }
}
