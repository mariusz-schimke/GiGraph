﻿using System.Linq;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Nodes;

namespace GiGraph.Dot.Output.Generators.Nodes
{
    public class DotNodeCollectionGenerator : DotEntityGenerator<DotNodeCollection, IDotNodeStatementWriter>
    {
        public DotNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotNodeCollection nodes, IDotNodeStatementWriter writer)
        {
            var orderedNodes = _options.SortElements
                ? nodes.Cast<IDotOrderable>()
                   .OrderBy(node => node.OrderingKey)
                   .Cast<DotNodeDefinition>()
                : nodes;

            foreach (var node in orderedNodes)
            {
                WriteNode(node, writer);
            }
        }

        protected virtual void WriteNode(DotNodeDefinition node, IDotNodeStatementWriter writer)
        {
            var nodeWriter = writer.BeginNodeStatement();
            _entityGenerators.GetForEntity<IDotNodeWriter>(node).Generate(node, nodeWriter);
            writer.EndNodeStatement();
        }
    }
}