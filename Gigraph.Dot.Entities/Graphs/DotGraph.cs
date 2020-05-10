namespace Gigraph.Dot.Entities.Graphs
{
    public class DotGraph : DotGraphBody
    {
        /// <summary>
        /// Gets or sets the identifier of the graph. Set null if no identifier should be used.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value that determines if the graph is directed.
        /// The edges of directed graphs are presented as arrows, whereas edges in undirected graphs are presented as lines.
        /// </summary>
        public bool IsDirected { get; set; }

        /// <summary>
        /// Gets or sets a value that determines if the graph is strict.
        /// Strict graph forbids the creation of multi-edges, i.e., there can be at most one edge with a given tail node and head node in the directed case.
        /// </summary>
        public bool IsStrict { get; set; }

        protected DotGraph()
        {
        }

        /// <summary>
        /// Creates a new graph instance.
        /// </summary>
        /// <param name="id">The identifier of the graph. Pass null if no identifier should be used.</param>
        /// <param name="isDirected">Determines if the graph should be directed.
        /// The edges of directed graphs are presented as arrows, whereas edges in undirected graphs are presented as lines.</param>
        /// <param name="isStrict">Determines if the graph is strict.
        /// Strict graph forbids the creation of multi-edges, i.e., there can be at most one edge with a given tail node and head node in the directed case.</param>
        public DotGraph(string id = null, bool isDirected = true, bool isStrict = false)
        {
            Id = id;
            IsDirected = isDirected;
            IsStrict = isStrict;
        }
    }
}
