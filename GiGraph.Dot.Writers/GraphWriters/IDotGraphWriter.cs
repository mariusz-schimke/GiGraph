namespace GiGraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphWriter : IDotCommonGraphWriter
    {
        void WriteGraphDeclaration(string id, bool strict, bool quoteId);
    }
}
