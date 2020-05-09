namespace Gigraph.Dot.Writers
{
    public interface IDotAttributeCollectionWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}