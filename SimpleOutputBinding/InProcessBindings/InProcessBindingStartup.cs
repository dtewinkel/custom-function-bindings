using InProcessBindings;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(InProcessBindingStartup))]

namespace InProcessBindings;

public class InProcessBindingStartup: IWebJobsStartup
{
    public void Configure(IWebJobsBuilder builder)
    {
        builder.AddExtension<InProcessBindingsExtensionConfigProvider>();
    }
}