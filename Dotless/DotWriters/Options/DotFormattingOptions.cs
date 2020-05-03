using System;

namespace Dotless.DotWriters.Options
{
    public class DotFormattingOptions
    {
        /// <summary>
        /// Gets or sets the value indicating if the output should be generated as a single line of text.
        /// In such case <see cref="LineBreak"/> sequences in identifiers and HTML labels will be replaced with
        /// <see cref="SingleLineOutputLineBreakReplacement"/>.
        /// </summary>
        public bool SingleLineOutput { get; set; } = false;

        public bool Indent { get; set; } = true;
        public char IndentChar { get; set; } = ' ';
        public int Indentation { get; set; } = 4;

        public string LineBreak { get; set; } = Environment.NewLine;
    }
}
