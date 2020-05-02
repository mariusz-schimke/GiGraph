using Dotless.Core;
using Dotless.GraphElements;
using System.Collections.Generic;

namespace Dotless.Graphs
{
    public class DotGraph : IDotEntity
    {
        public string? Name { get; set; }
        public bool IsDirected { get; set; }
        public bool IsStrict { get; set; }

        public List<DotGraphNode> Nodes { get; } = new List<DotGraphNode>();
        public DotGraphAttributes Attributes { get; } = new DotGraphAttributes();
    }
}
