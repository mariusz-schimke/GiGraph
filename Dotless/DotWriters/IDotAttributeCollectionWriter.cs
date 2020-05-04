namespace Dotless.DotWriters
{
    public interface IDotAttributeCollectionWriter : IDotWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}