using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphWriter : IDotEntityWriter
    {
        void WriteGraphDeclaration(string id, bool strict, bool quoteId);

        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}
