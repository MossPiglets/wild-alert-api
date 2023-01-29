using FluentAssertions;
using MapsterMapper;
using WildAlert.Application.Requests.Sensors.Commands.CreateSensor;
using WildAlert.Persistence;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class CreateSensorCommandHandlerTests
{
    private ApplicationDbContext _context = null!;
    private IMapper _mapper = null!;
    
    [SetUp]
    public void Setup()
    {
        _context = ApplicationDbContextFactory.Create();
        _mapper = new Mapper();
    }

    [Test]
    public async Task Handle_ShouldCreateNewAlert()
    {
        // Arrange
        var sut = new CreateSensorCommandHandler(_context, _mapper);
        var command = new CreateSensorCommand
        {
            Longitude = 20,
            Latitude = 30,
            Name = "test sensor",
        };
        // Act
        var result = await sut.Handle(command, CancellationToken.None);
        // Assert
        _context.Sensors.Should().NotBeEmpty();
        result.Longitude.Should().Be(command.Longitude);
        result.Latitude.Should().Be(command.Latitude);
        result.Name.Should().Be(command.Name);
        result.Id.Should().NotBeEmpty();
    }
}