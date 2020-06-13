using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.AttributeWriters;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using System.Linq;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Generators.CommonEntityGenerators
{
    public abstract class DotEntityWithAttributeListGenerator<TEntity, TWriter> : DotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotEntityWithAttributeListWriter
    {
        protected DotEntityWithAttributeListGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotEntityWithAttributeListGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual void WriteAttributes(IDotAttributeCollection attributes, IDotEntityWithAttributeListWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
                _entityGenerators.GetForEntity<IDotAttributeListItemWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndAttributeList();
            }
        }
    }
}
