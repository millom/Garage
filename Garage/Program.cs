using Garage.Garage;
using Garage.Vehicles;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

//var test = config.GetSection("garage:size").Value;
//var test = config.GetSection("garage:size").GetChildren();
//Console.WriteLine();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IGarage<IVehicle>, Garage<IVehicle>>();
        services.AddSingleton<IConfiguration>(config);
    })
    .UseConsoleLifetime()
    .Build();

host.Services.GetRequiredService<IGarage<IVehicle>>(); //.Runt()