using Microsoft.Azure.WebJobs;

namespace InProcessBindings;

/*
 * The actual implementation for the output binding.
 * It must be derived from IAsyncCollector
 */
/// <inheritdoc />
public class JsonFileAsyncCollector : IAsyncCollector<string>
{
    private readonly JsonFileAttribute _jsonFileAttribute;
    private readonly List<string> _items = new();

    public JsonFileAsyncCollector(JsonFileAttribute jsonFileAttribute)
    {
        _jsonFileAttribute = jsonFileAttribute;
    }


    /// <summary>
    /// Adds an item to the <see cref="T:Microsoft.Azure.WebJobs.IAsyncCollector`1" />.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task that will add the item to the collector.</returns>
    public Task AddAsync(string item, CancellationToken cancellationToken = new())
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Flush all the events accumulated so far.
    /// This can be an empty operation if the messages are not batched.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    public Task FlushAsync(CancellationToken cancellationToken = new())
    {
        return Task.CompletedTask;
    }
}