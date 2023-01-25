using FluentAssertions;
using MapsterMapper;
using WildAlert.Application.Requests.Sensors.Queries.GetSensorsQuery;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class GetSensorsQueryHandlerTests
{
    private ApplicationDbContext _context = null!;
    private IMapper _mapper = null!;
    
    [SetUp]
    public void Setup()
    {
        _context = ApplicationDbContextFactory.Create();
        _mapper = new Mapper();
        
        // Add sensor examples
        var sensors = new List<SensorEntity>()
        {
            new() {Latitude = 50, Longitude = 10, Name = "sensor1"},
            new() {Latitude = 40, Longitude = 20, Name = "sensor2"},
            new() {Latitude = 30, Longitude = 30, Name = "sensor3"},
            new() {Latitude = 20, Longitude = 40, Name = "sensor4"},
            new() {Latitude = 10, Longitude = 50, Name = "sensor5"}
        };
        _context.Sensors.AddRange(sensors);
        _context.SaveChanges();
    }
    
    [Test]
    public async Task Handle_ShouldReturnAllSensors()
    {
        // Arrange
        var sut = new GetSensorsQueryHandler(_context, _mapper);
        var query = new GetSensorsQuery();
        // Act
        var result = await sut.Handle(query, CancellationToken.None);
        // Assert
        result.Count().Should().Be(5);
    }
}