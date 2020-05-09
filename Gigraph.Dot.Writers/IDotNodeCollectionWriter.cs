namespace Gigraph.Dot.Writers
{
    public interface IDotNodeCollectionWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNode();
        void EndNode();
    }
}
