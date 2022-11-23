using Microsoft.Extensions.Logging;

using static System.Console;

public class ConsoleLoggerProvider : ILoggerProvider
{
    void IDisposable.Dispose() {}
    ILogger ILoggerProvider.CreateLogger(string categoryName) => new ConsoleLogger();
}

public class ConsoleLogger : ILogger
{
    IDisposable ILogger.BeginScope<TState>(TState state) => null!;

    bool ILogger.IsEnabled(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace or LogLevel.Information or LogLevel.None => false,
            _ => true,
        };
    }

    void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (eventId.Id == 20100) {
            Write($"Level: {logLevel}, Event Id: {eventId.Id}");
            if (state != null)
            {
                Write($", State: {state}");
            }
            if (exception != null)
            {
                Write($", Exception: {exception.Message}");
            }
            WriteLine();
        }
    }
}