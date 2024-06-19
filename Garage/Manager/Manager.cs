using Garage.Garage;
using Garage.Log;
using Garage.SearchFilter;
using Garage.Types;
using Garage.UI;
using Garage.Vehicles;

using Microsoft.Extensions.Logging;

namespace Garage.Manager
{
    internal class Manager(
        IUI ui,
        IGarageHandler garageHandler,
        ISearchFilter searchFilter,
        IMyLogger logger,
        Serilog.ILogger seriLogger) : IManager
    {
        private readonly IUI _ui = ui;
        private readonly IGarageHandler _garageHandler = garageHandler;
        private readonly ISearchFilter _searchFilter = searchFilter;
        private readonly IMyLogger _logger = logger;
        private readonly Serilog.ILogger _seriLogger = seriLogger;

        public void Run()
        {
            while (MainMenu()) ;
        }

        public bool MainMenu()
        {
            _ui.Clear();
            _ui.WriteLine("--- MAIN MENU ---");
            _ui.WriteLine("0: Park vehicle");
            _ui.WriteLine("1: Get parked vehicle");
            _ui.WriteLine("2: Show parked vehicles");
            _ui.WriteLine("3: Show log");
            _ui.WriteLine("9: Exit program");
            _ui.Write("> ");

            var command = _ui.ReadLine();

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
                default:
                    break;
            }

            return command != "9";
        }

        private void ShowLog()
        {
            _logger.PrintLog();
            //_ui.WriteSpaceLine();
            _ui.WriteLine("Press enter to continue");
            _ui.ReadLine();
        }

        public bool ParkMenu()
        {
            _ui.Clear();
            _ui.WriteLine("--- PARK VEHICLE MENU ---");
            _ui.WriteSpaceLine();
            _ui.WriteLine("Free parking slots");
            PrintFreeSlots();
            PrintCarsToPark();
            _ui.WriteLine("<regNr, parkingSlot>: Park regNr on parkingSlot : (Ex: ABC123, 0)");
            _ui.WriteLine("9: Exit menu");
            _ui.Write("> ");

            var command = _ui.ReadLine();
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
                        _ui.WriteLine($"In slot {slotId}: Parked vehicle <{vehicle}>");
                        _seriLogger.Information($"In slot {slotId}: Parked vehicle <{vehicle}>");
                        _ui.WriteLine("Press enter to continue");
                        _ui.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        _logger.AddToLog(ex.Message);
                        _ui.WriteLine(ex.Message);
                        _seriLogger.Error(ex, ex.Message);
                        _ui.WriteLine("Press enter to continue");
                        _ui.ReadLine();
                    }
                }
            }

            return command != "9";
        }

        private void PrintCarsToPark()
        {
            _ui.WriteSpaceLine();
            _ui.WriteLine("Vehicles to park");
            _garageHandler
                .GetNotParkedVehicles()
                .Where(x => x is not null)
                .ToList()
                .ForEach(x => _ui.WriteLine(x));
            _ui.WriteSpaceLine();
        }

        private void PrintFreeSlots()
        {
            _garageHandler
                .GetEmptyIndexes()
                .ToList()
                .ForEach(id => _ui.Write($"{id} "));
            _ui.WriteLine("");
        }

        public bool UnparkMenu()
        {
            _ui.Clear();
            _ui.WriteLine("--- UNPARK VEHICLE MENU --");
            _ui.WriteSpaceLine();
            PrintParkedCars();
            _ui.WriteSpaceLine();
            _ui.WriteLine("<regNr>: Unpark car Ex: ABC123");
            _ui.WriteLine("9: Exit menu");
            _ui.Write("> ");

            var command = _ui.ReadLine();

            if (!string.IsNullOrWhiteSpace(command) && command != "9")
            {
                try
                {
                    var vehicle = _garageHandler.GetParkedVehicle(command);

                    _logger.AddToLog($"Unparked vehicle {vehicle}");
                    _ui.WriteLine($"Unparked vehicle {vehicle}");
                    _seriLogger.Information($"Unparked vehicle {vehicle}");
                    //Log.Logger.LogInformation($"Unparked vehicle {vehicle}");
                    _ui.WriteLine("Press enter to continue");
                    _ui.ReadLine();
                }
                catch (Exception ex)
                {
                    _logger.AddToLog(ex.Message);
                    _ui.WriteLine(ex.Message);
                    _seriLogger.Error(ex, ex.Message);
                    //Log.Logger.LogError(ex, ex.Message);
                    _ui.WriteLine("Press enter to continue");
                    _ui.ReadLine();
                }
            }

            return command != "9";
        }

        private void PrintParkedCars()
        {
            _ui.WriteLine("Parked vehicles");
            _garageHandler.GetAllParkedVehicles()
                .ToList()
                .ForEach(x => _ui.WriteLine(x));
        }

        public bool ShowParkedVehiclesMenu()
        {
            _ui.Clear();
            _ui.WriteLine("--- SEARCH PARKED VEHICLES MENU --");
            _ui.WriteLine($"Search Params");
            _ui.WriteLine(_searchFilter.ToString());
            _ui.WriteSpaceLine();
            _ui.WriteLine("0: Set RegNumber param");
            _ui.WriteLine("1: Set Color param");
            _ui.WriteLine("2: Set Weels param");
            _ui.WriteLine("3: Set ExtraProp param");
            _ui.WriteLine("4: Reset filter");
            _ui.WriteSpaceLine();
            _ui.WriteLine("5: Do search");
            _ui.WriteLine("9: Exit menu");
            _ui.Write("> ");

            var command = _ui.ReadLine();

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
            _ui.WriteLine("Set Extra property filter");
            _ui.Write("> ");
            _searchFilter.ExtraProp = GetNumerOrNull(_ui.ReadLine());
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
            _ui.WriteLine("Set Number of weels filter");
            _ui.Write("> ");
            _searchFilter.Weels = GetNumerOrNull(_ui.ReadLine());
        }

        private void SetColor()
        {
            _ui.WriteLine("Set Color filter");
            _ui.Write("> ");
            try
            {
                _searchFilter.Color = (ColorType?)GetNumerOrNull(_ui.ReadLine());
            }
            catch
            {
                _searchFilter.Color = null;
                return;
            }
        }

        private void SetRegNumber()
        {
            _ui.WriteLine("Set RegNumber filter");
            _ui.Write("> ");
            var regNumber = _ui.ReadLine();
            _searchFilter.RegNumber = !string.IsNullOrWhiteSpace(regNumber)
                ? regNumber
                : null;
        }

        private void PrintSearchResult()
        {
            var list = _garageHandler.GetSearchResult(_searchFilter);
            _ui.WriteLine($"Parked vehicles, {list.Count()}");
            foreach (var vehicle in list)
            {
                _ui.WriteLine(vehicle);
            };
            _ui.WriteSpaceLine();
            _ui.WriteLine("Tryck enter för att fortsätta");
            _ui.ReadLine();
        }
    }
}
