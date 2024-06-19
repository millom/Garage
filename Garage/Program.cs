// Uncomment next line to create a new new Json Vehicle file
//#define CREATE_NEW_JSON_FILE

using Garage.Garage;
using Garage.Log;
using Garage.Manager;
using Garage.Search;

using Garage.UI;
using Garage.Utils;
using Garage.Vehicles;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using System.Collections.Generic;

#if CREATE_NEW_JSON_FILE
// Read instructions inside this function
JsonHandler.CreateNewJsonFile(@"all_vehicles.json");
#endif

IConfiguration? config = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

int garageSize = config.GetValue<int>("garage:size");

string? vehicleDataFilename = config.GetValue<string>("garage:vehicle_filename");
if (vehicleDataFilename is null)
    return;

string filename = config.GetValue<string>("garage:save_stage_filename")!;
Manager.SetSaveStageFilename(filename);

IList<Vehicle>? jsonVehicles = JsonHandler.GetVehicleList<Vehicle>(vehicleDataFilename);
if (jsonVehicles is null) return;
IList<IVehicle> vehicles = new List<IVehicle>(jsonVehicles);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IManager, Manager>();
        services.AddSingleton<IGarageHandler, GarageHandler>();
        services.AddSingleton<IGarage<IVehicle>, Garage<IVehicle>>();
        services.AddSingleton<IUI, ConsoleUI>();
        services.AddSingleton<IMyLogger, ListLogger>();
        services.AddSingleton<Serilog.ILogger>(Log.Logger);
        services.AddSingleton<IList<IVehicle>>(vehicles);
        services.AddSingleton<IList<string>>(new List<string>());
        services.AddSingleton<IVehicle[]>(new Vehicle[garageSize]);
        services.AddSingleton<IDictionary<string, int>>(new Dictionary<string, int>());
        services.AddSingleton<ISearchFilter, SearchFilter>();
    })
    .UseConsoleLifetime()
    .Build();

host.Services.GetRequiredService<IManager>().Run();