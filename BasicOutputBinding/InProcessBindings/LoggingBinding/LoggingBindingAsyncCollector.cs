using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace InProcessBindings.LoggingBinding;

public class LoggingBindingAsyncCollector : IAsyncCollector<string>
{
    private readonly LoggingBindingAttribute _outputBindingAttribute;
    private readonly ILogger<LoggingBindingAsyncCollector> _logger;
    private readonly List<string> _items = new();

    public LoggingBindingAsyncCollector(LoggingBindingAttribute outputBindingAttribute, ILogger<LoggingBindingAsyncCollector> logger)
    {
        _outputBindingAttribute = outputBindingAttribute;
        _logger = logger;
    }

    public Task AddAsync(string item, CancellationToken cancellationToken = new())
    {
        _logger.Log(_outputBindingAttribute.LogLevel, "Log on AddAsync: {item}.", item);
        _items.Add(item);
        return Task.CompletedTask;
    }

    public Task FlushAsync(CancellationToken cancellationToken = new())
    {
        foreach (var item in _items)
        {
            _logger.Log(_outputBindingAttribute.LogLevel, "Log on FlushAsync: {item}.", item);
        }
        return Task.CompletedTask;
    }
}