using Garage.Garage;
using Garage.Manager;
using Garage.Types;
using Garage.UI;
using Garage.Vehicles;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Text.Json;

using static System.Runtime.InteropServices.JavaScript.JSType;

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var garageSize = int.Parse(config.GetSection("garage:size").Value);
var vehicleDataFilename = config.GetSection("garage:vehicle_filename").Value;
//public void LoadJson()
//{
List<Vehicle> vehicles;
using (StreamReader r = new StreamReader(vehicleDataFilename))
{
    string json = r.ReadToEnd();
    //List<Vehicle> items = JsonConvert.DeserializeObject<List<Item>>(json);
    vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json).ToList();
}
//}

//IVehicle[] list =
//[
//    new Car(regNumber: "ABC123", color: ColorType.BLUE, weels: 4, fueltype: FuelType.ELECTRICITY),
//    new Car(regNumber: "ABC234", color: ColorType.YELLOW, weels: 4, fueltype: FuelType.ELECTRICITY),
//    new Car(regNumber: "ABC345", color: ColorType.RED, weels: 4, fueltype: FuelType.GASOLINE),
//    new Car(regNumber: "ABC456", color: ColorType.GREEN, weels: 4, fueltype: FuelType.GASOLINE),
//    new Car(regNumber: "ABC567", color: ColorType.WHITE, weels: 4, fueltype: FuelType.DIESEL),
//    new Boat(regNumber: "BCD123", color: ColorType.BLUE, weels: 0, length: 12),
//    new Boat(regNumber: "BCD234", color: ColorType.YELLOW, weels: 0, length: 22),
//    new Boat(regNumber: "BCD345", color: ColorType.RED, weels: 0, length: 9),
//    new Boat(regNumber: "BCD456", color: ColorType.GREEN, weels: 0, length: 10),
//    new Boat(regNumber: "BCD567", color: ColorType.WHITE, weels: 0, length: 12),
//    new Airplane(regNumber: "CDE123", color: ColorType.BLUE, weels: 8, engines: 2),
//    new Airplane(regNumber: "CDE234", color: ColorType.YELLOW, weels: 12, engines: 4),
//    new Airplane(regNumber: "CDE345", color: ColorType.RED, weels: 12, engines: 2),
//    new Airplane(regNumber: "CDE456", color: ColorType.GREEN, weels: 8, engines: 4),
//    new Airplane(regNumber: "CDE567", color: ColorType.WHITE, weels: 4, engines: 2),
//    new Bus(regNumber: "DEF123", color: ColorType.BLUE, weels: 6, seats: 25),
//    new Bus(regNumber: "DEF234", color: ColorType.YELLOW, weels: 6, seats: 22),
//    new Bus(regNumber: "DEF345", color: ColorType.RED, weels: 8, seats: 25),
//    new Bus(regNumber: "DEF456", color: ColorType.GREEN, weels: 8, seats: 15),
//    new Bus(regNumber: "DEF567", color: ColorType.WHITE, weels: 8, seats: 15),
//    new Motorcycle(regNumber: "EFG123", color: ColorType.BLUE, weels: 2, cylinderVolume: 120),
//    new Motorcycle(regNumber: "EFG234", color: ColorType.YELLOW, weels: 2, cylinderVolume: 110),
//    new Motorcycle(regNumber: "EFG345", color: ColorType.RED, weels: 2, cylinderVolume: 100),
//    new Motorcycle(regNumber: "EFG456", color: ColorType.GREEN, weels: 2, cylinderVolume: 120),
//    new Motorcycle(regNumber: "EFG567", color: ColorType.WHITE, weels: 2, cylinderVolume: 120)
//];

//JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }

//var vehicleJson = JsonSerializer.Serialize<object[]>(
//    list,
//    //(object[])list,
//    //list.GetType(),
//    new JsonSerializerOptions(JsonSerializerDefaults.General)
//    {
//        WriteIndented = true
//    }
//);
//Console.WriteLine(vehicleJson);

//foreach (var vehicle in vehicleJson)
//    Console.WriteLine(vehicle);

//File.WriteAllText(@"all_vehicles.json", vehicleJson);

//var deserialized = JsonSerializer.Deserialize<List<Vehicle?>>(vehicleJson).ToArray();
//var deserialized = JsonSerializer.Deserialize<List<Vehicle>>(vehicleJson).ToArray();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IManager, Manager>();
        services.AddSingleton<IGarageHandler, GarageHandler>();
        services.AddSingleton<IGarage<IVehicle>, Garage<IVehicle>>();
        services.AddSingleton<IUI, ConsoleUI>();
        //services.AddSingleton<IVehicle[]>(new Vehicle[garageSize]);
        //services.AddSingleton<IVehicle[]>(deserialized);
        //services.AddSingleton<IVehicle[]>(vehicles);
        services.AddSingleton<IEnumerable<IVehicle>>(vehicles);
        services.AddSingleton<IVehicle[]>(new Vehicle[garageSize]);
        //services.AddSingleton<IVehicle[]>(new IVehicle[garageSize]);
        //services.AddSingleton<IVehicle[]>(deserialized);
        services.AddSingleton<IDictionary<string, int>>(new Dictionary<string, int>());
        services.AddSingleton<ISearchFilter, SearchFilter>();
    })
    .UseConsoleLifetime()
    .Build();

host.Services.GetRequiredService<IManager>().Run();