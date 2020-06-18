﻿using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.Providers;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotAttributeGenerator : DotAttributeGenerator<DotAttribute>
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }
    }
}