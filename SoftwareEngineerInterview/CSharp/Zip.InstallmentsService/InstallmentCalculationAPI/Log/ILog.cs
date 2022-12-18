namespace InstallmentCalculationAPI.Log
{
    /// <summary>
    /// Interface for all log methods
    /// </summary>
    public interface ILog
    {
        
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
