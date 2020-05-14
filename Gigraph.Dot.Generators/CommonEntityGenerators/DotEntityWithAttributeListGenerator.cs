using Gigraph.Dot.Core;
using Gigraph.Dot.Entities;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.CommonEntityGenerators
{
    public abstract class DotEntityWithAttributeListGenerator<TEntity, TWriter> : DotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotEntityWithAttributeListWriter
    {
        public DotEntityWithAttributeListGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotEntityWithAttributeListWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
                _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndAttributeList();
            }
        }
    }
}
