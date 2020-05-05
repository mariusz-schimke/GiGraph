namespace Dotless.DotWriters
{
    public interface IDotNodeCollectionWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNode();
        void EndNode();
    }
}
