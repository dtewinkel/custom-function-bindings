using InProcessBindings.LoggingBinding;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;

namespace InProcessBindings;

public class InProcessBindingsExtensionConfigProvider: IExtensionConfigProvider
{
    private readonly ILogger<LoggingBindingAsyncCollector> _logger;

    public InProcessBindingsExtensionConfigProvider(ILogger<LoggingBindingAsyncCollector> logger)
    {
        _logger = logger;
    }

    public void Initialize(ExtensionConfigContext context)
    {
        context
            .AddBindingRule<LoggingBindingAttribute>()
            .BindToCollector(attribute => new LoggingBindingAsyncCollector(attribute, _logger));
    }
}