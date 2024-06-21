using Garage.Types;
using Garage.Vehicles;
using System.Text.Json;

namespace Garage.Utils
{
    internal static class JsonHandler
    {
        internal static IList<T>? GetVehicleList<T>(string vehicleDataFilename) where T : class
        {
            List<T>? jsonList;
            using (StreamReader r = new(vehicleDataFilename))
            {
                string json = r.ReadToEnd();
                jsonList = JsonSerializer.Deserialize<List<T>>(json)?.ToList();
            }
            if (jsonList is null) return null;

            return new List<T>(jsonList);
        }

        internal static void CreateNewJsonFile(string jsonFilename)
        {
            IVehicle[] list = CreateVehicleArray();

            CreateVehicleJsonFileFromList(jsonFilename, list);
        }

        internal static IVehicle[] CreateVehicleArray()
        {
            return [
                new Car(regNumber: "ABC123", color: ColorType.BLUE, weels: 4, fueltype: FuelType.ELECTRICITY),
                new Car(regNumber: "ABC234", color: ColorType.YELLOW, weels: 4, fueltype: FuelType.ELECTRICITY),
                new Car(regNumber: "ABC345", color: ColorType.RED, weels: 4, fueltype: FuelType.GASOLINE),
                new Car(regNumber: "ABC456", color: ColorType.GREEN, weels: 4, fueltype: FuelType.GASOLINE),
                new Car(regNumber: "ABC567", color: ColorType.WHITE, weels: 4, fueltype: FuelType.DIESEL),
                new Boat(regNumber: "BCD123", color: ColorType.BLUE, length: 12),
                new Boat(regNumber: "BCD234", color: ColorType.YELLOW, length: 22),
                new Boat(regNumber: "BCD345", color: ColorType.RED, length: 9),
                new Boat(regNumber: "BCD456", color: ColorType.GREEN, length: 10),
                new Boat(regNumber: "BCD567", color: ColorType.WHITE, length: 12),
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

        internal static void CreateVehicleJsonFileFromList<T>(string jsonFilename, T[] list) where T : class
        {
            string vehicleJson = JsonSerialize(list);
            File.WriteAllText(jsonFilename, vehicleJson);
        }

        internal static string JsonSerialize<T>(T[] list) where T: class
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
    }
}
