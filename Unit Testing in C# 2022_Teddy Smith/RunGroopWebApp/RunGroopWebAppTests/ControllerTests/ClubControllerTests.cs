using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Controllers;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RunGroopWebAppTests.ControllerTests
{
    public class ClubControllerTests
    {
        private ClubController _clubController;
        private IClubRepository _clubRepository;
        private IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClubControllerTests()
        {
            //First step, mock the dependencies
            //static functions are not be able to test
            _clubRepository = A.Fake<IClubRepository>();
            _photoService = A.Fake<IPhotoService>();
            //HttpContextAccessor是其他套件的，在這裡算是特例? HttpContextAccessor算是靜態的，應該是難以模擬測試或會花很多時間模擬之類的原因，靜態功能不建議Mock，像是ClubController的Create用了HttpContextAccessor，就不建議做單元測試
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //SUT ex:controller
            //Mock DI
            _clubController = new ClubController(_clubRepository, _photoService, _httpContextAccessor);

        }
        [Fact]
        public void ClubController_Index_ReturnSuccess()
        {
            //Arrange - What do i need to bring in?
            IEnumerable<Club> clubs = A.Fake<IEnumerable<Club>>();
            //Mock the function
            A.CallTo(()=> _clubRepository.GetAll()).Returns(clubs);

            //Act
            var result = _clubController.Index();

            //Assert - Object check actions
            //In this way only check type, can be more strict, ex: assert viewmodel and it's value
            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Fact]
        public void ClubController_Detail_ReturnSuccess()
        {
            //Arrange - What do i need to bring in?
            var id = 1;
            Club club = A.Fake<Club>();
            //Mock the function
            A.CallTo(() => _clubRepository.GetByIdAsync(id)).Returns(club);

            //Act
            var result = _clubController.Detail(id);

            //Assert - Object check actions
            //In this way only check type, can be more strict
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
