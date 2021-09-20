using System.Text;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records
{
    /// <summary>
    ///     Represents a textual field of a record (<see cref="DotRecord" />). A record can be used as the label of a
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
    ///         record-shaped node
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="Text">
    ///     The text of the field.
    /// </param>
    /// <param name="PortName">
    ///     The port name, that is a name that can be referred to from an edge's endpoint in order to attach the end of the edge to the
    ///     current field. You can specify the port on an edge's head or tail endpoint, or, alternatively, by using a corresponding
    ///     attribute for the head or tail among the attributes of the edge.
    /// </param>
    public record DotRecordTextField(DotEscapeString Text, string PortName = null) : DotRecordField
    {
        protected internal override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules, bool hasParent)
        {
            var result = new StringBuilder();
            var separator = string.Empty;

            if (PortName is not null)
            {
                result.Append("<");
                result.Append(syntaxRules.Attributes.RecordLabelValuePortEscaper.Escape(PortName));
                result.Append(">");
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
}