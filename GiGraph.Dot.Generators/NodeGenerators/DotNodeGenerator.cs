﻿using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.NodeWriters;

namespace GiGraph.Dot.Generators.NodeGenerators
{
    public class DotNodeGenerator : DotEntityWithAttributeListGenerator<DotNode, IDotNodeWriter>
    {
        protected DotNodeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotNodeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNode node, IDotNodeWriter writer)
        {
            WriteIdentifier(node.Id, writer);
            WriteAttributes(node.Attributes, writer);
        }

        protected virtual void WriteIdentifier(string id, IDotNodeWriter writer)
        {
            id = EscapeIdentifier(id);
            writer.WriteNodeIdentifier(id, IdentifierRequiresQuoting(id));
        }
    }
}
