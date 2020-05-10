using System;

namespace Gigraph.Dot.Writers.Options
{
    public class DotFormattingOptions
    {
        /// <summary>
        /// Gets or sets the value indicating if the output should be generated as a single line of text.
        /// In such case <see cref="LineBreak"/> sequences in identifiers and HTML labels will be replaced with white space.
        /// </summary>
        public virtual bool SingleLineOutput { get; set; } = false;

        public virtual char IndentChar { get; set; } = ' ';
        public virtual int Indentation { get; set; } = 4;

        public virtual string LineBreak { get; set; } = Environment.NewLine;
    }
}
