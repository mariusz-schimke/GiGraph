﻿using System.Linq;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Subgraphs
{
    public class DotSubgraphCollectionGenerator<TSubgraph> : DotEntityGenerator<DotCommonGraphCollection<TSubgraph>, IDotSubgraphWriterRoot>
        where TSubgraph : IDotCommonGraph, IDotAnnotatable
    {
        public DotSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotCommonGraphCollection<TSubgraph> subgraphs, IDotSubgraphWriterRoot writer)
        {
            var orderedSubgraphs = _options.SortElements
                ? subgraphs.Cast<IDotOrderable>()
                   .OrderBy(subgraph => subgraph.OrderingKey)
                   .Cast<TSubgraph>()
                : subgraphs;

            foreach (var subgraph in orderedSubgraphs)
            {
                WriteSubgraph(subgraph, writer);
            }
        }

        protected virtual void WriteSubgraph(TSubgraph subgraph, IDotSubgraphWriterRoot writer)
        {
            var subgraphWriter = writer.BeginSubgraph(_options.Subgraphs.PreferExplicitDeclaration);
            _entityGenerators.GetForEntity<IDotSubgraphWriter>(subgraph).Generate(subgraph, subgraphWriter);
            writer.EndSubgraph();
        }
    }
}