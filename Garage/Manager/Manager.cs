using Garage.Garage;
using Garage.Types;
using Garage.UI;

namespace Garage.Manager
{
    internal class Manager(
        IUI ui,
        IGarageHandler garageHandler,
        ISearchFilter searchFilter) : IManager
    {
        private readonly IUI _ui = ui;
        private readonly IGarageHandler _garageHandler = garageHandler;
        private readonly ISearchFilter _searchFilter = searchFilter;

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
            _ui.WriteLine("9: Exit program");

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
                default:
                    break;
            }

            return command != "9";
        }

        public bool ParkMenu()
        {
            _ui.Clear();
            _ui.WriteLine("--- PARK VEHICLE MENU ---");
            PrintFreeSlots();
            PrintCarsToPark();
            _ui.WriteLine("Park car: <regNr, parkingSlot> (Ex: ABC123, 0)");
            _ui.WriteLine("9: Exit menu");

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
                        _garageHandler.ParkVehicle(regNbr, slotId);
                    }
                    catch
                    {

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
                .ToList()
                .ForEach(v => _ui.WriteLine(v));
            _ui.WriteSpaceLine();
        }

        private void PrintFreeSlots()
        {
            _ui.WriteSpaceLine();
            _ui.WriteLine("Free parking slots");
            _garageHandler
                .GetFreeSlots()
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

            var command = _ui.ReadLine();

            if (!string.IsNullOrWhiteSpace(command) && command != "9")
            {
                _garageHandler.GetParkedVehicle(command);
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
            _ui.WriteLine(_searchFilter.ToString()!);
            _ui.WriteSpaceLine();
            _ui.WriteLine("0: Set RegNumber param");
            _ui.WriteLine("1: Set Color param");
            _ui.WriteLine("2: Set Weels param");
            _ui.WriteLine("3: Set ExtraProp param");
            _ui.WriteLine("4: Reset filter");
            _ui.WriteSpaceLine();
            _ui.WriteLine("5: Do search");
            _ui.WriteLine("9: Exit menu");

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
            _searchFilter.Weels = GetNumerOrNull(_ui.ReadLine());
        }

        private void SetColor()
        {
            _ui.WriteLine("Set Color filter");
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

        //public bool SearchParkedMenu()
        //{
        //    _ui.Clear();
        //    return true;
        //}

        //public void PrintNotParkedMenu()
        //{

        //}

        //public void PrintSeeParked()
        //{

        //}
    }
}
