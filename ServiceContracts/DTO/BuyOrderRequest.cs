using System.ComponentModel.DataAnnotations;
using ServiceContracts.CustomValidators;
using Entities;
namespace ServiceContracts.DTO
{
    public class BuyOrderRequest
    {
        [Required]
        public string? StockSymbol { get; set; }
        [Required]
        public string? StockName { get; set; }
        [AgeValidation("01/01/2000")]
        public DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000, ErrorMessage = "Value should be between 1 and 100000")]
        public uint Quantity { get; set; }
        [Range(1, 10000, ErrorMessage = "Value should be between 1 and 10000")]
        public double Price { get; set; }

        public BuyOrder toBuyOrder()
        {
            return new BuyOrder { StockSymbol = StockSymbol, StockName = StockName,DateAndTimeOfOrder = DateAndTimeOfOrder, Price = Price, Quantity = Quantity};
        }
    }
}
