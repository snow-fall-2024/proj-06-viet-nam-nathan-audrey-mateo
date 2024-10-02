﻿using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

public class XUnitLogger : ILogger
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly string _categoryName;

    public XUnitLogger(ITestOutputHelper outputHelper, string categoryName)
    {
        _outputHelper = outputHelper;
        _categoryName = categoryName;
    }

    public IDisposable BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information; // Adjust log level if needed.

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var message = formatter(state, exception);
        if (!string.IsNullOrEmpty(message))
        {
            _outputHelper.WriteLine($"{logLevel}: {_categoryName}: {message}");
        }

        if (exception != null)
        {
            _outputHelper.WriteLine($"{logLevel}: {_categoryName}: {exception}");
        }
    }
}