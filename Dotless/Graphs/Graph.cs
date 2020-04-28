using Dotless.DotBuilders;
using Dotless.Generators;
using Dotless.GraphElements;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dotless.Graphs
{
    public class Graph : GraphElement
    {
        public string? Name { get; set; }
        public bool IsDirected { get; set; }
        public bool IsStrict { get; set; }

        public List<GraphNode> Nodes { get; } = new List<GraphNode>();

        public string ToString(TokenWriterOptions options)
        {
            var result = new StringBuilder();
            var tokens = GraphGenerator.CreateDefault().Generate(this);

            new TokenWriter(tokens).Write(result, options);
            return result.ToString();
        }

        public override string ToString()
        {
            return ToString(new TokenWriterOptions());
        }

        public void WriteToFile(string filePath, TokenWriterOptions? options = null)
        {
            File.WriteAllText(filePath, ToString(options!));
        }

        public void WriteToFile(string filePath, Encoding encoding, TokenWriterOptions? options = null)
        {
            File.WriteAllText(filePath, ToString(options!), encoding);
        }
    }
}
