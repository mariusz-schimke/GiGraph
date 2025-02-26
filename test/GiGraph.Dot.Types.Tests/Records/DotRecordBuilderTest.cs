using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Records;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Records;

public class DotRecordBuilderTest
{
    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void record_builder_composes_an_expected_record_representation_with_fields_and_subrecords()
    {
        var builder = new DotRecordBuilder()
            .AppendField("Field_1.1")
            .AppendField("Field_1.2", "Field_1.2Port")
            .AppendFields(["Field_1.3", "Field_1.4"])
            .AppendFields("Field_1.5", "Field_1.6")
            .AppendFields((IEnumerable<DotEscapeString>) ["Field_1.7", "Field_1.8"])
            .AppendFields((IEnumerable<DotRecordField>) ["Field_1.9", "Field_1.10"])
            .AppendFields(new DotRecordTextField("Field_1.11"), new DotRecordTextField("Field_1.12"))
            .AppendSubrecord(["Field_1.13.1", "Field_1.13.2"])
            .AppendSubrecord("Field_1.14.1", "Field_1.14.2")
            .AppendSubrecord((IEnumerable<DotEscapeString>) ["Field_1.15.1", "Field_1.15.2"])
            .AppendSubrecord((IEnumerable<DotRecordField>) ["Field_1.16.1", "Field_1.16.2"])
            .AppendSubrecord(new DotRecordTextField("Field_1.17.1"), new DotRecordTextField("Field_1.17.2"))
            .AppendSubrecord(rb1 => rb1
                .AppendField(tf => tf.AppendLeftJustifiedLine("Field_1.18.1"))
                .AppendSubrecord(rb2 => rb2
                    .AppendFields("Field_1.18.2.1", "Field_1.18.2.2")
                )
            )
            .AppendSubrecord(new DotRecord("Field_1.13.1", "Field_1.13.2"));

        var dotEncoded = ((IDotEncodable) builder.Build()).GetDotEncodedValue(_syntaxOptions, _syntaxRules);
        Snapshot.Match(dotEncoded, "record_builder_output_with_fields_and_subrecords");
    }

    [Fact]
    public void record_builder_composes_an_expected_record_representation_with_fields_and_unflipped_subrecords()
    {
        var builder = new DotRecordBuilder()
            .AppendField("Field_1.1")
            .AppendField("Field_1.2", "Field_1.2Port")
            .AppendFields(["Field_1.3", "Field_1.4"])
            .AppendFields("Field_1.5", "Field_1.6")
            .AppendFields((IEnumerable<DotEscapeString>) ["Field_1.7", "Field_1.8"])
            .AppendFields((IEnumerable<DotRecordField>) ["Field_1.9", "Field_1.10"])
            .AppendFields(new DotRecordTextField("Field_1.11"), new DotRecordTextField("Field_1.12"))
            .AppendUnflippedSubrecord(["Field_1.13.1", "Field_1.13.2"])
            .AppendUnflippedSubrecord("Field_1.14.1", "Field_1.14.2")
            .AppendUnflippedSubrecord((IEnumerable<DotEscapeString>) ["Field_1.15.1", "Field_1.15.2"])
            .AppendUnflippedSubrecord((IEnumerable<DotRecordField>) ["Field_1.16.1", "Field_1.16.2"])
            .AppendUnflippedSubrecord(new DotRecordTextField("Field_1.17.1"), new DotRecordTextField("Field_1.17.2"))
            .AppendUnflippedSubrecord(rb1 => rb1
                .AppendField(tf => tf.AppendLeftJustifiedLine("Field_1.18.1"))
                .AppendUnflippedSubrecord(rb2 => rb2
                    .AppendFields("Field_1.18.2.1", "Field_1.18.2.2")
                )
            );

        var dotEncoded = ((IDotEncodable) builder.Build()).GetDotEncodedValue(_syntaxOptions, _syntaxRules);
        Snapshot.Match(dotEncoded, "record_builder_output_with_fields_and_unflipped_subrecords");
    }
}