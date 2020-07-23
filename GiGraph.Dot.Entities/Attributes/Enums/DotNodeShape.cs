using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The node shape.
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html">
    ///         View how individual shapes are visualized
    ///     </see>
    ///     .
    /// </summary>
    public enum DotNodeShape
    {
        /// <summary>
        ///     No shape, just label. Synonymous to <see cref="PlainText" />.
        /// </summary>
        None,

        /// <summary>
        ///     No shape, just label. Similar to <see cref="PlainText" /> and <see cref="None" />, except that it also enforces width = 0,
        ///     height = 0, and margin = 0, which guarantees that the actual size of the node is entirely determined by the label. This is
        ///     useful, for example, when using HTML-like labels.
        /// </summary>
        Plain,

        /// <summary>
        ///     No shape, just label. Synonymous to <see cref="None" />.
        /// </summary>
        PlainText,

        Underline,

        /// <summary>
        ///     The point shape. The way it is visualized is only affected by the peripheries, width, and height attributes.
        /// </summary>
        Point,

        Circle,
        ClippedCircle,
        DoubleCircle,

        Ellipse,
        Oval,
        Egg,

        /// <summary>
        ///     A rectangular shape. Synonymous to <see cref="Rect" /> and <see cref="Rectangle" />.
        /// </summary>
        Box,

        /// <summary>
        ///     A cuboid.
        /// </summary>
        Box3D,

        /// <summary>
        ///     A rectangular shape. Synonymous to <see cref="Rectangle" /> and <see cref="Box" />.
        /// </summary>
        Rect,

        /// <summary>
        ///     A rectangular shape. Synonymous to <see cref="Rect" /> and <see cref="Box" />.
        /// </summary>
        Rectangle,

        Cylinder,

        Square,
        ClippedSquare,

        Triangle,
        InvertedTriangle,

        Diamond,
        ClippedDiamond,

        Parallelogram,

        /// <summary>
        ///     A polygon shape. When set, the attributes sides, skew, and distortion are also used.
        /// </summary>
        Polygon,

        Pentagon,
        Hexagon,
        Septagon,

        Octagon,
        DoubleOctagon,
        TripleOctagon,

        Trapezium,
        InvertedTrapezium,

        House,
        InvertedHouse,

        Star,

        Note,
        Folder,
        Component,
        Tab,

        /// <summary>
        ///     Visually, a record is a box, with fields represented by alternating rows of horizontal or vertical subboxes. Use a
        ///     <see cref="DotRecordLabel" /> label to define the fields of the record (
        ///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
        ///         learn more
        ///     </see>
        ///     ).
        /// </summary>
        Record,

        /// <summary>
        ///     Visually, this type of record shape is a box with rounded corers, and fields represented by alternating rows of horizontal or
        ///     vertical subboxes. Use a <see cref="DotRecordLabel" /> label to define the fields of the record (
        ///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
        ///         learn more
        ///     </see>
        ///     ).
        /// </summary>
        RoundedRecord,


        // --- SYNTHETIC BIOLOGY SHAPES ---

        /// <summary>
        ///     Synthetic biology: coding sequence (CDS).
        /// </summary>
        Cds,

        /// <summary>
        ///     Synthetic biology: signature.
        /// </summary>
        Signature,

        /// <summary>
        ///     Synthetic biology: left arrow.
        /// </summary>
        LeftArrow,

        /// <summary>
        ///     Synthetic biology: right arrow.
        /// </summary>
        RightArrow,

        /// <summary>
        ///     Synthetic biology: left promoter.
        /// </summary>
        LeftPromoter,

        /// <summary>
        ///     Synthetic biology: right promoter.
        /// </summary>
        RightPromoter,

        /// <summary>
        ///     Synthetic biology: promoter.
        /// </summary>
        Promoter,

        /// <summary>
        ///     Synthetic biology: untranslated region (UTR).
        /// </summary>
        Utr,

        /// <summary>
        ///     Synthetic biology: terminator.
        /// </summary>
        Terminator,

        /// <summary>
        ///     Synthetic biology: primer site.
        /// </summary>
        PrimerSite,

        /// <summary>
        ///     Synthetic biology: restriction site.
        /// </summary>
        RestrictionSite,

        /// <summary>
        ///     Synthetic biology: 3' overhang.
        /// </summary>
        ThreePrimeOverhang,

        /// <summary>
        ///     Synthetic biology: 5' overhang.
        /// </summary>
        FivePrimeOverhang,

        /// <summary>
        ///     Synthetic biology: n overhang.
        /// </summary>
        NOverhang,

        /// <summary>
        ///     Synthetic biology: assembly.
        /// </summary>
        Assembly,

        /// <summary>
        ///     Synthetic biology: insulator.
        /// </summary>
        Insulator,

        /// <summary>
        ///     Synthetic biology: ribo site.
        /// </summary>
        RiboSite,

        /// <summary>
        ///     Synthetic biology: protease site.
        /// </summary>
        ProteaseSite,

        /// <summary>
        ///     Synthetic biology: RNA stab.
        /// </summary>
        RnaStab,

        /// <summary>
        ///     Synthetic biology: protein stab.
        /// </summary>
        ProteinStab
    }
}