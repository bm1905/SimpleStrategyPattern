using StrategyPattern.Models;

namespace StrategyPattern.Strategy.UseCases
{
    public class ContainsOnlyWarrantyCharges : IFeeStrategy
    {
        // Use case 2
        // No shipping fee but only warranty charges
        // Add warranty charges to total
        // Perform 20% discount
        public FeeModel Calculate(DataInput inputFees)
        {
            inputFees.TotalFee += inputFees.WarrantCharge ?? 0;
            inputFees.TotalFee -= (decimal)20 / 100 * inputFees.TotalFee;

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
