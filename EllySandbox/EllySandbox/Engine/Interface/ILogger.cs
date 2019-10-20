namespace EllySandbox.Engine.Interface
{
    public interface ILogger
    {
        void Log(object message);
        void LogWarning(object message);
        void LogError(object message);
        void LogTypeError(object message, System.Type type);
    }
}
