using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;
using Microsoft.Extensions.Logging;

namespace IsolatedWorkerBindings.LoggingBinding;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
public class LoggingBindingOutputAttribute: OutputBindingAttribute
{
    public LoggingBindingOutputAttribute(LogLevel logLevel)
    {
        LogLevel = logLevel;
    }

    public LogLevel LogLevel { get; }
}