using StrategyPattern.Models;

namespace StrategyPattern.Strategy.UseCases
{
    public class ContainsNoCharges : IFeeStrategy
    {
        // Use case 4
        // No charges
        public FeeModel Calculate(DataInput inputFees)
        {
            return new FeeModel
            {
                TotalFee = inputFees.TotalFee,
                ShippingCharge = inputFees.ShippingCharge,
                WarrantCharge = inputFees.WarrantCharge,
                Name = inputFees.Name
            };
        }
    }
}
