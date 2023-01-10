using FluentAssertions;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WildAlert.Application.Requests.Alerts.Queries.GetQuery;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alert;

namespace WildAlert.UnitTests;

public class GetAlertsQueryHandlerTests
{
    private ApplicationDbContext _context = null!;
    private IMapper _mapper = null!;
    
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        _context = new ApplicationDbContext(options);
        _mapper = new Mapper();
        
        // Add alert examples
        var alerts = new List<AlertEntity>()
        {
            new() {Latitude = 50.06169712305333, Longitude = 19.937262672461046, Comments = "the center"},
            new() {Latitude = 50.07769712305333, Longitude = 19.937262672461046, Comments = "2 km north from the center"},
            new() {Latitude = 50.06169712305333, Longitude = 19.977262672461046, Comments = "5 km west from the center"},
            new() {Latitude = 49.90169712305333, Longitude = 19.937262672461046, Comments = "10km south from the center"},
            new() {Latitude = 50.06169712305333, Longitude = 20.137262672461046, Comments = "25km east from the center"}
        };
        _context.Alerts.AddRange(alerts);
        _context.SaveChanges();
    }

    [TestCase(20.02, null)]
    [TestCase(null, 50.05)]
    [TestCase(null, null)]
    [Test]
    public async Task Handle_WhenNoLongitudeOrLatitudeGiven_ShouldReturnAllAlerts(double? longitude, double? latitude)
    {
        // Arrange
        var sut = new GetAlertsQueryHandler(_context, _mapper);
        var query = new GetAlertsQuery()
        {
            Longitude = longitude,
            Latitude = latitude
        };
        // Act
        var result = await sut.Handle(query, CancellationToken.None);
        // Assert
        result.Should().BeEquivalentTo(_context.Alerts);
    }
    
    [TestCase(19.937262672461046, 50.06169712305333, 3)]
    [TestCase(19.937262672461046, 50.06169712305333, 6)]
    [TestCase(19.937262672461046, 50.06169712305333, 16)]
    [TestCase(19.937262672461046, 50.06169712305333, 26)]
    [Test]
    public async Task Handle_WhenLongitudeAndLatitudeIsGiven_ShouldReturnAlertsInRadius(double longitude, double latitude, double radius)
    {
        // Arrange
        var sut = new GetAlertsQueryHandler(_context, _mapper);
        var query = new GetAlertsQuery()
        {
            Longitude = longitude,
            Latitude = latitude,
            Radius = radius
        };
        // Act
        var result = await sut.Handle(query, CancellationToken.None);
        // Assert
        //TODO: fix assert
        var radiusDegree = radius * 0.008;

        result.Should().OnlyContain(dto => 
            dto.Latitude < latitude + radiusDegree && dto.Latitude > latitude - radiusDegree &&
            dto.Longitude < latitude - radiusDegree && dto.Latitude > latitude + radiusDegree);
    }

}