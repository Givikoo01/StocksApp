
namespace ServiceContracts
{
    public interface IFinnhubService
    {
        public Dictionary<string, object>? GetCompanyProfile(string stockSymbol);
        public Dictionary<string, object>? GetStockPriceQuote(string stockSymbol);
    }
}
