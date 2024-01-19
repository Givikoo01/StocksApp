
using Entities;

namespace ServiceContracts.DTO
{
    public class SellOrderResponse
    {
        public Guid SellOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
        public double TradeAmount { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(SellOrderResponse)) return false;
            return obj is SellOrderResponse response &&
                   SellOrderID.Equals(response.SellOrderID) &&
                   StockSymbol == response.StockSymbol &&
                   StockName == response.StockName &&
                   DateAndTimeOfOrder == response.DateAndTimeOfOrder &&
                   Quantity == response.Quantity &&
                   Price == response.Price &&
                   TradeAmount == response.TradeAmount;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public static class SellOrderResponseExtensions
    {
        public static SellOrderResponse toSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse { SellOrderID = sellOrder.SellOrderID, StockSymbol = sellOrder.StockSymbol, StockName = sellOrder.StockName, DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder, Quantity = sellOrder.Quantity, Price = sellOrder.Price, TradeAmount = sellOrder.Price * sellOrder.Quantity };
        }
    }
}
