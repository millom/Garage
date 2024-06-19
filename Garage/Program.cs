// Uncomment next line to create a new new Json Vehicle file
//#define CREATE_NEW_JSON_FILE

//using Serilog;
using Garage.Garage;
using Garage.Log;
using Garage.Manager;
using Garage.SearchFilter;

#if CREATE_NEW_JSON_FILE
using Garage.Types;
#endif

using Garage.UI;
using Garage.Utils;
using Garage.Vehicles;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;


//using Serilog;
using Serilog.Formatting.Compact;

using System.Text.Json;


#if CREATE_NEW_JSON_FILE
// Read instructions inside this function
CreateNewJsonFile();
#endif

IConfiguration? config = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

int garageSize = config.GetValue<int>("garage:size");

string? vehicleDataFilename = config.GetValue<string>("garage:vehicle_filename");

if (vehicleDataFilename is null)
    return;

IList<IVehicle>? vehicles = JsonHandler.GetVehicleList(vehicleDataFilename);
if (vehicles is null) return;

////Create Logger
////Log.Logger = new LoggerConfiguration()
////ILogger<IManager>
Log.Logger = new LoggerConfiguration()
    //.ReadFrom.Configuration(config.GetSection("Logging"))
    //.ReadFrom.Configuration(config.GetSection("Serilog"))
    //.ReadFrom.Configuration(config.GetSection("Serilog2"))
    .ReadFrom.Configuration(config)
    .CreateLogger();
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File(new CompactJsonFormatter(), "..\\..\\..\\LogFiles\\log.txt")
//    .CreateLogger();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IManager, Manager>();
        services.AddSingleton<IGarageHandler, GarageHandler>();
        services.AddSingleton<IGarage<IVehicle>, Garage<IVehicle>>();
        services.AddSingleton<IUI, ConsoleUI>();
        services.AddSingleton<IMyLogger, ListLogger>();
        //services.AddSingleton<ILogger>();
        services.AddSingleton<Serilog.ILogger>(Log.Logger);
        //services.AddSingleton<ILogger<IManager>>(Logger);
        //services.AddLogging AddSingleton<ILogger<IManager>>(Logger);
        //services.AddLogging(loggingBuilder =>
        //{
        //    //loggingBuilder.AddSerilog(Log.Logger, true);
        //    loggingBuilder.AddConsole(Log.Logger, true);
        //});
        services.AddSingleton<IList<IVehicle>>(vehicles);
        services.AddSingleton<IList<string>>(new List<string>());
        services.AddSingleton<IVehicle[]>(new Vehicle[garageSize]);
        services.AddSingleton<IDictionary<string, int>>(new Dictionary<string, int>());
        services.AddSingleton<ISearchFilter, SearchFilter>();
        //Logger Initialization
        //services.AddLogging(loggingBuilder =>
        //{
        //    //loggingBuilder.AddSerilog(Log.Logger, true);
        //    loggingBuilder.AddConsole(Log.Logger, true);
        //});
    })
    .UseConsoleLifetime()
    .Build();

host.Services.GetRequiredService<IManager>().Run();

#if CREATE_NEW_JSON_FILE

JsonHandler.CreateNewJsonFile(@"all_vehicles.json");

#endif