using Garage.Exceptions;
using Garage.Garage;
using Garage.Log;
using Garage.Search;
using Garage.Types;
using Garage.UI;
using Garage.Utils;
using Garage.Vehicles;

using Serilog;

using System.Reflection;

namespace Garage.Manager
{
    /// <summary>
    /// Main class for handling:
    ///     input from user
    ///     print information
    ///     the garage
    ///     searching
    ///     logging
    /// </summary>
    /// <param name="rw"></param>
    /// <param name="garageHandler"></param>
    /// <param name="searchFilter"></param>
    /// <param name="logger"></param>
    /// <param name="seriLogger"></param>
    internal class Manager(
        IReaderWriter rw,
        IGarageHandler garageHandler,
        ISearchFilter searchFilter,
        IMyLogger logger,
        ILogger seriLogger) : IManager
    {
        private readonly IReaderWriter _rw = rw;
        private readonly IGarageHandler _garageHandler = garageHandler;
        private readonly ISearchFilter _searchFilter = searchFilter;
        private readonly IMyLogger _logger = logger;
        private readonly ILogger _seriLogger = seriLogger;

        // Must be set before starting the program
        private static string? saveFileName;

        /// <summary>
        /// Run the program
        /// </summary>
        public void Run()
        {
            if (saveFileName is null)
            {
                var message = "Manditory field 'saveFileName' not set, exit program";
                _rw.WriteLine(message);
                _seriLogger.Information(message);
                _rw.WriteLine("Press enter to continue");
                _rw.ReadLine();
            }
            while (MainMenu()) ;
        }

        public bool MainMenu()
        {
            _rw.Clear();
            _rw.WriteLine("--- MAIN MENU ---");
            _rw.WriteLine("0: Park vehicle");
            _rw.WriteLine("1: Get parked vehicle");
            _rw.WriteLine("2: Show parked vehicles");
            _rw.WriteLine("3: Show log");
            _rw.WriteLine("4: Save");
            _rw.WriteLine("5: Load");
            _rw.WriteLine("6: Unpark all");
            _rw.WriteLine("9: Exit program");
            _rw.WriteMarker();

            var command = _rw.ReadLine();

            switch (command)
            {
                case "0":
                    while (ParkMenu()) ;
                    break;
                case "1":
                    while (UnparkMenu()) ;
                    break;
                case "2":
                    while (ShowParkedVehiclesMenu()) ;
                    break;
                case "3":
                    ShowLog();
                    break;
                case "4":
                    SaveParked();
                    break;
                case "5":
                    LoadParked();
                    break;
                case "6":
                    EmptyGarage();
                    break;
                default:
                    break;
            }

            return command != "9";
        }

        private void EmptyGarage()
        {
            try
            {
                DoEmptyParked();
                var message = $"Unpark all vehicles";
                _logger.AddToLog(message);
                _rw.WriteLine(message);
                _seriLogger.Information(message);
                _rw.WriteLine("Press enter to continue");
                _rw.ReadLine();
            }
            catch (Exception ex)
            {
                _logger.AddToLog(ex.Message);
                _rw.WriteLine(ex.Message);
                _seriLogger.Error(ex, ex.Message);
                _rw.WriteLine("Press enter to continue");
                _rw.ReadLine();
            }
        }

        private void DoEmptyParked()
        {
            var parked = _garageHandler
                .GetParkedIdxRegNumber()
                .ToArray();
            Throw<NullReferenceException>
                .If(parked is null, "Didn't find any parked vehicles");
            Throw<Exception>
                .If(parked!.Length == 0, "No parked vehicles to save");
            parked
                .ToList()
                .ForEach(v => {
                    Throw<Exception>
                        .If(_garageHandler.GetParkedVehicle(v.Value) is null,
                        $"Unknown error, fail to unpark vehicle {v.Value} at id {v.Id}");
                }
                );
        }

        private void LoadParked()
        {
            try
            {
                DoLoadParked();
                var message = $"Loaded Parked vehicles from file";
                _logger.AddToLog(message);
                _rw.WriteLine(message);
                _seriLogger.Information(message);
                _rw.WriteLine("Press enter to continue");
                _rw.ReadLine();
            }
            catch (Exception ex)
            {
                _logger.AddToLog(ex.Message);
                _rw.WriteLine(ex.Message);
                _seriLogger.Error(ex, ex.Message);
                _rw.WriteLine("Press enter to continue");
                _rw.ReadLine();
            }
        }

        private void DoLoadParked()
        {
            IList<IdValuePair<string>>? jsonMap =
                JsonHandler.GetVehicleList<IdValuePair<string>>(saveFileName!);
            Throw<NullReferenceException>
                .If(jsonMap is null, "No parked vehicles to load");
            Throw<Exception>
                .If(jsonMap!.Count() == 0, "No parked vehicles to load");

            if (jsonMap == null)
            {
                return;
            }
            jsonMap
                .ToList()
                .ForEach(v => {
                    Throw<Exception>
                        .If(_garageHandler.ParkVehicle(v.Value, v.Id) is null,
                        $"Unknown error, can't park vehicle {v.Value} at id {v.Id}");
                    }
                );
        }

        private void SaveParked()
        {
            try
            {
                DoSaveParked();
                var message = $"Saved all Parked vehicles";
                _logger.AddToLog(message);
                _rw.WriteLine(message);
                _seriLogger.Information(message);
                _rw.WriteLine("Press enter to continue");
                _rw.ReadLine();
            }
            catch (Exception ex)
            {
                _logger.AddToLog(ex.Message);
                _rw.WriteLine(ex.Message);
                _seriLogger.Error(ex, ex.Message);
                _rw.WriteLine("Press enter to continue");
                _rw.ReadLine();
            }
        }

        private void DoSaveParked()
        {
            var parked = _garageHandler
                .GetParkedIdxRegNumber()
                .ToArray();
            Throw<NullReferenceException>
                .If(parked is null, "Didn't find any parked vehicles");
            Throw<Exception>
                .If(parked!.Length == 0, "No parked vehicles to save");

            JsonHandler.CreateVehicleJsonFileFromList(saveFileName!, parked);
        }

        private void ShowLog()
        {
            _logger.PrintLog();
            //_ui.WriteSpaceLine();
            _rw.WriteLine("Press enter to continue");
            _rw.ReadLine();
        }

        public bool ParkMenu()
        {
            _rw.Clear();
            _rw.WriteLine("--- PARK VEHICLE MENU ---");
            _rw.WriteSpaceLine();
            _rw.WriteLine("Free parking slots");
            PrintFreeSlots();
            PrintCarsToPark();
            _rw.WriteLine("<regNr, parkingSlot>: Park regNr on parkingSlot : (Ex: ABC123, 0)");
            _rw.WriteLine("9: Exit menu");
            _rw.WriteMarker();

            var command = _rw.ReadLine();
            if (!string.IsNullOrWhiteSpace(command) &&
                command != "9" && command.Contains(", "))
            {
                var commandSplit = command.Split(", ");
                if (commandSplit.Length == 2)
                {
                    try
                    {
                        var regNbr = commandSplit[0];
                        int slotId = int.Parse(commandSplit[1]);
                        var vehicle = _garageHandler.ParkVehicle(regNbr, slotId);

                        _logger.AddToLog($"In slot {slotId}: Parked vehicle <{vehicle}>");
                        _rw.WriteLine($"In slot {slotId}: Parked vehicle <{vehicle}>");
                        _seriLogger.Information($"In slot {slotId}: Parked vehicle <{vehicle}>");
                        _rw.WriteLine("Press enter to continue");
                        _rw.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        _logger.AddToLog(ex.Message);
                        _rw.WriteLine(ex.Message);
                        _seriLogger.Error(ex, ex.Message);
                        _rw.WriteLine("Press enter to continue");
                        _rw.ReadLine();
                    }
                }
            }

            return command != "9";
        }

        private void PrintCarsToPark()
        {
            _rw.WriteSpaceLine();
            _rw.WriteLine("Vehicles to park");
            _garageHandler
                .GetNotParkedVehicles()
                .Where(x => x is not null)
                .ToList()
                .ForEach(x => _rw.WriteLine(x));
            _rw.WriteSpaceLine();
        }

        private void PrintFreeSlots()
        {
            _garageHandler
                .GetEmptyIndexes()
                .ToList()
                .ForEach(id => _rw.Write($"{id} "));
            _rw.WriteLine("");
        }

        public bool UnparkMenu()
        {
            _rw.Clear();
            _rw.WriteLine("--- UNPARK VEHICLE MENU --");
            _rw.WriteSpaceLine();
            PrintParkedCars();
            _rw.WriteSpaceLine();
            _rw.WriteLine("<regNr>: Unpark car Ex: ABC123");
            _rw.WriteLine("9: Exit menu");
            _rw.WriteMarker();

            var command = _rw.ReadLine();

            if (!string.IsNullOrWhiteSpace(command) && command != "9")
            {
                try
                {
                    var vehicle = _garageHandler.GetParkedVehicle(command);

                    _logger.AddToLog($"Unparked vehicle {vehicle}");
                    _rw.WriteLine($"Unparked vehicle {vehicle}");
                    _seriLogger.Information($"Unparked vehicle {vehicle}");
                    //Log.Logger.LogInformation($"Unparked vehicle {vehicle}");
                    _rw.WriteLine("Press enter to continue");
                    _rw.ReadLine();
                }
                catch (Exception ex)
                {
                    _logger.AddToLog(ex.Message);
                    _rw.WriteLine(ex.Message);
                    _seriLogger.Error(ex, ex.Message);
                    //Log.Logger.LogError(ex, ex.Message);
                    _rw.WriteLine("Press enter to continue");
                    _rw.ReadLine();
                }
            }

            return command != "9";
        }

        private void PrintParkedCars()
        {
            _rw.WriteLine("Parked vehicles");
            _garageHandler.GetAllParkedVehicles()
                .ToList()
                .ForEach(x => _rw.WriteLine(x));
        }

        public bool ShowParkedVehiclesMenu()
        {
            _rw.Clear();
            _rw.WriteLine("--- SEARCH PARKED VEHICLES MENU --");
            _rw.WriteLine($"Search Params");
            _rw.WriteLine(_searchFilter.ToString());
            _rw.WriteSpaceLine();
            _rw.WriteLine("0: Set RegNumber param");
            _rw.WriteLine("1: Set Color param");
            _rw.WriteLine("2: Set Weels param");
            _rw.WriteLine("3: Set ExtraProp param");
            _rw.WriteLine("4: Reset filter");
            _rw.WriteSpaceLine();
            _rw.WriteLine("5: Do search");
            _rw.WriteLine("9: Exit menu");
            _rw.WriteMarker();

            var command = _rw.ReadLine();

            switch (command)
            {
                case "0":
                    SetRegNumber();
                    break;
                case "1":
                    SetColor();
                    break;
                case "2":
                    SetWeels();
                    break;
                case "3":
                    SetExtraProp();
                    break;
                case "4":
                    ClearAllProps();
                    break;
                case "5":
                    PrintSearchResult();
                    break;
            }

            return command != "9";
        }

        private void ClearAllProps()
        {
            _searchFilter.ResetAll();
        }

        private void SetExtraProp()
        {
            _rw.WriteLine("Set Extra property filter");
            PrintAllProperties(nameof(Car), typeof(ICar).GetProperties());
            PrintAllEnumValues(typeof(FuelType));
            PrintAllProperties(nameof(Boat), typeof(IBoat).GetProperties());
            PrintAllProperties(nameof(Airplane), typeof(IAirplane).GetProperties());
            PrintAllProperties(nameof(Motorcycle), typeof(IMotorcycle).GetProperties());
            PrintAllProperties(nameof(Bus), typeof(IBus).GetProperties());
            _rw.WriteSpaceLine();
            _rw.WriteMarker();
            _searchFilter.ExtraProp = GetNumerOrNull(_rw.ReadLine());
        }

        private void PrintAllProperties(
            string typeName,
            PropertyInfo[] extraProperties)
        {
            _rw.WriteSpaceLine();
            _rw.WriteLine($"For {typeName}");
            foreach (var item in extraProperties)
            {
                _rw.WriteLine($"   {item.Name}");
            }
        }

        private static int? GetNumerOrNull(string? rawNum)
        {
            try
            {
                 return !string.IsNullOrWhiteSpace(rawNum)
                    ? int.Parse(rawNum)
                    : null;
            }
            catch
            {
                return null;
            }
        }

        private void SetWeels()
        {
            _rw.WriteLine("Set Number of weels filter");
            _rw.WriteMarker();
            _searchFilter.Weels = GetNumerOrNull(_rw.ReadLine());
        }

        private void SetColor()
        {
            _rw.WriteLine("Set Color filter");
            _rw.WriteSpaceLine();
            PrintAllEnumValues(typeof(ColorType));
            _rw.WriteSpaceLine();
            _rw.WriteMarker();
            try
            {
                _searchFilter.Color = (ColorType?)GetNumerOrNull(_rw.ReadLine());
            }
            catch
            {
                _searchFilter.Color = null;
                return;
            }
        }

        private void PrintAllEnumValues(Type type)
        {
            var allNames = Enum.GetValues(type);
            foreach (var value in allNames)
            {
                _rw.WriteLine($"      {(int)value} {value}");
            }
        }

        private void SetRegNumber()
        {
            _rw.WriteLine("Set RegNumber filter");
            _rw.WriteMarker();
            var regNumber = _rw.ReadLine();
            _searchFilter.RegNumber = !string.IsNullOrWhiteSpace(regNumber)
                ? regNumber
                : null;
        }

        private void PrintSearchResult()
        {
            var list = _garageHandler.GetSearchResult(_searchFilter);
            _rw.WriteLine($"Parked vehicles, {list.Count()}");
            foreach (var vehicle in list)
            {
                _rw.WriteLine(vehicle);
            };
            _rw.WriteSpaceLine();
            _rw.WriteLine("Tryck enter för att fortsätta");
            _rw.ReadLine();
        }

        internal static void SetSaveStageFilename(string filename)
        {
            saveFileName = filename;
        }
    }
}
