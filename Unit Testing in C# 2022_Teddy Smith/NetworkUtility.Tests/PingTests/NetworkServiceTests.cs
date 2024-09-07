using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;
        private readonly IDNS _dNS;
        public NetworkServiceTests()
        {
            //Dependencies ， 不想實際連接到資料庫等，用FakeitEasy取代要注入的Service或Repository -> 想想後應該跟手動做另一物件替代差不多。就是要能動態return資料，可能也跟deligate差不多?
            _dNS = A.Fake<IDNS>(); // A : FakeitEasy Method

            //SUT : System Under Test, 也能是此測試class下大家都會用到的物件?來讓程式碼簡潔
            //Arrange - variables, classes, mocks            
            _networkService = new NetworkService(_dNS); //做作出來的Dependencies來讓SUT能測試，類似幫你動態做個假物件送進去
        }
        [Fact] //Xunit 檢測是否要測試的屬性
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes, mocks
            A.CallTo(()=>_dNS.SendDNS()).Returns(true); //幫假物件設定return值 => 設記測試案例

            //Act
            var result = _networkService.SendPing();

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

            //Act
            var result = _networkService.PingTimeout(a, b);
            
            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(10000, 0);
        }
        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange - variables, classes, mocks

            //Act
            var result = _networkService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }
        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            //Arrange - variables, classes, mocks
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _networkService.GetPingOptions();

            //Assert WARNING: "Be" careful ， 好像就是Be可以比對型別種類、型別相等、值等等各種方面來達成嚴格測試
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected); //BeEquivalentTo : have equally named properties with the same value...
            result.Ttl.Should().Be(1);
        }
        [Fact]
        public void NetworkService_MostRecentPings_ReturnObject()
        {
            //Arrange - variables, classes, mocks
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var result = _networkService.MostRecentPings();

            //Assert WARNING: "Be" careful ， 好像就是Be可以比對型別種類、型別相等、值等等各種方面來達成嚴格測試
            result.Should().BeOfType<PingOptions[]>(); //這會用實作的類別來比，BeOfType可能比不了Interface?
            result.Should().ContainEquivalentOf(expected);// at least contain one object equivalent to another object
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
