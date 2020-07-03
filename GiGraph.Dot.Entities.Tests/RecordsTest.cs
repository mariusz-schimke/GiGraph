using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class RecordsTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void embedded_record_returns_fields_in_single_brackets_as_dot_encoded_value()
        {
            var rec = new DotRecord(
                flip: true,
                "root field1",
                "root field2",
                new DotRecord(flip: false, "sub-field1", "sub-field2"));

            Assert.Equal(
                "{ root&#32;field1 | root&#32;field2 | { sub-field1 | sub-field2 } }",
                ((IDotEncodable) rec).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void flipped_embedded_record_returns_fields_in_double_brackets_as_dot_encoded_value()
        {
            var rec = new DotRecord(
                flip: false,
                "root field1",
                "root field2",
                new DotRecord(flip: true, "sub-field1", "sub-field2"));

            Assert.Equal(
                "root&#32;field1 | root&#32;field2 | { { sub-field1 | sub-field2 } }",
                ((IDotEncodable) rec).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void flipped_record_returns_fields_in_brackets_as_dot_encoded_value()
        {
            var rec = new DotRecord(flip: true, "field1", "field2");

            Assert.Equal("{ field1 | field2 }", ((IDotEncodable) rec).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void record_returns_fields_as_dot_encoded_value()
        {
            var rec = new DotRecord(flip: false, "field1", "field2");

            Assert.Equal("field1 | field2", ((IDotEncodable) rec).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void record_with_ports_returns_ports_and_fields_as_dot_encoded_value()
        {
            var rec = new DotRecord(flip: false, new DotRecordTextField("field1", "port 1"), "field2");

            Assert.Equal("<port&#32;1> field1 | field2", ((IDotEncodable) rec).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }
    }
}