using FluentAssertions;
using MapsterMapper;
using WildAlert.Application.Requests.SensorData.Commands.CreateSensorData;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alerts;
using WildAlert.Shared.DateTimeProvider;
using WildAlert.Tests.Shared.DateTimeProvider;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class CreateSensorDataCommandHandlerTests
{
    private ApplicationDbContext _context = null!;
    private IMapper _mapper = null!;
    private IDateTimeProvider _dateTimeProvider = null!;

    [SetUp]
    public void Setup()
    {
        _context = ApplicationDbContextFactory.Create();
        _mapper = new Mapper();
        _dateTimeProvider = new TestDateTimeProvider();
    }

    [Test]
    public async Task Handle_ShouldCreateNewSensorData()
    {
        // Arrange
        var sensorId = new Guid();
        var sut = new CreateSensorDataCommandHandler(_context, _mapper, _dateTimeProvider);
        var command = new CreateSensorDataCommand
        {
            SensorId = sensorId,
            DetectedAt = _dateTimeProvider.UtcNow,
            DetectedAnimal = AnimalType.Unknown
        };
        // Act
        var result = await sut.Handle(command, CancellationToken.None);
        // Assert
        _context.SensorData.Should().NotBeEmpty();
        result.DetectedAnimal.GetType().Should().Be<AnimalType>();
        result.DetectedAt.Should().Be(_dateTimeProvider.UtcNow);
        result.Id.Should().NotBeEmpty();
    }
}