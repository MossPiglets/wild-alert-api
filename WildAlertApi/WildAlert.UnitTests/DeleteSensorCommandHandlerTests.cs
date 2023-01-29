using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WildAlert.Application.Requests.Sensors.Commands.DeleteSensor;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class DeleteSensorCommandHandlerTests
{
    private ApplicationDbContext _context = null!;
    
    [SetUp]
    public void Setup()
    {
        _context = ApplicationDbContextFactory.Create();

        _context.Sensors.Add(new SensorEntity {Latitude = 50, Longitude = 10, Name = "test sensor"});
        _context.SaveChanges();
    }

    [Test]
    public async Task Handle_ShouldDeleteSensorById()
    {
        // Arrange
        var sut = new DeleteSensorCommandHandler(_context);
        var id = (await _context.Sensors.FirstAsync()).Id;
        var command = new DeleteSensorCommand
        {
            Id = id
        };
        // Act
        await sut.Handle(command, CancellationToken.None);
        // Assert
        _context.Sensors.Should().NotContain(s => s.Id == id);
    }
}