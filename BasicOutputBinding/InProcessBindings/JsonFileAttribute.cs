using Microsoft.Azure.WebJobs.Description;

namespace InProcessBindings;

/*
 * Output bindings can be used on (out) parameters and on the return value.
 */
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
/*
 * Indicate this is a binding.
 */
[Binding]
public class JsonFileAttribute: Attribute
{
    /// <summary>
    /// property to get the path to write the JSON file to
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonFileAttribute"/> class.
    /// </summary>
    /// <param name="path">Path to write the JSON file to.</param>
    /// <remarks>Will overwrite the file if it already existed.</remarks>
    public JsonFileAttribute(string path)
    {
        Path = path;
    }
}