using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact] //Xunit 檢測是否要測試的屬性
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes, mocks
            var pingService = new NetworkService();

            //Act
            var result = pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent Success!");
            result.Should().Contain("Success", Exactly.Twice());
        }
        [Theory] //可以使用inline data傳入變數，就可以變測試多個情境
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange - variables, classes, mocks
            var pingService = new NetworkService();

            //Act
            var result = pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(10000, 0);
        }
    }
}
