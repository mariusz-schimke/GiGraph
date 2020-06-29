using System.Text;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Records
{
    /// <summary>
    /// Represents a textual field of a record (<see cref="DotRecord"/>).
    /// A record can be used as the label of a <see href="http://www.graphviz.org/doc/info/shapes.html#record">record-based node</see>. 
    /// </summary>
    public class DotRecordTextField : DotRecordField
    {
        protected DotEscapableRecordFieldString _text;
        protected DotEscapableRecordFieldString _portName;

        /// <summary>
        /// Gets or sets the text of the field.
        /// </summary>
        public virtual string Text
        {
            get => _text;
            set => _text = value;
        }

        /// <summary>
        /// Gets or sets a port name, that is a name that can be referred to from an edge endpoint in order to attach
        /// the end of the edge to the current field. See <see cref="DotEndpoint.Port"/> or
        /// <see cref="IDotEdgeAttributes.TailPort"/> and <see cref="IDotEdgeAttributes.HeadPort"/>.
        /// </summary>
        public virtual string PortName
        {
            get => _portName;
            set => _portName = value;
        }

        /// <summary>
        /// Creates a new text field instance.
        /// </summary>
        /// <param name="text">The text to initialize the field with.</param>
        /// <param name="portName">The port name, that is a name that can be referred to from an edge endpoint
        /// in order to attach the end of the edge to the current field. See <see cref="DotEndpoint.Port"/> or
        /// <see cref="IDotEdgeAttributes.TailPort"/> and <see cref="IDotEdgeAttributes.HeadPort"/>.</param>
        public DotRecordTextField(string text, string portName = null)
        {
            _text = text;
            _portName = portName;
        }

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules, bool hasParent)
        {
            var result = new StringBuilder();
            var separator = string.Empty;

            if (_portName is {})
            {
                result.Append("<");
                result.Append(_portName.GetDotEncodedString(options, syntaxRules));
                result.Append(">");
                separator = " ";
            }

            if (_text is {})
            {
                result.Append(separator);
                result.Append(_text.GetDotEncodedString(options, syntaxRules));
            }

            return result.ToString();
        }

        public static implicit operator DotRecordTextField(string text)
        {
            return new DotRecordTextField(text);
        }
    }
}