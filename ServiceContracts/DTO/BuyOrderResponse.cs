using Entities;

namespace ServiceContracts.DTO
{
    public class BuyOrderResponse
    {
        public Guid BuyOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
        public double TradeAmount { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(BuyOrderResponse)) return false;
            BuyOrderResponse other = (BuyOrderResponse)obj;
            return BuyOrderID == other.BuyOrderID && StockSymbol == other.StockSymbol && StockName == other.StockName && DateAndTimeOfOrder == other.DateAndTimeOfOrder && Quantity == other.Quantity && Price == other.Price;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Buy Order ID: {BuyOrderID}, Stock Symbol: {StockSymbol}, Stock Name: {StockName}, Date and Time of Buy Order: {DateAndTimeOfOrder.ToString("dd MMM yyyy hh:mm ss tt")}, Quantity: {Quantity}, Buy Price: {Price}, Trade Amount: {TradeAmount}";
        }
    }

    public static class BuyOrderResponseExtensions
    {
        public static BuyOrderResponse toBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse { BuyOrderID = buyOrder.BuyOrderID, StockSymbol = buyOrder.StockSymbol, StockName = buyOrder.StockName,DateAndTimeOfOrder= buyOrder.DateAndTimeOfOrder, Price = buyOrder.Price, Quantity = buyOrder.Quantity, TradeAmount = buyOrder.Price * buyOrder.Quantity };
        }
    }
}
