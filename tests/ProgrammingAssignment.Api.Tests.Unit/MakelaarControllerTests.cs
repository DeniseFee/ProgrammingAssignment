using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProgrammingAssignment.Api.Controllers;
using ProgrammingAssignment.Application.Makelaars;
using ProgrammingAssignment.Domain.Makelaar;

namespace ProgrammingAssignment.Api.Tests.Unit
{
    public class MakelaarControllerTests
    {
        private readonly IMakelaarService _makelaarService;
        private readonly MakelaarController _controller;

        public MakelaarControllerTests()
        {
            _makelaarService = Substitute.For<IMakelaarService>();
            _controller = new MakelaarController(_makelaarService);
        }

        [Fact]
        public async void ProcessMakelaarsTopListAsync_WithValidList_ReturnsOkResult()
        {
            // Arrange
            var makelaarDtoList = new List<Makelaar>
            {
                new() { FundaId = 1, Naam= "Makelaar1" },
                new() { FundaId = 2, Naam = "Makelaar2" }
            };

            _makelaarService.ProcessMakelaarsTopListAsync().Returns(Task.FromResult(makelaarDtoList));

            // Act
            var result = await _controller.ProcessMakelaarsTopListAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(makelaarDtoList, okResult.Value);
        }

        [Fact]
        public async Task ProcessMakelaarsTopListAsync_WithNullTopList_ReturnsOkResult()
        {
            // Arrange
            _makelaarService.ProcessMakelaarsTopListAsync().Returns(Task.FromResult<List<Makelaar>>(null));

            // Act
            var result = await _controller.ProcessMakelaarsTopListAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Null(okResult.Value);
        }

        [Fact]
        public async void ProcessMakelaarsTopListAsync_WithException_ThrowsNotImplementedException()
        {
            // Arrange
            _makelaarService.ProcessMakelaarsTopListAsync().Throws(new Exception("Service error"));

            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _controller.ProcessMakelaarsTopListAsync());
        }
    }
}