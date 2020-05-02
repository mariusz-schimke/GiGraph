using Dotless.Attributes;
using Dotless.DotWriters.Options;
using Dotless.GraphElements;
using Dotless.Graphs;
using Dotless.Writers.Options;
using System;

namespace Dotless
{
    // TODO: przejrzec wszystkie metody, czy powinny lub nie powinny byc wirtualne
    // TODO: przejrzeć klasy, czy powinny miec interfejsy (np. TokenWriter itp.)



    internal class Program
    {
        private static void Main(string[] args)
        {
            var fo = new DotFormattingOptions
            {
                //SingleLine = true,
                //TokenSpacing = 0
            };

            var wo = new DotWriterOptions()
            {
            };

            wo.Attributes.PreferQuotedValue = false;

            var dotGraph = new DotGraph()
            {
                IsStrict = true,
                Name = "My \"awesome\" graph"
            };

            dotGraph.Nodes.Add(new DotGraphNode("my \"node")
            {
                Label = "my label"
            });

            dotGraph.Nodes.Add(new DotGraphNode("my \"node")
            {
                Label = new DotHtmlLabel("<b>text<b>")
            });

            dotGraph.Nodes.Add(new DotGraphNode("myNode")
            {
                Label = new DotTextLabel("label")
            });

            dotGraph.Nodes.Add(new DotGraphNode("myNode")
            {
                Label = new DotTextLabel("graph")
            });

            // Console.WriteLine(dotGraph.ToString(fo, fo));

            Console.ReadLine();
        }
    }
}
