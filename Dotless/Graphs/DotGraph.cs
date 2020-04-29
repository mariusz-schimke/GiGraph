using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.Generators;
using Dotless.GraphElements;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dotless.Graphs
{
    public class DotGraph : IDotEntity
    {
        public string? Name { get; set; }
        public bool IsDirected { get; set; }
        public bool IsStrict { get; set; }

        public List<DotGraphNode> Nodes { get; } = new List<DotGraphNode>();
        public DotAttributeCollection Attributes { get; } = new DotAttributeCollection();

        public string ToString(DotTokenWriterOptions options)
        {
            var result = new StringBuilder();
            var tokens = DotGraphGenerator.CreateDefault().Generate(this);

            new DotTokenWriter(tokens).Write(result, options);
            return result.ToString();
        }

        public override string ToString()
        {
            return ToString(new DotTokenWriterOptions());
        }

        public void WriteToFile(string filePath, DotTokenWriterOptions? options = null)
        {
            File.WriteAllText(filePath, ToString(options!));
        }

        public void WriteToFile(string filePath, Encoding encoding, DotTokenWriterOptions? options = null)
        {
            File.WriteAllText(filePath, ToString(options!), encoding);
        }
    }
}
