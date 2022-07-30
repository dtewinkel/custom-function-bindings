using IsolatedWorkerBindings.LoggingBinding;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace IsolatedWorkerFunctionApp;

public class DemoFunction
{
    private readonly ILogger<DemoFunction> _logger;

    public DemoFunction(ILogger<DemoFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(OutParameterDemoFunction))]
    public void OutParameterDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer , [LoggingBindingOutput(LogLevel.Warning)] out string message)
    {
        _logger.LogInformation("{function} function executed at: {when}", nameof(OutParameterDemoFunction), DateTime.Now);

        message = $"{nameof(OutParameterDemoFunction)} - Hello world!";
    }

    //[Function(nameof(CollectorDemoFunction))]
    //public void CollectorDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer, [LoggingBindingOutput(LogLevel.Warning)] ICollector<string> messages)
    //{
    //    _logger.LogInformation("{function} function executed at: {when}.", nameof(CollectorDemoFunction), DateTime.Now);

    //    messages.Add($"{nameof(CollectorDemoFunction)} - Hello world!");
    //    messages.Add($"{nameof(CollectorDemoFunction)} - Hello again world!");
    //}

    //[Function(nameof(ReturnValueDemoFunction))]
    //[return: LoggingBindingOutput(LogLevel.Error)]
    //public string ReturnValueDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    //{
    //    _logger.LogInformation("{function} function executed at: {when}.", nameof(ReturnValueDemoFunction), DateTime.Now);

    //    return $"{nameof(ReturnValueDemoFunction)} - Hello World";
    //}

    //[Function(nameof(ReturnArrayDemoFunction))]
    //[return: LoggingBindingOutput(LogLevel.Error)]
    //public string[] ReturnArrayDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    //{
    //    _logger.LogInformation("{function} function executed at: {when}.", nameof(ReturnArrayDemoFunction), DateTime.Now);

    //    return new[]
    //    {
    //        $"{nameof(ReturnArrayDemoFunction)} - Hello World",
    //        $"{nameof(ReturnArrayDemoFunction)} - Hello again World"
    //    };
    //}

}
