# Custom Function Bindings - Basic Output Binding

## Implementation in InProcessBindings

An output binding consists of a few part to make it work:

1. An attribute to bind 
1. An extension to configure the binding...
1. A Collector, which provides the implementation of the binding.

See the comments in the source files

## Wrapper in IsolatedWorkerBindings

To be able to use a binding in Azure Functions using the Isolated Worker Process a wrapper needs to be provided to proxy the implementation in the In Process binding. This proxy is automatically generated based on the bindings provided in the project and based on naming conventions.

So to make it work this is needed:

1. 