namespace Garage.Manager
{
    internal interface IManager
    {
        bool MainMenu();
        bool ParkMenu();
        void PrintNotParkedMenu();
        void PrintSeeParked();
        void Run();
        bool SearchParkedMenu();
        bool ShowParkedVehiclesMenu();
        bool UnparkMenu();
    }
}