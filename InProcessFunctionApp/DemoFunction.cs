using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionApp;

public class DemoFunction
{
    private readonly ILogger _logger;

    public DemoFunction(ILogger<DemoFunction> logger)
    {
        _logger = logger;
    }

    [FunctionName("DemoFunction")]
    public void Run([TimerTrigger("0 */10 * * * *", RunOnStartup = true)]TimerInfo myTimer)
    {
        var nextInvocation = (myTimer?.FormatNextOccurrences(1) ?? "unknown").ReplaceLineEndings("");
        _logger.LogInformation("C# Timer trigger function executed at: {when}. Next invocation: {nextInvocation}.", DateTime.Now, nextInvocation);
    }
}