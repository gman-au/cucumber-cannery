using Microsoft.Extensions.DependencyInjection;
using Cucumber.Cannery.Application;
using Cucumber.Cannery.Tool;

var services = 
    Startup
        .AddServices();

var serviceProvider =
    services
        .BuildServiceProvider();

var application = 
    serviceProvider
        .GetRequiredService<ISpecFlowApplication>();

application
    .Perform(args);