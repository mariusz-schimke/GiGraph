using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.CommonEntityGenerators
{
    public abstract class DotEntityDefaultsGenerator<TWriter> : DotEntityGenerator<DotAttributeCollection, TWriter>
        where TWriter : IDotEntityDefaultsWriter
    {
        public DotEntityDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotAttributeCollection defaults, TWriter writer)
        {
            WriteKeyword(defaults, writer);
            WriteAttributes(defaults, writer);
        }

        protected abstract void WriteKeyword(DotAttributeCollection defaults, TWriter writer);

        protected virtual void WriteAttributes(DotAttributeCollection defaults, TWriter writer)
        {
            var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(defaults).Generate(defaults, attributesWriter);
            writer.EndAttributeList(defaults.Count());
        }
    }
}
