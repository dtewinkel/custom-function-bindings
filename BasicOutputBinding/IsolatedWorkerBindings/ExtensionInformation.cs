using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

/* 
 * The ExtensionInformationAttribute links the bindings in this assembly to the actual implementation.
 * This link is a link to a NuGet package that implements the actual in-process bindings that 
 * are executed in the host process.The NuGet package is referenced by its ID and version.
 */
[assembly: ExtensionInformation("Basic.OutputBinding.InProcess", "1.0.0")]
