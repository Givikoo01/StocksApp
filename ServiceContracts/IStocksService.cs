using ServiceContracts.DTO;


namespace Services
{
    public interface IStocksService
    {
        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
        public SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest);
        public List<BuyOrderResponse> GetBuyOrders();
        public List<SellOrderResponse> GetSellOrders();
    }
}
