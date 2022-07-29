namespace StrategyPattern.Models
{
    public class DataInput
    {
        public string Name { get; set; }
        public decimal TotalFee { get; set; }
        public decimal? ShippingCharge { get; set; }
        public decimal? WarrantCharge { get; set; }
    }
}
