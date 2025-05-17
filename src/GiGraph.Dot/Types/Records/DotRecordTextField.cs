using System.Text;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

/// <summary>
///     Represents a textual field of a record (<see cref="DotRecord"/>). A record can be used as the label of a
///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
///         record-shaped node
///     </see>
///     .
/// </summary>
public class DotRecordTextField : DotRecordField
{
    /// <summary>
    ///     Creates a new instance of a textual record field.
    /// </summary>
    /// <param name="text">
    ///     The text of the field.
    /// </param>
    /// <param name="portName">
    ///     The port name, that is a name that can be referred to from an edge's endpoint in order to attach the end of the edge to the
    ///     current field. You can specify the port on an edge's head or tail endpoint, or, alternatively, by using a corresponding
    ///     attribute for the head or tail among the attributes of the edge.
    /// </param>
    public DotRecordTextField(DotEscapeString? text, string? portName = null)
    {
        Text = text;
        PortName = portName;
    }

    /// <summary>
    ///     The text of the field.
    /// </summary>
    public DotEscapeString? Text { get; }

    /// <summary>
    ///     The port name, that is a name that can be referred to from an edge's endpoint in order to attach the end of the edge to the
    ///     current field. You can specify the port on an edge's head or tail endpoint, or, alternatively, by using a corresponding
    ///     attribute for the head or tail among the attributes of the edge.
    /// </summary>
    public string? PortName { get; }

    protected internal override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules, bool hasParent)
    {
        var result = new StringBuilder();
        var separator = string.Empty;

        if (PortName is not null)
        {
            result.Append('<');
            result.Append(syntaxRules.Attributes.RecordLabelValuePortEscaper.Escape(PortName));
            result.Append('>');
            separator = " ";
        }

        if (Text is not null)
        {
            result.Append(separator);
            result.Append(Text.GetEscapedString(syntaxRules.Attributes.RecordLabelValueFieldEscaper));
        }

        return result.ToString();
    }
}