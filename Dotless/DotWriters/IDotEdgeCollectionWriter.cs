namespace Dotless.DotWriters
{
    public interface IDotEdgeCollectionWriter : IDotEntityWriter
    {
        IDotEdgeWriter BeginEdge();
        void EndEdge();
    }
}
