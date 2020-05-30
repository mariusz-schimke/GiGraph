using System;

namespace GiGraph.Dot.Writers.Options
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

        public virtual DotFormattingOptions Clone()
        {
            return (DotFormattingOptions)MemberwiseClone();
        }
    }
}
