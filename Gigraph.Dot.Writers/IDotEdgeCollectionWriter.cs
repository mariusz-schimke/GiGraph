namespace Gigraph.Dot.Writers
{
    public interface IDotEdgeCollectionWriter : IDotEntityWriter
    {
        IDotEdgeWriter BeginEdge();
        void EndEdge();
    }
}
