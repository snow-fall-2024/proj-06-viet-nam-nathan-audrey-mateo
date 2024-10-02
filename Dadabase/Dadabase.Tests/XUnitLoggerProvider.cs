using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

public class XUnitLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _outputHelper;

    public XUnitLoggerProvider(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new XUnitLogger(_outputHelper, categoryName);
    }

    public void Dispose() { }
}
