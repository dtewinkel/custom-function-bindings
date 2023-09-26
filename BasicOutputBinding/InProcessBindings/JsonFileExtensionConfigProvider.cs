using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace InProcessBindings;

[Extension("JSon Binding Example")]
public class JsonFileExtensionConfigProvider : IExtensionConfigProvider
{
    public void Initialize(ExtensionConfigContext context)
    {
        context
            .AddBindingRule<JsonFileAttribute>()
            .BindToCollector(attribute => new JsonFileAsyncCollector(attribute));
    }
}