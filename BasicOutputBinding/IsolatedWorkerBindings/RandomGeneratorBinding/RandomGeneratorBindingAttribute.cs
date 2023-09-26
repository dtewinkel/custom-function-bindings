using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

namespace IsolatedWorkerBindings.RandomGeneratorBinding;

public sealed class RandomGeneratorBindingInputAttribute : InputBindingAttribute
{
    public RandomGeneratorBindingInputAttribute(int min = int.MinValue, int max = int.MaxValue)
    {
        Max = max;
        Min = min;
    }

    public int Min { get; }

    public int Max { get; }
}
