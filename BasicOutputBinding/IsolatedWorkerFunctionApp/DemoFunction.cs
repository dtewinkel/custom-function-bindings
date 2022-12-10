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

    [Function(nameof(SingleValueOutputTypeDemoFunction))]
    public SingleValueOutputType SingleValueOutputTypeDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    {
        _logger.LogInformation("{function} function executed at: {when}", nameof(SingleValueOutputTypeDemoFunction), DateTime.Now);

        return new SingleValueOutputType
        {
            Message = $"{nameof(SingleValueOutputTypeDemoFunction)} - Hello world!"
        };
    }

    public class SingleValueOutputType
    {
        [LoggingBindingOutput(LogLevel.Warning)]
        public string? Message { get; set; }
    }

    [Function(nameof(MultiValueOutputTypeDemoFunction))]
    public MultiValueOutputType MultiValueOutputTypeDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    {
        _logger.LogInformation("{function} function executed at: {when}.", nameof(MultiValueOutputTypeDemoFunction), DateTime.Now);

        return new MultiValueOutputType
        {
            Messages = new[]
            {
                $"{nameof(MultiValueOutputTypeDemoFunction)} - Hello world!",
                $"{nameof(MultiValueOutputTypeDemoFunction)} - Hello again world!"
            }
        };
    }

    public class MultiValueOutputType
    {
        [LoggingBindingOutput(LogLevel.Warning)]
        public string[]? Messages { get; set; }
    }

    [Function(nameof(ReturnValueDemoFunction))]
    [LoggingBindingOutput(LogLevel.Error)]
    public string ReturnValueDemoFunction([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    {
        _logger.LogInformation("{function} function executed at: {when}.", nameof(ReturnValueDemoFunction), DateTime.Now);

        return $"{nameof(ReturnValueDemoFunction)} - Hello World";
    }

    [Function(nameof(ReturnArrayDemoFunction))]
    [LoggingBindingOutput(LogLevel.Error)]
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
