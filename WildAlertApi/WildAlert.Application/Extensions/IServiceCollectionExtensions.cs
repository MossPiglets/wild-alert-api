using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WildAlert.Application.Extensions;

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(IApplicationMarker).Assembly);
    }
}