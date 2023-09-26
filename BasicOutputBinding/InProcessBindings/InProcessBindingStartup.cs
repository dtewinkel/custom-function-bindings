using InProcessBindings;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(InProcessBindingStartup))]

namespace InProcessBindings;

/*
 * Startup task to add a binding extension by providing the Extension configuration provider.
 */

public class InProcessBindingStartup: IWebJobsStartup
{
    public void Configure(IWebJobsBuilder builder)
    {
        builder.AddExtension<InProcessBindingsExtensionConfigProvider>();
    }
}