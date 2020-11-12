using System;

namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    ///     Customizes output DOT script formatting.
    /// </summary>
    public partial class DotFormattingOptions
    {
        /// <summary>
        ///     Indicates if the output should be generated without line breaks.
        /// </summary>
        public virtual bool SingleLine { get; set; } = false;

        /// <summary>
        ///     The base indentation level for the DOT output.
        /// </summary>
        public virtual int IndentationLevel { get; set; } = 0;

        /// <summary>
        ///     The indentation size.
        /// </summary>
        public virtual int IndentationSize { get; set; } = 4;

        /// <summary>
        ///     Determines what character to use for indentation (space by default).
        /// </summary>
        public virtual char IndentationChar { get; set; } = ' ';

        /// <summary>
        ///     The line break sequence to use in the DOT output (<see cref="Environment.NewLine" /> by default).
        /// </summary>
        public virtual string LineBreak { get; set; } = Environment.NewLine;

        /// <summary>
        ///     Gets edge formatting options.
        /// </summary>
        public virtual EdgeOptions Edges { get; } = new EdgeOptions();

        /// <summary>
        ///     Gets subgraph formatting options.
        /// </summary>
        public virtual SubgraphOptions Subgraphs { get; } = new SubgraphOptions();

        /// <summary>
        ///     An optional text encoder to use when writing text to the output stream. May become useful when the DOT visualization tool you
        ///     use fails processing some special or national characters. In such case replacing them with their HTML-code equivalents might
        ///     help.
        /// </summary>
        public virtual Func<string, string> TextEncoder { get; set; }
    }
}