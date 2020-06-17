using System.Text;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Records
{
    /// <summary>
    /// Represents a textual field of a record (<see cref="DotRecord"/>).
    /// A record can be used as the label of a record-based node (<see href="http://www.graphviz.org/doc/info/shapes.html#record"/>). 
    /// </summary>
    public class DotRecordTextField : DotRecordField
    {
        protected readonly IDotTextEscaper _textEscaper;

        /// <summary>
        /// Gets or sets the text of the field.
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// Gets or sets a port name, that is a name that can be referred to from an edge endpoint in order to attach
        /// the end of the edge to the current field. See <see cref="DotEndpoint.Port"/> or
        /// <see cref="IDotEdgeAttributes.TailPort"/> and <see cref="IDotEdgeAttributes.HeadPort"/>.
        /// </summary>
        public virtual string PortName { get; set; }

        protected DotRecordTextField(string text, string portName, IDotTextEscaper textEscaper)
        {
            _textEscaper = textEscaper;
            Text = text;
            PortName = portName;
        }

        /// <summary>
        /// Creates a new text field instance.
        /// </summary>
        /// <param name="text">The text to initialize the field with.</param>
        /// <param name="portName">The port name, that is a name that can be referred to from an edge endpoint
        /// in order to attach the end of the edge to the current field. See <see cref="DotEndpoint.Port"/> or
        /// <see cref="IDotEdgeAttributes.TailPort"/> and <see cref="IDotEdgeAttributes.HeadPort"/>.</param>
        public DotRecordTextField(string text, string portName = null)
            : this(text, portName, DotTextEscapingPipeline.ForRecordNodeField())
        {
        }

        protected internal override string GetDotEncoded(DotGenerationOptions options, bool hasParent)
        {
            var result = new StringBuilder();
            var separator = string.Empty;

            if (PortName is {})
            {
                result.Append("<");
                result.Append(_textEscaper.Escape(PortName));
                result.Append(">");
                separator = " ";
            }

            result.Append(separator);
            result.Append(_textEscaper.Escape(Text));

            return result.ToString();
        }

        public static implicit operator DotRecordTextField(string text)
        {
            return new DotRecordTextField(text);
        }
    }
}