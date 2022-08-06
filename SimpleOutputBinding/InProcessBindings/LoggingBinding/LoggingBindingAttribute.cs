using System;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Extensions.Logging;

namespace InProcessBindings.LoggingBinding;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
[Binding]
public class LoggingBindingAttribute : Attribute
{
    public LoggingBindingAttribute(LogLevel logLevel)
    {
        LogLevel = logLevel;
    }

    public LogLevel LogLevel { get; }
}