namespace Garage.Manager
{
    internal interface IManager
    {
        bool MainMenu();
        bool ParkMenu();
        void Run();
        bool ShowParkedVehiclesMenu();
        bool UnparkMenu();
    }
}