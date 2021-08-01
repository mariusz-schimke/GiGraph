using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Writers.Options
{
    public class DotTokenWriterOptions
    {
        public DotTokenWriterOptions(
            int indentationLevel,
            int indentationSize,
            char indentationChar,
            string lineBreak,
            bool singleLine,
            bool hashForSingleLineComments,
            Func<string, DotTokenType, string> textEncoder)
        {
            IndentationLevel = indentationLevel;
            IndentationSize = indentationSize;
            IndentationChar = indentationChar;
            LineBreak = lineBreak;
            SingleLine = singleLine;
            HashForSingleLineComments = hashForSingleLineComments;
            TextEncoder = textEncoder;
        }

        public DotTokenWriterOptions(DotTokenWriterOptions source)
            : this(
                source.IndentationLevel,
                source.IndentationSize,
                source.IndentationChar,
                source.LineBreak,
                source.SingleLine,
                source.HashForSingleLineComments,
                source.TextEncoder
            )
        {
        }

        public virtual int IndentationLevel { get; protected set; }
        public virtual int IndentationSize { get; protected set; }
        public virtual char IndentationChar { get; protected set; }
        public virtual string LineBreak { get; protected set; }
        public virtual bool SingleLine { get; protected set; }
        public bool HashForSingleLineComments { get; protected set; }

        public virtual Func<string, DotTokenType, string> TextEncoder { get; protected set; }

        public virtual DotTokenWriterOptions ToSingleLine()
        {
            return new DotTokenWriterOptions(this)
            {
                SingleLine = true
            };
        }

        public virtual DotTokenWriterOptions IncreaseIndentation()
        {
            return new DotTokenWriterOptions(this)
            {
                IndentationLevel = IndentationLevel + 1
            };
        }
    }
}