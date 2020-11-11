﻿using System;

namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    ///     Specifies syntax-related options for generating the output DOT script.
    /// </summary>
    public partial class DotSyntaxOptions
    {
        /// <summary>
        ///     Gets the generation options for attributes.
        /// </summary>
        public virtual AttributeOptions Attributes { get; protected set; } = new AttributeOptions();

        /// <summary>
        ///     Gets the generation options for subgraphs.
        /// </summary>
        public virtual SubgraphOptions Subgraphs { get; protected set; } = new SubgraphOptions();

        /// <summary>
        ///     Gets the generation options for clusters.
        /// </summary>
        public virtual ClusterOptions Clusters { get; protected set; } = new ClusterOptions();

        /// <summary>
        ///     Gets the generation options for colors.
        /// </summary>
        public virtual ColorOptions Colors { get; protected set; } = new ColorOptions();

        /// <summary>
        ///     Gets the generation options for comments.
        /// </summary>
        public virtual CommentOptions Comments { get; protected set; } = new CommentOptions();

        /// <summary>
        ///     When set, identifiers will always be quoted, even if it is not required.
        /// </summary>
        public virtual bool PreferQuotedIdentifiers { get; set; } = false;

        /// <summary>
        ///     When set, all statements within the graph will be followed by a delimiter (;).
        /// </summary>
        public virtual bool PreferStatementDelimiter { get; set; } = false;

        /// <summary>
        ///     Gets or sets a value indicating if graph elements should be sorted in the output DOT script. This setting affects attributes,
        ///     nodes, edges, subgraphs, and clusters. If false, all elements will be rendered in the order they were added to individual
        ///     graph element collections.
        ///     <para>
        ///         Useful when the output DOT script is going to be compared to its other versions, so that there are as few differences
        ///         between the scripts as possible. However, this option should be used with care because the order of elements in the
        ///         script may affect the order they are visualized, if that matters.
        ///     </para>
        /// </summary>
        public virtual bool SortElements { get; set; } = false;

        /// <summary>
        ///     Creates a new instance with custom options.
        /// </summary>
        /// <param name="init">
        ///     The options initializer to use.
        /// </param>
        public static DotSyntaxOptions Custom(Action<DotSyntaxOptions> init)
        {
            var result = new DotSyntaxOptions();
            init?.Invoke(result);
            return result;
        }
    }
}