using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Nodes;

namespace GiGraph.Dot.Output.Generators.Nodes;

public class DotNodeGroupGenerator : DotNodeGenerator<DotNodeGroup>
{
    public DotNodeGroupGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(DotNodeGroup nodeGroup, IDotNodeWriter writer)
    {
        WriteIdentifiers(nodeGroup.Ids, writer);
        WriteAttributes(nodeGroup.Attributes.Collection, writer);
    }

    protected virtual void WriteIdentifiers(string[] nodeIds, IDotNodeWriter writer)
    {
        if (nodeIds.Length == 0)
        {
            throw new ArgumentException("At least one node identifier has to be specified for a node group.", nameof(nodeIds));
        }

        IEnumerable<string> orderedNodeIds = _options.SortElements
            ? nodeIds.OrderBy(nodeId => nodeId, StringComparer.InvariantCulture)
            : nodeIds;

        foreach (var nodeId in orderedNodeIds)
        {
            WriteIdentifier(nodeId, writer);
        }
    }
}