using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace UnitTests
{
    public class StocksTest
    {
        private readonly IStocksService _stocksService;
        public StocksTest()
        {
            _stocksService = new StocksService(); 
        }

        #region CreateBuyOrder

        //When you supply BuyOrderRequest as null, it should throw ArgumentNullException.
        [Fact]
        public void CreateBuyOrder_NullArgument()
        {
            //Arrange
            BuyOrderRequest? request = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _stocksService.CreateBuyOrder(request);
            });
        }

        //When you supply buyOrderQuantity as 0 (as per the specification, minimum is 1),
        //it should throw ArgumentException.

        [Fact]
        public void BuyOrderRequest_Zero_Quantity()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 0 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(request);
            });
        }

        //When you supply buyOrderQuantity as 100001 (as per the specification, maximum is 100000),
        //it should throw ArgumentException.
        [Fact]
        public void BuyOrderRequest_QuantityIsGreaterThanMaximum()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 100001 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(request);
            });
        }

        // When you supply buyOrderPrice as 0 (as per the specification, minimum is 1),
        // it should throw ArgumentException.
        [Fact]
        public void BuyOrderRequest_Zero_Price()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 0, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(request);
            });
        }
        //When you supply buyOrderPrice as 10001 (as per the specification, maximum is 10000),
        //it should throw ArgumentException.
        [Fact]
        public void BuyOrderRequest_PriceIsGreaterThanMaximum()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 10001, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(request);
            });
        }

        //When you supply stock symbol=null (as per the specification, stock symbol can't be null),
        //it should throw ArgumentException.

        [Fact]
        public void BuyOrderRequest_StockSymbolIsNull()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockSymbol = null, StockName = "Microsoft", Price = 56, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(request);
            });
        }

        //When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD) - (as per the specification, it should be equal or newer date than 2000-01-01),
        //it should throw ArgumentException.
        [Fact]
        public void BuyOrderRequest_Age_ShouldNotBeOlderThanMaxAge()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockSymbol = "MSFT",DateAndTimeOfOrder =Convert.ToDateTime("1999-12-31"), StockName = "Microsoft", Price = 56, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(request);
            });
        }

        //If you supply all valid values, it should be successful and return an object of BuyOrderResponse type with auto-generated BuyOrderID (guid).
        [Fact]
        public void BuyOrderRequest_ValidRequest()
        {
            //Arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockSymbol = "MSFT", DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"), StockName = "Microsoft", Price = 56, Quantity = 500 };
            //Act
            BuyOrderResponse response = _stocksService.CreateBuyOrder(request);
            //Assert
            Assert.NotEqual(Guid.Empty, response.BuyOrderID);
        }

        #endregion

        #region CreateSellOrder
        //When you supply SellOrderRequest as null, it should throw ArgumentNullException.
        [Fact]
        public void CreateSellOrder_NullArgument()
        {
            //Arrange
            SellOrderRequest? request = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _stocksService.CreateSellOrder(request);
            });
        }
        //When you supply sellOrderQuantity as 0 (as per the specification, minimum is 1),
        //it should throw ArgumentException.
        [Fact]
        public void CreateSellOrder_Zero_Quantity()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 0 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(request);
            });
        }
        //When you supply sellOrderQuantity as 100001 (as per the specification, maximum is 100000),
        //it should throw ArgumentException.
        [Fact]
        public void CreateSellOrder_QuantityIsGreaterThanMaximum()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 100001 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(request);
            });
        }

        //When you supply sellOrderPrice as 0 (as per the specification, minimum is 1),
        //it should throw ArgumentException.
        [Fact]
        public void CreateSellOrder_Zero_Price()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 0, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(request);
            });
        }

        //When you supply sellOrderPrice as 10001 (as per the specification, maximum is 10000),
        //it should throw ArgumentException
        [Fact]
        public void CreateSellOrder_PriceIsGreaterThanMaximum()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 10001, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(request);
            });
        }
        //When you supply stock symbol=null (as per the specification, stock symbol can't be null),
        //it should throw ArgumentException.
        [Fact]
        public void CreateSellOrder_NullStockSymbol()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest() { StockSymbol = null, StockName = "Microsoft", Price = 56, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(request);
            });
        }

        //When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD)
        //(as per the specification, it should be equal or newer date than 2000-01-01), it should throw ArgumentException.
        [Fact]
        public void CreateSellOrder_AgeIsOlderThanMaximumAge()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest() { StockSymbol = "MSFT", DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"), StockName = "Microsoft", Price = 56, Quantity = 500 };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateSellOrder(request);
            });
        }

        //If you supply all valid values, it should be successful and return an object of SellOrderResponse
        //type with auto-generated SellOrderID (guid).
        [Fact]
        public void CreateSellOrder_ValidRequest()
        {
            //Arrange
            SellOrderRequest request = new SellOrderRequest() { StockSymbol = "MSFT", DateAndTimeOfOrder = Convert.ToDateTime("2024-01-23"), StockName = "Microsoft", Price = 56, Quantity = 500 };
            //Act
            SellOrderResponse sellOrderResponse = _stocksService.CreateSellOrder(request);
            //Assert
            Assert.NotEqual(Guid.Empty, sellOrderResponse.SellOrderID);
        }
        #endregion

        #region GetBuyOrders

        //When you invoke this method, by default, the returned list should be empty.
        [Fact]
        public void GetBuyOrders_InvokeByDefault_EmptyList()
        {
            //Act
            List<BuyOrderResponse> buyOrderFromGet = _stocksService.GetBuyOrders();
            //Assert
            Assert.Empty(buyOrderFromGet);

        }

        //When you first add few buy orders using CreateBuyOrder() method; and then invoke GetAllBuyOrders() method;
        //the returned list should contain all the same buy orders.
        [Fact]
        public void GetBuyOrder_AddFewOrders()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest1 = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 1, DateAndTimeOfOrder = DateTime.Parse("2023-01-01 9:00") };
            BuyOrderRequest buyOrderRequest2 = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 1, DateAndTimeOfOrder = DateTime.Parse("2023-01-01 9:00") };
            List<BuyOrderRequest> buyOrderRequests = new List<BuyOrderRequest> { buyOrderRequest1, buyOrderRequest2 };
            List<BuyOrderResponse> buyOrderResponses_from_add = new List<BuyOrderResponse>();
            foreach (BuyOrderRequest buyOrderRequest in buyOrderRequests)
            {
                BuyOrderResponse response_from_add = _stocksService.CreateBuyOrder(buyOrderRequest);
                buyOrderResponses_from_add.Add(response_from_add);
            }
            //Act
            List<BuyOrderResponse> buyOrderResponses_from_Get = _stocksService.GetBuyOrders();
            //Assert
            foreach (BuyOrderResponse buyOrderResponse in buyOrderResponses_from_add)
            {
                Assert.Contains(buyOrderResponse, buyOrderResponses_from_Get);
            }
        }

        #endregion

        #region GetSellOrders
        //When you invoke this method, by default, the returned list should be empty
        [Fact]
        public void GetSellOrders_InvokeByDefault_EmptyList()
        {
            //Act
            List<SellOrderResponse> sellOrderResponses = _stocksService.GetSellOrders();
            //Assert
            Assert.Empty(sellOrderResponses);
        }
        //When you first add few sell orders using CreateSellOrder() method; and then invoke GetAllSellOrders() method;
        //the returned list should contain all the same sell orders.
        [Fact]
        public void GetSellOrders_AddFewOrders()
        {
            //Arrange
            SellOrderRequest sellOrderRequest1 = new SellOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 1, DateAndTimeOfOrder = DateTime.Parse("2023-01-01 9:00") };
            SellOrderRequest sellOrderRequest2 = new SellOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = 1, DateAndTimeOfOrder = DateTime.Parse("2023-01-01 9:00") };
            List<SellOrderRequest> sellOrderRequests = new List<SellOrderRequest> { sellOrderRequest1, sellOrderRequest2 };
            List<SellOrderResponse> sellOrderResponses_from_Add = new List<SellOrderResponse>();
            foreach (SellOrderRequest sellOrderRequest in sellOrderRequests)
            {
                SellOrderResponse response_from_add = _stocksService.CreateSellOrder(sellOrderRequest);
                sellOrderResponses_from_Add.Add(response_from_add);
            }
            //Act
            List<SellOrderResponse> sellOrderResponses_from_Get = _stocksService.GetSellOrders();
            foreach (SellOrderResponse response_from_add in sellOrderResponses_from_Add)
            {
                //Assert
                Assert.Contains(response_from_add, sellOrderResponses_from_Get);
            }
        }
        #endregion
    }
}