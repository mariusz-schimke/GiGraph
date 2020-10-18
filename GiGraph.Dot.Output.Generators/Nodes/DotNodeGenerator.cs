using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Nodes;

namespace GiGraph.Dot.Output.Generators.Nodes
{
    public class DotNodeGenerator : DotNodeGenerator<DotNode>
    {
        public DotNodeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotNode node, IDotNodeWriter writer)
        {
            WriteIdentifier(node.Id, writer);
            WriteAttributes(node.Attributes.Collection, writer);
        }
    }
}