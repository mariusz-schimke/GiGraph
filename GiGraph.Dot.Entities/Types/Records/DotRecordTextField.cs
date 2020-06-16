using System.Text;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Records
{
    public class DotRecordTextField : DotRecordField
    {
        protected readonly IDotTextEscaper _textEscaper;

        public string Text { get; set; }
        public string PortName { get; set; }

        protected DotRecordTextField(string text, string portName, IDotTextEscaper textEscaper)
        {
            _textEscaper = textEscaper;
            Text = text;
            PortName = portName;
        }

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