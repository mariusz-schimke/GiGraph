using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers;
using GiGraph.Dot.Output.Writers.Graphs;

namespace GiGraph.Dot.Output.Generators.Graphs
{
    public abstract class DotCommonGraphGenerator<TGraph, TGraphAttributes, TWriter> : DotEntityGenerator<TGraph, TWriter>
        where TGraph : DotCommonGraph<TGraphAttributes>
        where TGraphAttributes : IDotAttributeCollection
        where TWriter : IDotEntityWriter
    {
        protected DotCommonGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual void WriteBody(TGraph graphBody, IDotCommonGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();

            // the annotation of the root section is written above graph/subgraph/cluster declaration by another generator
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Generate(graphBody, bodyWriter, annotate: false);

            foreach (var subsection in graphBody.Subsections)
            {
                _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Generate(subsection, bodyWriter);
            }

            writer.EndBody();
        }
    }
}