using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public interface IDotCommonGraphWriter : IDotEntityWriter
    {
        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}
