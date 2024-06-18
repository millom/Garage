namespace Garage.Log
{
    internal interface IMyLogger
    {
        void AddToLog(string message);
        void PrintLog();
    }
}