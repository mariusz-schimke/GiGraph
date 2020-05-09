namespace Gigraph.Dot.Entities.Graphs
{
    public class DotGraph : DotGraphBody
    {
        public string Id { get; set; }
        public bool IsDirected { get; set; }
        public bool IsStrict { get; set; }
    }
}
