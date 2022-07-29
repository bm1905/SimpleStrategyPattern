using StrategyPattern.Models;

namespace StrategyPattern.Strategy.UseCases
{
    public class ContainsWarrantyAndShippingCharges : IFeeStrategy
    {
        // Use case 1
        // Both shipping fee and warranty charges are present
        // Add warranty charges to total
        // Perform 40% discount
        // Add shipping charges
        public FeeModel Calculate(DataInput inputFees)
        {
            inputFees.TotalFee += inputFees.WarrantCharge ?? 0;
            inputFees.TotalFee -= (decimal)40 / 100 * inputFees.TotalFee;
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
