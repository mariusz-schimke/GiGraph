﻿using System;
using GiGraph.Dot.Output.TextEscaping;

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
        ///     The line break sequence to use in the DOT output (a system-dependent line break sequence is used by default; see also
        ///     <see cref="DotNewLine" />).
        /// </summary>
        public virtual string LineBreak { get; set; } = DotNewLine.SystemDefault;

        /// <summary>
        ///     Gets global attribute formatting options.
        /// </summary>
        public virtual GlobalAttributesOptions GlobalAttributes { get; } = new GlobalAttributesOptions();

        /// <summary>
        ///     Gets subgraph formatting options.
        /// </summary>
        public virtual SubgraphOptions Subgraphs { get; } = new SubgraphOptions();

        /// <summary>
        ///     Gets cluster formatting options.
        /// </summary>
        public virtual ClusterOptions Clusters { get; } = new ClusterOptions();

        /// <summary>
        ///     Gets edge formatting options.
        /// </summary>
        public virtual EdgeOptions Edges { get; } = new EdgeOptions();

        /// <summary>
        ///     Gets node formatting options.
        /// </summary>
        public virtual NodeOptions Nodes { get; } = new NodeOptions();

        /// <summary>
        ///     An optional text encoder to use when writing text to the output stream. May become useful when the DOT visualization tool you
        ///     use fails processing some special or national characters. In such case replacing them with their HTML-code equivalents might
        ///     help.
        /// </summary>
        public virtual Func<string, DotTokenType, string> TextEncoder { get; set; }

        /// <summary>
        ///     Causes attribute lists of all types of elements to be written inline.
        /// </summary>
        public virtual DotFormattingOptions SingleLineAttributeLists()
        {
            return SingleLineAttributeLists(true);
        }

        /// <summary>
        ///     Causes attribute lists of all types of elements to be written in multiple lines (one attribute per line).
        /// </summary>
        public virtual DotFormattingOptions MultilineAttributeLists()
        {
            return SingleLineAttributeLists(false);
        }

        protected virtual DotFormattingOptions SingleLineAttributeLists(bool value)
        {
            GlobalAttributes.SingleLineAttributeLists = value;
            Nodes.SingleLineAttributeLists = value;
            Edges.SingleLineAttributeLists = value;
            return this;
        }
    }
}