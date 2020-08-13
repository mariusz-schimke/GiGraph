using GiGraph.Dot.Entities.Types.Attributes;
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
        [DotAttributeValue("none")]
        None,

        /// <summary>
        ///     No shape, just label. Similar to <see cref="PlainText" /> and <see cref="None" />, except that it also enforces width = 0,
        ///     height = 0, and margin = 0, which guarantees that the actual size of the node is entirely determined by the label. This is
        ///     useful, for example, when using HTML-like labels.
        /// </summary>
        [DotAttributeValue("plain")]
        Plain,

        /// <summary>
        ///     No shape, just label. Synonymous to <see cref="None" />.
        /// </summary>
        [DotAttributeValue("plaintext")]
        PlainText,

        [DotAttributeValue("underline")]
        Underline,

        /// <summary>
        ///     The point shape. The way it is visualized is only affected by the peripheries, width, and height attributes.
        /// </summary>
        [DotAttributeValue("point")]
        Point,

        [DotAttributeValue("circle")]
        Circle,

        [DotAttributeValue("Mcircle")]
        ClippedCircle,

        [DotAttributeValue("doublecircle")]
        DoubleCircle,


        [DotAttributeValue("ellipse")]
        Ellipse,

        [DotAttributeValue("oval")]
        Oval,

        [DotAttributeValue("egg")]
        Egg,

        /// <summary>
        ///     A rectangular shape. Synonymous to <see cref="Rect" /> and <see cref="Rectangle" />.
        /// </summary>
        [DotAttributeValue("box")]
        Box,

        /// <summary>
        ///     A cuboid.
        /// </summary>
        [DotAttributeValue("box3d")]
        Box3D,

        /// <summary>
        ///     A rectangular shape. Synonymous to <see cref="Rectangle" /> and <see cref="Box" />.
        /// </summary>
        [DotAttributeValue("rect")]
        Rect,

        /// <summary>
        ///     A rectangular shape. Synonymous to <see cref="Rect" /> and <see cref="Box" />.
        /// </summary>
        [DotAttributeValue("rectangle")]
        Rectangle,


        [DotAttributeValue("cylinder")]
        Cylinder,


        [DotAttributeValue("square")]
        Square,

        [DotAttributeValue("Msquare")]
        ClippedSquare,


        [DotAttributeValue("triangle")]
        Triangle,

        [DotAttributeValue("invtriangle")]
        InvertedTriangle,


        [DotAttributeValue("diamond")]
        Diamond,

        [DotAttributeValue("Mdiamond")]
        ClippedDiamond,


        [DotAttributeValue("parallelogram")]
        Parallelogram,

        /// <summary>
        ///     A polygon shape. When set, the attributes sides, skew, and distortion are also used.
        /// </summary>
        [DotAttributeValue("polygon")]
        Polygon,


        [DotAttributeValue("pentagon")]
        Pentagon,

        [DotAttributeValue("hexagon")]
        Hexagon,

        [DotAttributeValue("septagon")]
        Septagon,


        [DotAttributeValue("octagon")]
        Octagon,

        [DotAttributeValue("doubleoctagon")]
        DoubleOctagon,

        [DotAttributeValue("tripleoctagon")]
        TripleOctagon,


        [DotAttributeValue("trapezium")]
        Trapezium,

        [DotAttributeValue("invtrapezium")]
        InvertedTrapezium,


        [DotAttributeValue("house")]
        House,

        [DotAttributeValue("invhouse")]
        InvertedHouse,


        [DotAttributeValue("star")]
        Star,


        [DotAttributeValue("note")]
        Note,

        [DotAttributeValue("folder")]
        Folder,

        [DotAttributeValue("component")]
        Component,

        [DotAttributeValue("tab")]
        Tab,

        /// <summary>
        ///     Visually, a record is a box, with fields represented by alternating rows of horizontal or vertical subboxes. Use a
        ///     <see cref="DotRecordLabel" /> label to define the fields of the record (
        ///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
        ///         learn more
        ///     </see>
        ///     ).
        /// </summary>
        [DotAttributeValue("record")]
        Record,

        /// <summary>
        ///     Visually, this type of record shape is a box with rounded corers, and fields represented by alternating rows of horizontal or
        ///     vertical subboxes. Use a <see cref="DotRecordLabel" /> label to define the fields of the record (
        ///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
        ///         learn more
        ///     </see>
        ///     ).
        /// </summary>
        [DotAttributeValue("Mrecord")]
        RoundedRecord,


        // --- SYNTHETIC BIOLOGY SHAPES ---

        /// <summary>
        ///     Synthetic biology: coding sequence (CDS).
        /// </summary>
        [DotAttributeValue("cds")]
        Cds,

        /// <summary>
        ///     Synthetic biology: signature.
        /// </summary>
        [DotAttributeValue("signature")]
        Signature,

        /// <summary>
        ///     Synthetic biology: left arrow.
        /// </summary>
        [DotAttributeValue("larrow")]
        LeftArrow,

        /// <summary>
        ///     Synthetic biology: right arrow.
        /// </summary>
        [DotAttributeValue("rarrow")]
        RightArrow,

        /// <summary>
        ///     Synthetic biology: left promoter.
        /// </summary>
        [DotAttributeValue("lpromoter")]
        LeftPromoter,

        /// <summary>
        ///     Synthetic biology: right promoter.
        /// </summary>
        [DotAttributeValue("rpromoter")]
        RightPromoter,

        /// <summary>
        ///     Synthetic biology: promoter.
        /// </summary>
        [DotAttributeValue("promoter")]
        Promoter,

        /// <summary>
        ///     Synthetic biology: untranslated region (UTR).
        /// </summary>
        [DotAttributeValue("utr")]
        Utr,

        /// <summary>
        ///     Synthetic biology: terminator.
        /// </summary>
        [DotAttributeValue("terminator")]
        Terminator,

        /// <summary>
        ///     Synthetic biology: primer site.
        /// </summary>
        [DotAttributeValue("primersite")]
        PrimerSite,

        /// <summary>
        ///     Synthetic biology: restriction site.
        /// </summary>
        [DotAttributeValue("restrictionsite")]
        RestrictionSite,

        /// <summary>
        ///     Synthetic biology: 3' overhang.
        /// </summary>
        [DotAttributeValue("threepoverhang")]
        ThreePrimeOverhang,

        /// <summary>
        ///     Synthetic biology: 5' overhang.
        /// </summary>
        [DotAttributeValue("fivepoverhang")]
        FivePrimeOverhang,

        /// <summary>
        ///     Synthetic biology: n overhang.
        /// </summary>
        [DotAttributeValue("noverhang")]
        NOverhang,

        /// <summary>
        ///     Synthetic biology: assembly.
        /// </summary>
        [DotAttributeValue("assembly")]
        Assembly,

        /// <summary>
        ///     Synthetic biology: insulator.
        /// </summary>
        [DotAttributeValue("insulator")]
        Insulator,

        /// <summary>
        ///     Synthetic biology: ribo site.
        /// </summary>
        [DotAttributeValue("ribosite")]
        RiboSite,

        /// <summary>
        ///     Synthetic biology: protease site.
        /// </summary>
        [DotAttributeValue("proteasesite")]
        ProteaseSite,

        /// <summary>
        ///     Synthetic biology: RNA stab.
        /// </summary>
        [DotAttributeValue("rnastab")]
        RnaStab,

        /// <summary>
        ///     Synthetic biology: protein stab.
        /// </summary>
        [DotAttributeValue("proteinstab")]
        ProteinStab
    }
}