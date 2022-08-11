# Custom Azure Function Bindings

Experiments in creating custom Azure Function bindings.

## Introduction

The repository contains a number of experiments I did to step by step discover how to write custom Azure Function bindings, one feature at a time.

Each experiment is stored in a folder, where the Visual Studio solutions and projects for that experiment can be found.

Each experiment contains the documentation as comments in the code, with a README.md as a starting point in the root of the directory.

The only purpose of this repository is experimenting with custom Azure Function bindings, so don't expect the best structured code, unit tests, or other great stuff one should do for production ready code.

All experiments produce bindings for use in *classic* in process Azure Functions and for use in the new [Isolated Model](https://github.com/Azure/azure-functions-dotnet-worker) Azure Functions.

I recommend reading [Maarten Balliauw](https://blog.maartenballiauw.be/)'s post on [Custom bindings with Azure Functions .NET Isolated Worker](https://blog.maartenballiauw.be/post/2021/06/01/custom-bindings-with-azure-functions-dotnet-isolated-worker.html). Saves me from a lot of explaining on this page.

## Local NuGet Setup

Before any of the project can be build and tested, some setup must be done on the local computer:

- Set environment variable `CUSTOM_FUNCTION_BINDINGS_NUGET` to the path were nuget packages for the projects can be stored.
- Add this path to the user NuGet config. See [NuGet Config file locations](https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior#config-file-locations-and-uses) for where to find the user NuGet config file. See [Changing config settings](https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior#changing-config-settings) on how to update the NuGet config.

## Projects per experiment

Each solution for each experiment contains four project:

- `InProcessBindings` - Actual implementation of the Azure Function bindings. Produces a NuGet that is referenced by the `IsolatedWorkerBindings`
- `InProcessFunctionApp` - *classic* Azure Functions app demonstrating the use of the feature from the `InProcessBindings` project.
- `IsolatedWorkerBindings` - Implementation of the Azure Function bindings wrappers to make the bindings from the `InProcessBindings` project work in the Isolated Worker model.
- `IsolatedWorkerFunctionApp` - Isolated Worker Azure Functions app demonstrating the Isolated worker bindings from the `IsolatedWorkerBindings`.

## Experiments

- [Simple Output Binding - README.md](./SimpleOutputBinding/README.md) - Add a simple output binding.

## References

Amongst others, I used the following documentation and great projects of others as input for my experiments:

- [Custom bindings with Azure Functions .NET Isolated Worker](https://blog.maartenballiauw.be/post/2021/06/01/custom-bindings-with-azure-functions-dotnet-isolated-worker.html) by Maarten Balliauw.
- [Azure / azure-functions-dotnet-worker](https://github.com/Azure/azure-functions-dotnet-worker) repository on GitHub.
- [Azure / azure-webjobs-sdk Repo](https://github.com/Azure/azure-webjobs-sdk) and [Azure / azure-webjobs-sdk Wiki](https://github.com/Azure/azure-webjobs-sdk/wiki).
- [Azure / azure-webjobs-sdk-extensions Repo](https://github.com/Azure/azure-webjobs-sdk-extensions) and [Azure / azure-webjobs-sdk-extensions Wiki](https://github.com/Azure/azure-webjobs-sdk-extensions/wiki).

Some other sources:

- [Azure Tips and Tricks - Tip 247: Creating custom bindings for Azure Functions](https://microsoft.github.io/AzureTipsAndTricks/blog/blog/tip247.html).
- [MQTT function bindings by Kees Schollaart](https://case.schollaart.net/2018/09/22/mqtt-and-azure-functions.html).
