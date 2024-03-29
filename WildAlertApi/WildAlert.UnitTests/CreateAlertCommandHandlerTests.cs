using FluentAssertions;
using MapsterMapper;
using WildAlert.Application.Requests.Alerts.Commands.CreateAlert;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alerts;
using WildAlert.Shared.DateTimeProvider;
using WildAlert.Tests.Shared.DateTimeProvider;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class CreateAlertCommandHandlerTests
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
    public async Task Handle_ShouldCreateNewAlert()
    {
        // Arrange
        var sut = new CreateAlertCommandHandler(_context, _mapper, _dateTimeProvider);
        var command = new CreateAlertCommand
        {
            Longitude = 20,
            Latitude = 30,
            Comments = "test comment",
            Animal = AnimalType.Fox
        };
        // Act
        var result = await sut.Handle(command, CancellationToken.None);
        // Assert
        _context.Alerts.Should().NotBeEmpty();
        result.Longitude.Should().Be(command.Longitude);
        result.Latitude.Should().Be(command.Latitude);
        result.Comments.Should().Be(command.Comments);
        result.Animal.Should().Be(command.Animal);
        result.Id.Should().NotBeEmpty();
        result.CreatedAt.Should().Be(_dateTimeProvider.UtcNow);
    }
}