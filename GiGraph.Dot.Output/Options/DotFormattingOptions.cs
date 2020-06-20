using System;

namespace GiGraph.Dot.Output.Options
{
    public class DotFormattingOptions
    {
        /// <summary>
        /// Gets or sets the value indicating if the output should be generated as a single line of text.
        /// In such case <see cref="LineBreak"/> sequences in identifiers and HTML labels will be replaced with white space.
        /// </summary>
        public virtual bool SingleLineOutput { get; set; } = false;

        /// <summary>
        /// Determines what character to use for indentation (space by default).
        /// </summary>
        public virtual char IndentChar { get; set; } = ' ';

        /// <summary>
        /// The default indentation to apply to the DOT output.
        /// </summary>
        public virtual int Indentation { get; set; } = 4;

        /// <summary>
        /// The line break sequence to use in the DOT output (<see cref="Environment.NewLine"/> by default).
        /// </summary>
        public virtual string LineBreak { get; set; } = Environment.NewLine;

        /// <summary>
        /// An optional text encoder to use when writing text to the output stream. May become useful when
        /// the DOT visualization tool you use fails processing some special characters. In such case replacing them
        /// with their HTML-code equivalents might help. 
        /// </summary>
        public virtual Func<string, string> TextEncoder { get; set; }

        public virtual DotFormattingOptions Clone()
        {
            return (DotFormattingOptions) MemberwiseClone();
        }
    }
}