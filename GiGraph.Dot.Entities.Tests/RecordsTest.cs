using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class RecordsTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new DotSyntaxOptions();
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
                "{ root\\ field1 | root\\ field2 | { sub-field1 | sub-field2 } }",
                ((IDotEncodable) rec).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
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
                "root\\ field1 | root\\ field2 | { { sub-field1 | sub-field2 } }",
                ((IDotEncodable) rec).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
        }

        [Fact]
        public void flipped_record_returns_fields_in_brackets_as_dot_encoded_value()
        {
            var rec = new DotRecord(flip: true, "field1", "field2");

            Assert.Equal("{ field1 | field2 }", ((IDotEncodable) rec).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
        }

        [Fact]
        public void record_returns_fields_as_dot_encoded_value()
        {
            var rec = new DotRecord(flip: false, "field1", "field2");

            Assert.Equal("field1 | field2", ((IDotEncodable) rec).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
        }

        [Fact]
        public void record_with_ports_returns_ports_and_fields_as_dot_encoded_value()
        {
            var rec = new DotRecord(flip: false, new DotRecordTextField("field1", "port 1"), "field2");

            Assert.Equal("<port\\ 1> field1 | field2", ((IDotEncodable) rec).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
        }

        [Fact]
        public void record_port_and_field_return_escaped_dot_encoded_value()
        {
            var value = " a \" \\ \r\n \r \n < > { } | ";
            var rec = new DotRecord(new DotRecordTextField(value, value));

            // CR LF are not replaced in port
            var port = @$"<\ a\ \""\ \\\ {"\r\n"}\ {'\r'}\ {'\n'}\ \<\ \>\ \{{\ \}}\ \|\ >";
            
            // CR LF are replaced with \n in field
            var field = @"\ a\ \""\ \\\ \n\ \n\ \n\ \<\ \>\ \{\ \}\ \|\ ";

            Assert.Equal($"{port} {field}", ((IDotEncodable) rec).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
        }
    }
}