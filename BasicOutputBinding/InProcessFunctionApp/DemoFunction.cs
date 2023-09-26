using System;
using InProcessBindings;
using InProcessBindings.LoggingBinding;
using InProcessBindings.RandomGeneratorBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace InProcessFunctionApp;

public class DemoFunction
{
    private readonly ILogger _logger;

    public DemoFunction(ILogger<DemoFunction> logger)
    {
        _logger = logger;
    }


    [FunctionName(nameof(OutParameterDemoFunction))]
    public void OutParameterDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer, 
        [RandomGeneratorBinding(1, 100)] string randomValue, [LoggingBinding(LogLevel.Warning)] out string message)
    {
        _logger.LogInformation("{function} function executed at: {when}", nameof(OutParameterDemoFunction), DateTime.Now);

        message = $"{nameof(OutParameterDemoFunction)} - Hello world {randomValue}!";
    }

    [FunctionName(nameof(CollectorDemoFunction))]
    public void CollectorDemoFunction([TimerTrigger("*/10 * * * * *", RunOnStartup = true)]TimerInfo myTimer, 
        [RandomGeneratorBinding(10, 20)] RandomResult randomValue, [LoggingBinding(LogLevel.Warning)] ICollector<string> messages)
    {
        _logger.LogInformation("{function} function executed at: {when}.", nameof(CollectorDemoFunction), DateTime.Now);

        messages.Add($"{nameof(CollectorDemoFunction)} - Hello world {randomValue.RandomValue}!");
        messages.Add($"{nameof(CollectorDemoFunction)} - Hello again world {randomValue.RandomValue} (between {randomValue.MinValue} and {randomValue.MaxValue}!");
    }

    [FunctionName(nameof(ReturnValueDemoFunction))]
    [return: LoggingBinding(LogLevel.Error)]
    public string ReturnValueDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    {
        _logger.LogInformation("{function} function executed at: {when}.", nameof(ReturnValueDemoFunction), DateTime.Now);

        return $"{nameof(ReturnValueDemoFunction)} - Hello World";
    }

    [FunctionName(nameof(ReturnArrayDemoFunction))]
    [return: LoggingBinding(LogLevel.Error)]
    public string[] ReturnArrayDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    {
        _logger.LogInformation("{function} function executed at: {when}.", nameof(ReturnArrayDemoFunction), DateTime.Now);

        return new[]
        {
            $"{nameof(ReturnArrayDemoFunction)} - Hello World",
            $"{nameof(ReturnArrayDemoFunction)} - Hello again World"
        };
    }
}