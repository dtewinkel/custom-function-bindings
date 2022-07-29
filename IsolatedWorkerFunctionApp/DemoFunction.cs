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

    [Function("DemoFunction")]
    public void Run([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] TimerInfo timerInfo)
    {
        var nextInvocation = timerInfo.ScheduleStatus?.Next.ToString("o") ?? "Unknown";
        _logger.LogInformation("C# Timer trigger function executed at: {when}. Next invocation: {nextInvocation}.", DateTime.Now, nextInvocation);
    }
}
