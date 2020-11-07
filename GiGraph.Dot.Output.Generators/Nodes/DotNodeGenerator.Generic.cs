using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Nodes;

namespace GiGraph.Dot.Output.Generators.Nodes
{
    public abstract class DotNodeGenerator<TEntity> : DotEntityWithAttributeListGenerator<TEntity, IDotNodeWriter>
        where TEntity : DotNodeDefinition
    {
        protected DotNodeGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual void WriteIdentifier(string id, IDotNodeWriter writer)
        {
            id = EscapeIdentifier(id);
            writer.WriteNodeIdentifier(id, IdentifierRequiresQuoting(id));
        }
    }
}