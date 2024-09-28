using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProgrammingAssignment.Api.Controllers;
using ProgrammingAssignment.Application.Makelaars;
using Refit;

namespace ProgrammingAssignment.Api.Tests.Unit;

public class MakelaarControllerTests
{
    private readonly MakelaarController _controller;
    private readonly IMakelaarService _mockMakelaarService;

    public MakelaarControllerTests()
    {
        _mockMakelaarService = Substitute.For<IMakelaarService>();
        _controller = new MakelaarController(_mockMakelaarService);
    }

    [Fact]
    public async Task ProcessMakelaarsTopListAsync_ReturnsOk_WhenServiceReturnsTopList()
    {
        // Arrange
        var place = "Amsterdam";
        var expectedTopList = new List<MakelaarDto>
            { new() { FundaId = 1234, Naam = "Makelaar1" }, new() { FundaId = 4321, Naam = "Makelaar2" } };
        _mockMakelaarService.ProcessMakelaarsTopListAsync(place).Returns(expectedTopList);

        // Act
        var result = await _controller.ProcessMakelaarsTopListAsync(place);

        // Assert
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult?.StatusCode.Should().Be(200);
        okResult?.Value.Should().Be(expectedTopList);
    }

    [Fact]
    public async Task ProcessMakelaarsTopListAsync_ReturnsNotFound_WhenApiExceptionWithNotFoundIsThrown()
    {
        // Arrange
        var place = "NonExistentPlace";
        var apiException = await ApiException.Create(
            new HttpRequestMessage(HttpMethod.Get, "http://localhost"),
            HttpMethod.Get,
            new HttpResponseMessage(HttpStatusCode.NotFound),
            new RefitSettings());

        _mockMakelaarService.ProcessMakelaarsTopListAsync(place).Throws(apiException);

        // Act
        var result = await _controller.ProcessMakelaarsTopListAsync(place);

        // Assert
        var notFoundResult = result as NotFoundObjectResult;
        notFoundResult.Should().NotBeNull();
        notFoundResult?.StatusCode.Should().Be(404);
        notFoundResult?.Value.Should().BeEquivalentTo(new { message = "Geen woningen gevonden voor deze locatie." });
    }

    [Fact]
    public async Task ProcessMakelaarsTopListAsync_ReturnsTooManyRequests_WhenApiExceptionWithTooManyRequestsIsThrown()
    {
        // Arrange
        var place = "Amsterdam";
        var apiException = await ApiException.Create(
            new HttpRequestMessage(HttpMethod.Get, "http://localhost"),
            HttpMethod.Get,
            new HttpResponseMessage(HttpStatusCode.TooManyRequests),
            new RefitSettings());
        _mockMakelaarService.ProcessMakelaarsTopListAsync(place).Throws(apiException);

        // Act
        var result = await _controller.ProcessMakelaarsTopListAsync(place);

        // Assert
        var tooManyRequestsResult = result as ObjectResult;
        tooManyRequestsResult.Should().NotBeNull();
        tooManyRequestsResult?.StatusCode.Should().Be(429);
        tooManyRequestsResult?.Value.Should()
            .BeEquivalentTo(new { message = "Te veel aanvragen. Probeer het later opnieuw." });
    }

    [Fact]
    public async Task
        ProcessMakelaarsTopListAsync_ReturnsInternalServerError_WhenApiExceptionWithOtherStatusCodeIsThrown()
    {
        // Arrange
        var place = "Amsterdam";
        var apiException = await ApiException.Create(
            new HttpRequestMessage(HttpMethod.Get, "http://localhost"),
            HttpMethod.Get,
            new HttpResponseMessage(HttpStatusCode.BadRequest),
            new RefitSettings());
        _mockMakelaarService.ProcessMakelaarsTopListAsync(place).Throws(apiException);

        // Act
        var result = await _controller.ProcessMakelaarsTopListAsync(place);

        // Assert
        var internalServerErrorResult = result as ObjectResult;
        internalServerErrorResult.Should().NotBeNull();
        internalServerErrorResult?.StatusCode.Should().Be(500);
        internalServerErrorResult?.Value.Should()
            .BeEquivalentTo(new { message = "Er ging iets mis bij het ophalen van de woningen." });
    }

    [Fact]
    public async Task ProcessMakelaarsTopListAsync_ReturnsInternalServerError_WhenUnexpectedExceptionIsThrown()
    {
        // Arrange
        var place = "Amsterdam";
        var exceptionMessage = "Unexpected error!";
        _mockMakelaarService.ProcessMakelaarsTopListAsync(place).Throws(new Exception(exceptionMessage));

        // Act
        var result = await _controller.ProcessMakelaarsTopListAsync(place);

        // Assert
        var internalServerErrorResult = result as ObjectResult;
        internalServerErrorResult.Should().NotBeNull();
        internalServerErrorResult?.StatusCode.Should().Be(500);
        internalServerErrorResult?.Value.Should().BeEquivalentTo(new
            { message = $"Er is een interne fout opgetreden: {exceptionMessage}." });
    }
}