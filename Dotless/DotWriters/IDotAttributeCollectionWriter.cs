namespace Dotless.DotWriters
{
    public interface IDotAttributeCollectionWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}