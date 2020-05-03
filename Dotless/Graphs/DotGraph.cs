using Dotless.Core;
using Dotless.Nodes;

namespace Dotless.Graphs
{
    public class DotGraph : IDotEntity
    {
        public string? Name { get; set; }
        public bool IsDirected { get; set; }
        public bool IsStrict { get; set; }

        public DotGraphNodes Nodes { get; } = new DotGraphNodes();
        public DotGraphAttributes Attributes { get; } = new DotGraphAttributes();
    }
}
