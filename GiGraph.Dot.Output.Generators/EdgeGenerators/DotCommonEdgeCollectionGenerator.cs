using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;

namespace GiGraph.Dot.Output.Generators.EdgeGenerators
{
    public class DotCommonEdgeCollectionGenerator : DotEntityGenerator<DotCommonEdgeCollection, IDotEdgeStatementWriter>
    {
        protected DotCommonEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonEdgeCollection edges, IDotEdgeStatementWriter writer)
        {
            var orderedEdges = _options.OrderElements
                ? edges.Cast<IDotOrderableEntity>()
                       .OrderBy(edge => edge.OrderingKey)
                       .Cast<DotCommonEdge>()
                : edges;

            foreach (var edge in orderedEdges.Where(edge => edge.Endpoints.Any()))
            {
                WriteEdge(edge, writer);
            }
        }

        protected virtual void WriteEdge(DotCommonEdge edge, IDotEdgeStatementWriter writer)
        {
            var edgeWriter = writer.BeginSequence();
            _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Generate(edge, edgeWriter);
            writer.EndSequence();
        }
    }
}
