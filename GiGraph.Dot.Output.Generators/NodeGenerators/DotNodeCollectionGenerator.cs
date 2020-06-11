﻿using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.NodeWriters;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Generators.NodeGenerators
{
    public class DotNodeCollectionGenerator : DotEntityGenerator<DotNodeCollection, IDotNodeStatementWriter>
    {
        protected DotNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNodeCollection nodes, IDotNodeStatementWriter writer)
        {
            var orderedNodes = _options.OrderElements
                ? nodes.Cast<IDotOrderableEntity>()
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
            var nodeWriter = writer.BeginNode();
            _entityGenerators.GetForEntity<IDotNodeWriter>(node).Generate(node, nodeWriter);
            writer.EndNode();
        }
    }
}
