using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Writers;
using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Generators
{
    public abstract class DotEntityWithAttributeListGenerator<TEntity, TWriter> : DotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity, IDotAnnotatable
        where TWriter : IDotEntityWithAttributeListWriter
    {
        protected DotEntityWithAttributeListGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotEntityWithAttributeListWriter writer, bool annotate = true)
        {
            if (attributes.Any())
            {
                var attributeListItemWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
                _entityGenerators.GetForEntity<IDotAttributeListItemWriter>(attributes).Generate(attributes, attributeListItemWriter, annotate);
                writer.EndAttributeList();
            }
        }
    }
}