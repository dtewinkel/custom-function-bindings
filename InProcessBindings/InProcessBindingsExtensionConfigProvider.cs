using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace InProcessBindings;

[Extension("InProcessBindings")]
public class InProcessBindingsExtensionConfigProvider: IExtensionConfigProvider
{
    public void Initialize(ExtensionConfigContext context)
    {
    }
}