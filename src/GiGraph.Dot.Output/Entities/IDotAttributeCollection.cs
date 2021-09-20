namespace GiGraph.Dot.Output.Entities
{
    public interface IDotAttributeCollection : IDotEntity
    {
        /// <summary>
        ///     Checks if the collection contains any attributes.
        /// </summary>
        bool Any();
    }
}