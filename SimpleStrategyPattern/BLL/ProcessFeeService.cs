using StrategyPattern.Models;
using System.Threading.Tasks;
using StrategyPattern.DAL;
using StrategyPattern.Strategy;
using StrategyPattern.Strategy.UseCases;

namespace StrategyPattern.BLL
{
    public class ProcessFeeService : IProcessFeeService
    {
        private readonly IProcessFeeRepository _processFeeRepository;
        public ProcessFeeService(IProcessFeeRepository processFeeRepository)
        {
            _processFeeRepository = processFeeRepository;
        }
        public async Task<FeeModel> CalculateCharges(DataInput inputFees)
        {
            if (inputFees.ShippingCharge.GetValueOrDefault() != 0 && inputFees.WarrantCharge.GetValueOrDefault() != 0)
            {
                CalculateFee calculateFee = new CalculateFee(new ContainsWarrantyAndShippingCharges());
                FeeModel feeModel = calculateFee.Calculate(inputFees);
                var key = await _processFeeRepository.InsertFee(feeModel);
                var output = await _processFeeRepository.GetFee<FeeModel>(key);
                return output;
            }

            if (inputFees.ShippingCharge.GetValueOrDefault() != 0 && inputFees.WarrantCharge.GetValueOrDefault() == 0)
            {
                CalculateFee calculateFee = new CalculateFee(new ContainsOnlyShippingCharges());
                FeeModel feeModel = calculateFee.Calculate(inputFees);
                var key = await _processFeeRepository.InsertFee(feeModel);
                var output = await _processFeeRepository.GetFee<FeeModel>(key);
                return output;
            }

            if (inputFees.ShippingCharge.GetValueOrDefault() == 0 && inputFees.WarrantCharge.GetValueOrDefault() != 0)
            {
                CalculateFee calculateFee = new CalculateFee(new ContainsOnlyWarrantyCharges());
                FeeModel feeModel = calculateFee.Calculate(inputFees);
                var key = await _processFeeRepository.InsertFee(feeModel);
                var output = await _processFeeRepository.GetFee<FeeModel>(key);
                return output;
            }

            if (inputFees.ShippingCharge.GetValueOrDefault() == 0 && inputFees.WarrantCharge.GetValueOrDefault() == 0)
            {
                CalculateFee calculateFee = new CalculateFee(new ContainsNoCharges());
                FeeModel feeModel = calculateFee.Calculate(inputFees);
                var key = await _processFeeRepository.InsertFee(feeModel);
                var output = await _processFeeRepository.GetFee<FeeModel>(key);
                return output;
            }

            return default;
        }
    }
}
