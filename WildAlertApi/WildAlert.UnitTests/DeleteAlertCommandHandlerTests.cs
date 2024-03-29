using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WildAlert.Application.Requests.Alerts.Commands.DeleteAlert;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alerts;
using WildAlert.UnitTests.Factories;

namespace WildAlert.UnitTests;

public class DeleteAlertCommandHandlerTests
{
    private ApplicationDbContext _context = null!;
    
    [SetUp]
    public void Setup()
    {
        _context = ApplicationDbContextFactory.Create();

        _context.Alerts.Add(new AlertEntity {Animal = AnimalType.Deer, Latitude = 50, Longitude = 10, Comments = "test alert"});
        _context.SaveChanges();
    }

    [Test]
    public async Task Handle_ShouldDeleteAlertById()
    {
        // Arrange
        var sut = new DeleteAlertCommandHandler(_context);
        var id = (await _context.Alerts.FirstAsync()).Id;
        var command = new DeleteAlertCommand
        {
            Id = id
        };
        // Act
        await sut.Handle(command, CancellationToken.None);
        // Assert
        _context.Alerts.Should().NotContain(s => s.Id == id);
    }
    
    [Test]
    public async Task Handle_WhenGivenIncorrectOrNonExistingId_ShouldThrowException()
    {
        //Arrange
        var sut = new DeleteAlertCommandHandler(_context);
        var command = new DeleteAlertCommand
        {
            Id =  new Guid("BBA8E3C4-3A58-48D7-8A1D-501B6DF84108")
        };
        //Act
        Func<Task> result = () =>sut.Handle(command, CancellationToken.None);
        //Assert
        await result.Should().ThrowAsync<NotFoundException>();
    }
}