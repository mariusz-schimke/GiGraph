using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Core;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.AttributeWriters;
using GiGraph.Dot.Writers.CommonEntityWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.CommonEntityGenerators
{
    public abstract class DotEntityWithAttributeListGenerator<TEntity, TWriter> : DotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotEntityWithAttributeListWriter
    {
        public DotEntityWithAttributeListGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual void WriteAttributes(IDotAttributeCollection attributes, IDotEntityWithAttributeListWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
                _entityGenerators.GetForEntity<IDotAttributeStatementWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndAttributeList();
            }
        }
    }
}
