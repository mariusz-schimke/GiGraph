using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.GraphWriters;

namespace GiGraph.Dot.Generators.GraphGenerators
{
    public abstract class DotCommonGraphGenerator<TGraph, TWriter> : DotEntityGenerator<TGraph, TWriter>
        where TGraph : DotCommonGraph
        where TWriter : IDotEntityWriter
    {
        protected DotCommonGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper ?? TextEscapingPipeline.CreateForGraphId())
        {
        }

        public DotCommonGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null)
        {
        }

        protected virtual void WriteBody(DotCommonGraph graphBody, IDotCommonGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Generate(graphBody, bodyWriter);
            writer.EndBody();
        }
    }
}
