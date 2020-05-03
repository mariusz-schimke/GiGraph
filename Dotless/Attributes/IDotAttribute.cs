using Dotless.Core;

namespace Dotless.Attributes
{
    // TODO: czy ten interfejs jest rzeczywiście użyteczny?
    public interface IDotAttribute : IDotEntity
    {
        string Key { get; }
        bool HasValue { get; }
    }
}