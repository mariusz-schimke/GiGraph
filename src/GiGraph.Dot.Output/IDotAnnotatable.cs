namespace GiGraph.Dot.Output
{
    public interface IDotAnnotatable
    {
        /// <summary>
        ///     The annotation to write in the output DOT script as a comment in the context of the element or section represented by the
        ///     current object.
        /// </summary>
        public string Annotation { get; set; }
    }
}