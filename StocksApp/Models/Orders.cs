using ServiceContracts.DTO;

namespace StocksApp.Models;

public class Orders
{
    public List<BuyOrderResponse> BuyOrders;

    public List<SellOrderResponse> SellOrders;
}