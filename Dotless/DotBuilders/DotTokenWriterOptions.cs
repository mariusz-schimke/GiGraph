using System;

namespace Dotless.DotBuilders
{
    public class DotTokenWriterOptions
    {
        /// <summary>
        /// Gets or sets the value indicating if the output should be generated as a single line of text.
        /// In such case <see cref="LineBreak"/> sequences in identifiers and HTML labels will be replaced with
        /// <see cref="SingleLineOutputLineBreakReplacement"/>.
        /// </summary>
        public bool SingleLineOutput { get; set; } = false;

        /// <summary>
        /// Gets or sets the string to to replace all <see cref="LineBreak"/> sequences in identifiers and HTML labels
        /// in the <see cref="SingleLineOutput"/> mode.
        /// </summary>
        public string SingleLineOutputLineBreakReplacement { get; set; } = " ";

        public bool Indent { get; set; } = true;
        public char IndentChar { get; set; } = ' ';
        public int Indentation { get; set; } = 4;
        public int BaseIndentation { get; set; } = 0;
        public int TokenSpacing { get; set; } = 1;
        public string LineBreak { get; set; } = Environment.NewLine;
    }
}
