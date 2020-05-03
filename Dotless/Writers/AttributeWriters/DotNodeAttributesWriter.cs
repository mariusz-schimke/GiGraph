﻿using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Writers.Options;
using System.Linq;

namespace Dotless.Writers.AttributeWriters
{
    /// <summary>
    /// Writes a list of node attributes.
    /// </summary>
    public class DotNodeAttributesWriter : DotEntityWriter<DotNodeAttributes>
    {
        public DotNodeAttributesWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override bool Write(DotNodeAttributes attributes, DotStringWriter writer)
        {
            if (!attributes.Any())
            {
                return false;
            }

            var context = writer.AssertContext<DotStringWriter.AttributesContext>();

            foreach (var attribute in attributes)
            {
                _entityGenerators.GetForTypeOrForAnyBaseType(attribute).Write(attribute, context);
            }

            return true;
        }
    }
}
