# Custom Function Bindings

Experiments in creating custom Azure function bindings.

## Introduction

## Local NuGet Setup

Before any of the project can be build and tested to setup must be done on the local computer:

- Set environment variable `CUSTOM_FUNCTION_BINDINGS_NUGET` to the path were nuget packages for the projects can be stored.
  
- Add this path to the user NuGet config. See [NuGet Config file locations](https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior#config-file-locations-and-uses) for where to find the user NuGet config file. See [Changing config settings](https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior#changing-config-settings) on how to update the NuGet config.

## Experiments

- [Simple Output Binding - README.md](./SimpleOutputBinding/README.md)
