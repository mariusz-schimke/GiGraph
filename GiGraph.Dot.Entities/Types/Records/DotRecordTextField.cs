using System.Text;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Records
{
    /// <summary>
    ///     Represents a textual field of a record (<see cref="DotRecord" />). A record can be used as the label of a
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
    ///         record-based node
    ///     </see>
    ///     .
    /// </summary>
    public class DotRecordTextField : DotRecordField
    {
        protected DotEscapeString _portName;
        protected DotEscapeString _text;

        /// <summary>
        ///     Creates a new text field instance.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the field with.
        /// </param>
        /// <param name="portName">
        ///     The port name, that is a name that can be referred to from an edge's endpoint in order to attach the end of the edge to the
        ///     current field. You can use the <see cref="DotEndpoint.Port" /> property on the <see cref="DotEdge{TTail,THead}.Tail" /> or
        ///     the <see cref="DotEdge{TTail,THead}.Head" /> endpoint of a <see cref="DotEdge" />, or, alternatively, the
        ///     <see cref="DotEdgeEndpointAttributes.Port" /> property on its <see cref="DotEdgeAttributes.Head" /> or
        ///     <see cref="DotEdgeAttributes.Tail" /> attributes.
        /// </param>
        public DotRecordTextField(DotEscapeString text, string portName = null)
        {
            _text = text;
            _portName = portName;
        }

        /// <summary>
        ///     Gets or sets the text of the field.
        /// </summary>
        public virtual DotEscapeString Text
        {
            get => _text;
            set => _text = value;
        }

        /// <summary>
        ///     Gets or sets a port name, that is a name that can be referred to from an edge's endpoint in order to attach the end of the
        ///     edge to the current field. You can use the <see cref="DotEndpoint.Port" /> property on the
        ///     <see cref="DotEdge{TTail,THead}.Tail" /> or the <see cref="DotEdge{TTail,THead}.Head" /> endpoint of a <see cref="DotEdge" />
        ///     , or, alternatively, the <see cref="DotEdgeEndpointAttributes.Port" /> property on its <see cref="DotEdgeAttributes.Head" />
        ///     or <see cref="DotEdgeAttributes.Tail" /> attributes.
        /// </summary>
        public virtual string PortName
        {
            get => _portName;
            set => _portName = value;
        }

        protected internal override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules, bool hasParent)
        {
            var result = new StringBuilder();
            var separator = string.Empty;

            if (_portName is {})
            {
                result.Append("<");
                result.Append(_portName.GetEscapedString(syntaxRules.RecordFieldEscaper));
                result.Append(">");
                separator = " ";
            }

            if (_text is {})
            {
                result.Append(separator);
                result.Append(_text.GetEscapedString(syntaxRules.RecordFieldEscaper));
            }

            return result.ToString();
        }

        public static implicit operator DotRecordTextField(string text)
        {
            return new DotRecordTextField(text);
        }

        public static implicit operator DotRecordTextField(DotEscapeString text)
        {
            return new DotRecordTextField(text);
        }
    }
}