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
        ///     current field. You can specify the port on an edge's head or tail endpoint, or, alternatively, by using a corresponding
        ///     attribute for the head or tail among the attributes of the edge.
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
        ///     edge to the current field. You can specify the port on an edge's head or tail endpoint, or, alternatively, by using a
        ///     corresponding attribute for the head or tail among the attributes of the edge.
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

            if (_portName is not null)
            {
                result.Append("<");
                result.Append(_portName.GetEscapedString(syntaxRules.Attributes.RecordLabelValuePortEscaper));
                result.Append(">");
                separator = " ";
            }

            if (_text is not null)
            {
                result.Append(separator);
                result.Append(_text.GetEscapedString(syntaxRules.Attributes.RecordLabelValueFieldEscaper));
            }

            return result.ToString();
        }
    }
}