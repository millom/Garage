namespace Garage.Manager
{
    /// <summary>
    /// Interface defining the Manager class
    /// </summary>
    internal interface IManager
    {
        bool MainMenu();
        bool ParkMenu();
        void Run();
        bool ShowParkedVehiclesMenu();
        bool UnparkMenu();
    }
}