using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WildAlert.Application.Extensions;

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(IApplicationMarker));
        
        // Fluent validation
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();
        
        //Mapster
        var config = new TypeAdapterConfig();
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
    }
    
}