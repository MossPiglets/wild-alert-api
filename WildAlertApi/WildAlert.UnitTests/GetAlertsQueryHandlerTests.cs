using FluentAssertions;
using MapsterMapper;
using WildAlert.Application.Requests.Alerts.Queries.GetAlerts;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alerts;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class GetAlertsQueryHandlerTests
{
    private ApplicationDbContext _context = null!;
    private IMapper _mapper = null!;
    private readonly double _oneKilometerInDegrees = 0.008;
    
    [SetUp]
    public void Setup()
    {
        _context = ApplicationDbContextFactory.Create();
        _mapper = new Mapper();
        
        // Add alert examples
        var alerts = new List<AlertEntity>()
        {
            new() {Latitude = 50, Longitude = 20, Comments = "the center"},
            new() {Latitude = 50+2*_oneKilometerInDegrees, Longitude = 20, Comments = "2 km north from the center"},
            new() {Latitude = 50, Longitude = 20-5*_oneKilometerInDegrees, Comments = "5 km west from the center"},
            new() {Latitude = 50-10*_oneKilometerInDegrees, Longitude = 20, Comments = "10km south from the center"},
            new() {Latitude = 50, Longitude = 20+25*_oneKilometerInDegrees, Comments = "25km east from the center"}
        };
        _context.Alerts.AddRange(alerts);
        _context.SaveChanges();
    }

    [TestCase(20, null)]
    [TestCase(null, 50)]
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
    
    [TestCase(20, 50, 3)]
    [TestCase(20, 50, 6)]
    [TestCase(20, 50, 16)]
    [TestCase(20, 50, 26)]
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
        var radiusInDegrees = radius * 0.008;
        // Act
        var result = await sut.Handle(query, CancellationToken.None);
        // Assert
        result.Should().OnlyContain(dto => 
            dto.Latitude < (latitude + radiusInDegrees) && dto.Latitude > (latitude - radiusInDegrees) &&
            dto.Longitude < (longitude + radiusInDegrees) && dto.Longitude > (longitude - radiusInDegrees));
    }

}