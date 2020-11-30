using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Graphs;

namespace GiGraph.Dot.Output.Generators.Graphs
{
    public class DotGraphGenerator : DotCommonGraphGenerator<DotGraph, IDotGraphWriterRoot>
    {
        public DotGraphGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotGraph graph, IDotGraphWriterRoot writerRoot)
        {
            var writer = writerRoot.BeginGraph(graph.IsDirected);

            WriteDeclaration(graph.Id, graph.IsStrict, writer);
            WriteBody(graph, writer);

            writerRoot.EndGraph();
        }

        protected virtual void WriteDeclaration(string id, bool strict, IDotGraphWriter writer)
        {
            id = EscapeIdentifier(id);

            // whether the graph and its edges will be directed, is decided by the writer instance
            writer.WriteGraphDeclaration
            (
                id,
                strict,
                quoteId: IdentifierRequiresQuoting(id)
            );
        }
    }
}