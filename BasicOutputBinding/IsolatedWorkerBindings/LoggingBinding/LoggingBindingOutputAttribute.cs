using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;
using Microsoft.Extensions.Logging;

namespace IsolatedWorkerBindings.LoggingBinding;

/*
 * The output binding attribute to proxy the output binding in the In-process binding assembly.
 *
 * Naming: Attribute name from the in process assembly with 'Output' added.
 *   In this example: 'LoggingBinding' + 'Output' + 'Attribute'.
 *
 * Please note that the Isolate worker output bindings are valid on different elements than in the In-process bindings:
 *   - In-process: Parameter and ReturnValue.
 *   - Isolate worker: Method and Property.
 */
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
public class LoggingBindingOutputAttribute: OutputBindingAttribute
{
    public LoggingBindingOutputAttribute(LogLevel logLevel)
    {
        LogLevel = logLevel;
    }

    public LogLevel LogLevel { get; }
}