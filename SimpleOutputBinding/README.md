# Custom Function Bindings - Base

Experiments in creating custom Azure function bindings. For the starting point of this project see the [main branch](https://github.com/dtewinkel/custom-function-bindings).

This branch contains the base project structure shared by all branches that contain the examples.

## Common structure

All branches use the same project structure, as defined in this branch.

## Solutions

The repository contains two solutions:

1. The solution, `InProcess.sln`, that defines and demos the 'classic' in-process bindings. This solution also produces a NuGet package that is consumed by the other solution.
1. The solution, `IsolatedWorker.sln`, that defines and demos the bindings for the .NET Isolated worker.

Each solution contains two project:

1. The project that defines the bindings.
1. The project that consumes the binding with one or more demo functions.
