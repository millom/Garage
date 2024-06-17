using Garage.Garage;
using Garage.UI;

namespace Garage.Manager
{
    internal class Manager : IManager
    {
        private readonly IUI _ui;
        private readonly IGarageHandler _garageHandler;
        private readonly ISearchFilter _searchFilter;

        public Manager(
            IUI ui,
            IGarageHandler garageHandler,
            ISearchFilter searchFilter)
        {
            _ui = ui;
            _garageHandler = garageHandler;
            _searchFilter = searchFilter;
        }

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
            _ui.WriteLine("--- PARK VEHICLE MENU --");

            var command = _ui.ReadLine();

            return command != "9";
        }

        public bool UnparkMenu()
        {
            _ui.Clear();
            _ui.WriteLine("--- PARK VEHICLE MENU --");

            var command = _ui.ReadLine();

            return command != "9";
        }

        public bool ShowParkedVehiclesMenu()
        {
            _ui.Clear();
            _ui.WriteLine("--- SEARCH PARKED VEHICLES MENU --");
            _ui.WriteLine("0: Do search");
            _ui.WriteLine($"Search Params");
            _ui.WriteLine(_searchFilter.ToString()!);
            _ui.WriteLine("1: Set RegNumber param");
            _ui.WriteLine("2: Set Color param");
            _ui.WriteLine("3: Set Weels param");
            _ui.WriteLine("4: Set ExtraProp param");
            _ui.WriteLine("9: Exit menu");

            var command = _ui.ReadLine();

            switch (command)
            {
                case "0":
                    PrintSearchResult();
                    break;
                case "1":
                    SetRegNumber();
                    break;
                case "2":
                    //SetColor();
                    break;
                case "3":
                    //SetWeels();
                    break;
                case "4":
                    //SetExtraProp();
                    break;
            }

            return _ui.ReadLine() != "9";
        }

        private void SetRegNumber()
        {
            _searchFilter.GetPublicInstanceProps();
            foreach (var prop in _searchFilter.GetPublicInstanceProps())
            {
                _ui.WriteLine($"{prop.Name}");
            }
        }

        private void PrintSearchResult()
        {
            foreach (var vehicle in _garageHandler.GetSearchResult(_searchFilter))
            {
                _ui.WriteLine(vehicle);
            };
        }

        public bool SearchParkedMenu()
        {
            _ui.Clear();
            return true;
        }

        public void PrintNotParkedMenu()
        {

        }

        public void PrintSeeParked()
        {

        }
    }
}
