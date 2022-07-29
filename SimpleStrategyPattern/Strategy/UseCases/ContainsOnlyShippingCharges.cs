using StrategyPattern.Models;

namespace StrategyPattern.Strategy.UseCases
{
    public class ContainsOnlyShippingCharges : IFeeStrategy
    {
        // Use case 3
        // No warranty charges but only shipping fee
        // Total price gets 0% discount and add shipping fee
        public FeeModel Calculate(DataInput inputFees)
        {
            inputFees.TotalFee += inputFees.ShippingCharge ?? 0;

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
