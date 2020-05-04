namespace Dotless.DotWriters
{
    public interface IDotNodeCollectionWriter : IDotWriter
    {
        IDotNodeWriter BeginNode();
        void EndNode();
    }
}
