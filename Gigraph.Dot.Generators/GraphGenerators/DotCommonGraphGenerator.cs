using Gigraph.Dot.Core;
using Gigraph.Dot.Core.TextEscaping;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.GraphWriters;

namespace Gigraph.Dot.Generators.GraphGenerators
{
    public abstract class DotCommonGraphGenerator<TGraph, TWriter> : DotEntityGenerator<TGraph, TWriter>
        where TGraph : DotCommonGraph
        where TWriter : IDotEntityWriter
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();

        public DotCommonGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual string EscapeGraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        protected virtual void WriteBody(DotCommonGraph graphBody, IDotCommonGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Generate(graphBody, bodyWriter);
            writer.EndBody();
        }
    }
}
