using InProcessBindings.LoggingBinding;
using InProcessBindings.RandomGeneratorBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InProcessBindings;

[Extension("Output Binding Example")]
public class InProcessBindingsExtensionConfigProvider: IExtensionConfigProvider
{
    private readonly ILogger<LoggingBindingAsyncCollector> _logger;

    public InProcessBindingsExtensionConfigProvider(ILogger<LoggingBindingAsyncCollector> logger)
    {
        _logger = logger;
    }

    public void Initialize(ExtensionConfigContext context)
    {
        context
            .AddBindingRule<LoggingBindingAttribute>()
            .BindToCollector(attribute => new LoggingBindingAsyncCollector(attribute, _logger));

        var rule = context.AddBindingRule<RandomGeneratorBindingAttribute>();

        var converter = new RandomInputConverter();
        rule.BindToInput<int>(converter);
        rule.BindToInput<string>(converter);
        rule.BindToInput<RandomResult>(converter);
    }
}

public class RandomInputConverter : 
    IConverter<RandomGeneratorBindingAttribute, int>,
    IConverter<RandomGeneratorBindingAttribute, string>,
    IConverter<RandomGeneratorBindingAttribute, RandomResult>
{
    private readonly Random _randomGenerator = new();

    int IConverter<RandomGeneratorBindingAttribute, int>.Convert(RandomGeneratorBindingAttribute input)
    {
        return GetRandomValue(input);
    }

    private int GetRandomValue(RandomGeneratorBindingAttribute input)
    {

        return _randomGenerator.Next(input.Min, input.Max);
    }

    string IConverter<RandomGeneratorBindingAttribute, string>.Convert(RandomGeneratorBindingAttribute input)
    {
        return JsonConvert.SerializeObject(GetRandomResult(input));
    }

    RandomResult IConverter<RandomGeneratorBindingAttribute, RandomResult>.Convert(RandomGeneratorBindingAttribute input)
    {
        return GetRandomResult(input);
    }

    private RandomResult GetRandomResult(RandomGeneratorBindingAttribute input)
    {
        return new RandomResult
        {
            RandomValue = GetRandomValue(input),
            MinValue = input.Min,
            MaxValue = input.Max
        };
    }
}