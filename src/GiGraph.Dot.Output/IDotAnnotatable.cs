namespace GiGraph.Dot.Output
{
    public interface IDotAnnotatable
    {
        /// <summary>
        ///     The annotation to write next to the element in the output DOT script as a comment.
        /// </summary>
        public string Annotation { get; set; }
    }
}