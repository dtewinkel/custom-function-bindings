using Microsoft.Azure.WebJobs.Description;

namespace InProcessBindings.RandomGeneratorBinding;

[AttributeUsage(AttributeTargets.Parameter)]
[Binding]
public class RandomGeneratorBindingAttribute : Attribute
{
    public RandomGeneratorBindingAttribute(int min = int.MinValue, int max = int.MaxValue)
    {
        Max = max;
        Min = min;
    }

    public int Min { get; }

    public int Max { get; }
}