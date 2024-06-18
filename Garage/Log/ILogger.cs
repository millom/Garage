namespace Garage.Log
{
    internal interface ILogger
    {
        void AddToLog(string message);
        void PrintLog();
    }
}