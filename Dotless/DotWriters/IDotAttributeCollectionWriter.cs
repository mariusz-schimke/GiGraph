namespace Dotless.DotWriters
{
    public interface IDotAttributeCollectionWriter : IDotWriter
    {
        IDotNodeWriter BeginAttribute();
        void EndAttribute();
    }
}