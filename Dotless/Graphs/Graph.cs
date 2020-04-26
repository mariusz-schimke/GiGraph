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

        public string ToString(GeneratorOptions options)
        {
            return GraphGenerator.CreateDefault(options).Generate(this);
        }

        public override string ToString()
        {
            return GraphGenerator.CreateDefault().Generate(this);
        }

        public void WriteToFile(string filePath, GeneratorOptions? options = null)
        {
            File.WriteAllText(filePath, ToString(options!));
        }

        public void WriteToFile(string filePath, Encoding encoding, GeneratorOptions? options = null)
        {
            File.WriteAllText(filePath, ToString(options!), encoding);
        }
    }
}
