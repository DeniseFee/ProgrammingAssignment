using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProgrammingAssignment.Infra.FundaPartnerApi.Client;
using ProgrammingAssignment.Infra.FundaPartnerApi.Koopwoning;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Tests;

public class KoopwoningenServiceTests
{
    private const string ApiKey = "test-api-key";
    private const string TestPlaats = "amsterdam";
    private readonly IFundaPartnerApi _fundaPartnerApiMock;
    private readonly KoopwoningenService _koopwoningenService;

    public KoopwoningenServiceTests()
    {
        _fundaPartnerApiMock = Substitute.For<IFundaPartnerApi>();
        var mockConfiguration = Substitute.For<IConfiguration>();
        mockConfiguration["PartnerApiKey"].Returns(ApiKey);
        var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new KoopwoningenMappingProfile()); });

        var mapper = mappingConfig.CreateMapper();
        _koopwoningenService = new KoopwoningenService(_fundaPartnerApiMock, mockConfiguration, mapper, Substitute.For<ILogger<KoopwoningenService>>());
    }

    [Fact]
    public async Task GetKoopwoningenVoorPlaatsAsync_ReturnsWoningen_ForSinglePage()
    {
        // Arrange
        var woning1 = new ObjectsBuilder().WithMakelaarNaam("Makelaar A").Build();
        var woning2 = new ObjectsBuilder().WithMakelaarNaam("Makelaar B").Build();
        var paging = new PagingBuilder().WithAantalPaginas(1).Build();
        
        var koopwoningenResponse =
            new KoopwoningenResponseBuilder()
                    .WithObjects([woning1, woning2])
                    .WithPaging(paging)
                .Build();
        
        var woningenJson = JsonConvert.SerializeObject(koopwoningenResponse);
        
        _fundaPartnerApiMock.GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>())
            .Returns(Task.FromResult(woningenJson));

        // Act
        var result = await _koopwoningenService.GetKoopwoningenVoorPlaatsAsync(TestPlaats);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].MakelaarNaam.Should().Be("Makelaar A");
        result[1].MakelaarNaam.Should().Be("Makelaar B");

        await _fundaPartnerApiMock.Received(1).GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>());
    }

    [Fact]
    public async Task GetKoopwoningenVoorPlaatsAsync_ReturnsWoningen_ForMultiplePages()
    {
        // Arrange
        var woning1 = new ObjectsBuilder().WithMakelaarNaam("Makelaar A").Build();
        var paging1 = new PagingBuilder().WithAantalPaginas(2).WithHuidigePagina(1).Build();
        var koopwoningenResponse1 =
            new KoopwoningenResponseBuilder()
                .WithObjects([woning1])
                .WithPaging(paging1)
                .Build();
        var woningenJson1 = JsonConvert.SerializeObject(koopwoningenResponse1);
        
        var woning2 = new ObjectsBuilder().WithMakelaarNaam("Makelaar B").Build();
        var paging2 = new PagingBuilder().WithAantalPaginas(2).WithHuidigePagina(2).Build();
        
        var koopwoningenResponse2 =
            new KoopwoningenResponseBuilder()
                .WithObjects([woning2])
                .WithPaging(paging2)
                .Build();
        var woningenJson2 = JsonConvert.SerializeObject(koopwoningenResponse2);

        _fundaPartnerApiMock.GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>())
            .Returns(Task.FromResult(woningenJson1));
        _fundaPartnerApiMock.GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 2, Arg.Any<int>())
            .Returns(Task.FromResult(woningenJson2));

        // Act
        var result = await _koopwoningenService.GetKoopwoningenVoorPlaatsAsync(TestPlaats);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].MakelaarNaam.Should().Be("Makelaar A");
        result[1].MakelaarNaam.Should().Be("Makelaar B");

        await _fundaPartnerApiMock.Received(1).GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>());
        await _fundaPartnerApiMock.Received(1).GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 2, Arg.Any<int>());
    }

    [Fact]
    public async Task GetKoopwoningenVoorPlaatsAsync_WithNoWoningenFound_ReturnsEmptyList()
    {
        // Arrange
        var response = new KoopwoningenResponse
        {
            Objects = [],
            Paging = new Paging
            {
                AantalPaginas = 1
            }
        };

        var emptyJson = JsonConvert.SerializeObject(response);
        _fundaPartnerApiMock.GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>())
            .Returns(Task.FromResult(emptyJson));

        // Act
        var result = await _koopwoningenService.GetKoopwoningenVoorPlaatsAsync(TestPlaats);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
        
        await _fundaPartnerApiMock.Received(1).GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>());
    }

    [Fact]
    public async Task GetKoopwoningenVoorPlaatsAsync_ThrowsException_WhenApiThrowsException()
    {
        // Arrange
        _fundaPartnerApiMock.GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>())
            .Throws(new HttpRequestException("API error"));

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() =>
            _koopwoningenService.GetKoopwoningenVoorPlaatsAsync(TestPlaats));

        await _fundaPartnerApiMock.Received(1).GetKoopwoningenVoorPlaatsAsync(ApiKey, TestPlaats, 1, Arg.Any<int>());
    }
}