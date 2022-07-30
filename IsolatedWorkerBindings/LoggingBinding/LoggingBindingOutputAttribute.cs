using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;
using Microsoft.Extensions.Logging;

namespace IsolatedWorkerBindings.LoggingBinding;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
public class LoggingBindingOutputAttribute: OutputBindingAttribute
{
    public LoggingBindingOutputAttribute(LogLevel logLevel)
    {
        LogLevel = logLevel;
    }

    public LogLevel LogLevel { get; set; }
}