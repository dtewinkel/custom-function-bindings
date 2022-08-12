using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

/* 
 * The ExtensionInformationAttribute links the bindings in this assembly to the actual implementation.
 * This link is a link to a NuGet package with the in-process binding that implement the actual bindings that 
 * are executed on the host.The NuGet package is referenced by its ID and version.
 */
[assembly: ExtensionInformation("SimpleOutputBinding", "1.0.0")]
