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
    public void Run([TimerTrigger("0 */10 * * * *", RunOnStartup = true)] MyInfo myTimer)
    {
        var nextInvocation = myTimer.ScheduleStatus.Next;
        _logger.LogInformation("C# Timer trigger function executed at: {when}. Next invocation: {nextInvocation}.", DateTime.Now, nextInvocation);
    }
}

public class MyInfo
{
    public MyScheduleStatus ScheduleStatus { get; set; }

    public bool IsPastDue { get; set; }
}

public class MyScheduleStatus
{
    public DateTime Last { get; set; }

    public DateTime Next { get; set; }

    public DateTime LastUpdated { get; set; }
}