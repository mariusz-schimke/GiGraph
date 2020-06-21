namespace GiGraph.Dot.Entities
{
    public interface IDotEntity
    {
        /// <summary>
        /// The comment notes to write next to the element in the output DOT script.
        /// </summary>
        public string Notes { get; set; }
    }
}