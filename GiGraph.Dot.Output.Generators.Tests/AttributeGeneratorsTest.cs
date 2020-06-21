using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Output.Generators.GraphGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Tests
{
    public class AttributeGeneratorsTest
    {
        private DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void record_returns_fields_as_dot_encoded_value()
        {
            var attr = new DotLabelAttribute("label", "string value");
            // var generatorsProviderBuilder = new DotEntityGeneratorsProviderBuilder();
            // var graphGeneratorBuilder = new DotGraphGeneratorBuilder(generatorsProviderBuilder);

            Assert.Equal("field1 | field2", ((IDotEncodableValue) rec).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }
    }
}