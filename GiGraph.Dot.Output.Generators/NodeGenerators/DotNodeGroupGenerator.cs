using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.NodeWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Generators.Providers;

namespace GiGraph.Dot.Output.Generators.NodeGenerators
{
    public class DotNodeGroupGenerator : DotNodeGenerator<DotNodeGroup>
    {
        public DotNodeGroupGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNodeGroup nodeGroup, IDotNodeWriter writer)
        {
            WriteIdentifiers(nodeGroup.NodeIds, writer);
            WriteAttributes(nodeGroup.Attributes, writer);
        }

        protected virtual void WriteIdentifiers(IEnumerable<string> nodeIds, IDotNodeWriter writer)
        {
            if (!nodeIds.Any())
            {
                throw new ArgumentException("At least one node identifier has to be specified for a node group.", nameof(nodeIds));
            }

            var orderedNodeIds = _options.OrderElements
                ? nodeIds.OrderBy(nodeId => nodeId)
                : nodeIds;

            foreach (var nodeId in orderedNodeIds)
            {
                WriteIdentifier(nodeId, writer);
            }
        }
    }
}