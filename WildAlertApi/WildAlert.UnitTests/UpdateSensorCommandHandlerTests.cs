using FluentAssertions;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class UpdateSensorCommandHandlerTests
{
    private ApplicationDbContext _context = null!;
    private IMapper _mapper = null!;
    
    [SetUp]
    public void Setup()
    {
        _context = ApplicationDbContextFactory.Create();
        _mapper = new Mapper();

        _context.Sensors.Add(new SensorEntity {Latitude = 50, Longitude = 10, Name = "not updated sensor"});
        _context.SaveChanges();
    }

    [Test]
    public async Task Handle_ShouldUpdateAndReturnAlert()
    {
        // Arrange
        var sut = new UpdateSensorCommandHandler(_context, _mapper);
        var id = (await _context.Sensors.FirstAsync()).Id;
        var command = new UpdateSensorCommand
        {
            Id = id,
            Longitude = 20,
            Latitude = 30,
            Name = "updated sensor",
        };
        // Act
        var result = await sut.Handle(command, CancellationToken.None);
        // Assert
        var updatedSensor = await _context.Sensors.FirstOrDefaultAsync(x => x.Id == command.Id);
        updatedSensor.Should().BeEquivalentTo(command);
        result.Longitude.Should().Be(command.Longitude);
        result.Latitude.Should().Be(command.Latitude);
        result.Name.Should().Be(command.Name);
        result.Id.Should().NotBeEmpty();
    }
}