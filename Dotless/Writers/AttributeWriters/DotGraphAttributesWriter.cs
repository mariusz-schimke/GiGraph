using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Writers.Options;
using System.Linq;

namespace Dotless.Writers.AttributeWriters
{
    /// <summary>
    /// Writes a list of graph attributes.
    /// </summary>
    public class DotGraphAttributesWriter : DotEntityWriter<DotGraphAttributes>
    {
        public DotGraphAttributesWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotGraphAttributes attributes, DotStringWriter writer)
        {
            if (!attributes.Any())
            {
                return;
            }

            var context = writer
                .AssertContext<DotStringWriter.GraphContext>()
                .BeginAttributeListContext(_options.Attributes.PreferExplicitDelimiter);

            foreach (var attribute in attributes)
            {
                _entityGenerators.GetForTypeOrForAnyBaseType(attribute).Write(attribute, context);
            }

            context.EndContext();
        }
    }
}
