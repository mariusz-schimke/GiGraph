﻿using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers;
using GiGraph.Dot.Output.Writers.Graphs;

namespace GiGraph.Dot.Output.Generators.Graphs
{
    public abstract class DotCommonGraphGenerator<TGraph, TWriter> : DotEntityGenerator<TGraph, TWriter>
        where TGraph : DotCommonGraph
        where TWriter : IDotEntityWriter
    {
        protected DotCommonGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual void WriteBody(DotCommonGraph graphBody, IDotCommonGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Generate(graphBody, bodyWriter, annotate: false);
            writer.EndBody();
        }
    }
}