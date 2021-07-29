namespace GiGraph.Dot.Types.Layout
{
    /// <summary>
    ///     Provides the names of available graph layout engines.
    /// </summary>
    public static class DotLayoutEngines
    {
        /// <summary>
        ///     Draws “hierarchical” or layered drawings of directed graphs. This is the default tool to use if edges have directionality.
        ///     See
        ///     <see href="https://graphviz.org/pdf/dot.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Dot = "dot";

        /// <summary>
        ///     Draws “spring model” layouts. This is the default tool to use if the graph is not too large (about 100 nodes) and you don't
        ///     know anything else about it. Neato attempts to minimize a global energy function, which is equivalent to statistical
        ///     multi-dimensional scaling. See
        ///     <see href="https://graphviz.org/pdf/dot.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Neato = "neato";

        /// <summary>
        ///     Draws clustered graphs. See
        ///     <see href="https://graphviz.org/pdf/osage.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Osage = "osage";

        /// <summary>
        ///     Draws “spring model” layouts similar to those of <see cref="Neato" />, but does this by reducing forces rather than working
        ///     with energy. See
        ///     <see href="https://graphviz.org/pdf/dot.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Fdp = "fdp";

        /// <summary>
        ///     A multiscale version of <see cref="Fdp" /> for the layout of large graphs. See
        ///     <see href="https://graphviz.org/pdf/dot.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Sfdp = "sfdp";

        /// <summary>
        ///     Draws circular layouts. This is suitable for certain diagrams of multiple cyclic structures, such as certain
        ///     telecommunications networks. See
        ///     <see href="https://graphviz.org/pdf/dot.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Circo = "circo";

        /// <summary>
        ///     Draws radial layouts. Nodes are placed on concentric circles depending their distance from a given root node. See
        ///     <see href="https://graphviz.org/pdf/dot.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Twopi = "twopi";

        /// <summary>
        ///     Draws the graph as a squarified treemap. The clusters of the graph are used to specify the tree. See
        ///     <see href="https://graphviz.org/pdf/patchwork.1.pdf">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        public const string Patchwork = "patchwork";
    }
}