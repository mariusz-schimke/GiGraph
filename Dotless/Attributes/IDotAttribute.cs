using Dotless.Core;

namespace Dotless.Attributes
{
    public interface IDotAttribute : IDotEntity
    {
        string Key { get; }
    }
}