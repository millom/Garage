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

IList<IVehicle>? vehicles = GetVehicleList(vehicleDataFilename);
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

#region needed_functiones

static IList<IVehicle>? GetVehicleList(string vehicleDataFilename)
{
    List<Vehicle>? jsonList;
    using (StreamReader r = new(vehicleDataFilename))
    {
        string json = r.ReadToEnd();
        jsonList = JsonSerializer.Deserialize<List<Vehicle>>(json)?.ToList();
    }
    if (jsonList is null) return null;

    return new List<IVehicle>(jsonList);
}

#endregion

#if CREATE_NEW_JSON_FILE

static void CreateNewJsonFile()
{
    /**
     * Set filename
     */
    string jsonFilename = @"all_vehicles.json";

    /**
     * Creste vehicle data in this function 
     */
    IVehicle[] list = CreateVehicleArray();

    /**
     * Create Json file
     */
    CreateVehicleJsonFileFromList(jsonFilename, list);
}

static IVehicle[] CreateVehicleArray()
{
    return [
        new Car(regNumber: "ABC123", color: ColorType.BLUE, weels: 4, fueltype: FuelType.ELECTRICITY),
        new Car(regNumber: "ABC234", color: ColorType.YELLOW, weels: 4, fueltype: FuelType.ELECTRICITY),
        new Car(regNumber: "ABC345", color: ColorType.RED, weels: 4, fueltype: FuelType.GASOLINE),
        new Car(regNumber: "ABC456", color: ColorType.GREEN, weels: 4, fueltype: FuelType.GASOLINE),
        new Car(regNumber: "ABC567", color: ColorType.WHITE, weels: 4, fueltype: FuelType.DIESEL),
        new Boat(regNumber: "BCD123", color: ColorType.BLUE, weels: 0, length: 12),
        new Boat(regNumber: "BCD234", color: ColorType.YELLOW, weels: 0, length: 22),
        new Boat(regNumber: "BCD345", color: ColorType.RED, weels: 0, length: 9),
        new Boat(regNumber: "BCD456", color: ColorType.GREEN, weels: 0, length: 10),
        new Boat(regNumber: "BCD567", color: ColorType.WHITE, weels: 0, length: 12),
        new Airplane(regNumber: "CDE123", color: ColorType.BLUE, weels: 8, engines: 2),
        new Airplane(regNumber: "CDE234", color: ColorType.YELLOW, weels: 12, engines: 4),
        new Airplane(regNumber: "CDE345", color: ColorType.RED, weels: 12, engines: 2),
        new Airplane(regNumber: "CDE456", color: ColorType.GREEN, weels: 8, engines: 4),
        new Airplane(regNumber: "CDE567", color: ColorType.WHITE, weels: 4, engines: 2),
        new Bus(regNumber: "DEF123", color: ColorType.BLUE, weels: 6, seats: 25),
        new Bus(regNumber: "DEF234", color: ColorType.YELLOW, weels: 6, seats: 22),
        new Bus(regNumber: "DEF345", color: ColorType.RED, weels: 8, seats: 25),
        new Bus(regNumber: "DEF456", color: ColorType.GREEN, weels: 8, seats: 15),
        new Bus(regNumber: "DEF567", color: ColorType.WHITE, weels: 8, seats: 15),
        new Motorcycle(regNumber: "EFG123", color: ColorType.BLUE, weels: 2, cylinderVolume: 120),
        new Motorcycle(regNumber: "EFG234", color: ColorType.YELLOW, weels: 2, cylinderVolume: 110),
        new Motorcycle(regNumber: "EFG345", color: ColorType.RED, weels: 2, cylinderVolume: 100),
        new Motorcycle(regNumber: "EFG456", color: ColorType.GREEN, weels: 2, cylinderVolume: 120),
        new Motorcycle(regNumber: "EFG567", color: ColorType.WHITE, weels: 2, cylinderVolume: 120)
    ];
}

static string JsonSerialize(IVehicle[] list)
{
    var vehicleJson = JsonSerializer.Serialize<object[]>(
        value: list,
        options: new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            WriteIndented = true
        }
    );

    return vehicleJson;
}

static void CreateVehicleJsonFileFromList(string jsonFilename, IVehicle[] list)
{
    string vehicleJson = JsonSerialize(list);
    File.WriteAllText(jsonFilename, vehicleJson);
}

#endif