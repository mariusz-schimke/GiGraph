using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Types.Nodes;

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
    ///     No shape, just label. Similar to <see cref="PlainText" /> and <see cref="None" />, except that it also enforces a zero width,
    ///     height, and padding, which guarantees that the actual size of the node is entirely determined by the label. This is useful,
    ///     for example, when using HTML-like labels.
    /// </summary>
    [DotAttributeValue("plain")]
    Plain,

    /// <summary>
    ///     No shape, just label. Synonymous to <see cref="None" />.
    /// </summary>
    [DotAttributeValue("plaintext")]
    PlainText,

    /// <summary>
    ///     An underline.
    /// </summary>
    [DotAttributeValue("underline")]
    Underline,

    /// <summary>
    ///     The point shape. The way it is visualized is only affected by the peripheries, width, and height attributes.
    /// </summary>
    [DotAttributeValue("point")]
    Point,

    /// <summary>
    ///     A circular shape.
    /// </summary>
    [DotAttributeValue("circle")]
    Circle,

    /// <summary>
    ///     A clipped circle shape.
    /// </summary>
    [DotAttributeValue("Mcircle")]
    ClippedCircle,

    /// <summary>
    ///     A double circle shape.
    /// </summary>
    [DotAttributeValue("doublecircle")]
    DoubleCircle,

    /// <summary>
    ///     An elliptical shape.
    /// </summary>
    [DotAttributeValue("ellipse")]
    Ellipse,

    /// <summary>
    ///     An oval shape.
    /// </summary>
    [DotAttributeValue("oval")]
    Oval,

    /// <summary>
    ///     An egg shape.
    /// </summary>
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

    /// <summary>
    ///     A cylindrical shape.
    /// </summary>
    [DotAttributeValue("cylinder")]
    Cylinder,

    /// <summary>
    ///     A square shape.
    /// </summary>
    [DotAttributeValue("square")]
    Square,

    /// <summary>
    ///     A clipped square shape.
    /// </summary>
    [DotAttributeValue("Msquare")]
    ClippedSquare,

    /// <summary>
    ///     A triangular shape.
    /// </summary>
    [DotAttributeValue("triangle")]
    Triangle,

    /// <summary>
    ///     An inverted triangle shape.
    /// </summary>
    [DotAttributeValue("invtriangle")]
    InvertedTriangle,

    /// <summary>
    ///     A diamond shape.
    /// </summary>
    [DotAttributeValue("diamond")]
    Diamond,

    /// <summary>
    ///     A clipped diamond shape.
    /// </summary>
    [DotAttributeValue("Mdiamond")]
    ClippedDiamond,

    /// <summary>
    ///     A parallelogram shape.
    /// </summary>
    [DotAttributeValue("parallelogram")]
    Parallelogram,

    /// <summary>
    ///     A polygon shape. When set, the attributes sides, skew, and distortion are also used.
    /// </summary>
    [DotAttributeValue("polygon")]
    Polygon,

    /// <summary>
    ///     A pentagonal shape.
    /// </summary>
    [DotAttributeValue("pentagon")]
    Pentagon,

    /// <summary>
    ///     A hexagonal shape.
    /// </summary>
    [DotAttributeValue("hexagon")]
    Hexagon,

    /// <summary>
    ///     A septagonal shape.
    /// </summary>
    [DotAttributeValue("septagon")]
    Septagon,

    /// <summary>
    ///     An octagonal shape.
    /// </summary>
    [DotAttributeValue("octagon")]
    Octagon,

    /// <summary>
    ///     A double octagon shape.
    /// </summary>
    [DotAttributeValue("doubleoctagon")]
    DoubleOctagon,

    /// <summary>
    ///     A triple octagon shape.
    /// </summary>
    [DotAttributeValue("tripleoctagon")]
    TripleOctagon,

    /// <summary>
    ///     A trapezium shape.
    /// </summary>
    [DotAttributeValue("trapezium")]
    Trapezium,

    /// <summary>
    ///     An inverted trapezium shape.
    /// </summary>
    [DotAttributeValue("invtrapezium")]
    InvertedTrapezium,

    /// <summary>
    ///     A house shape.
    /// </summary>
    [DotAttributeValue("house")]
    House,

    /// <summary>
    ///     An inverted house shape.
    /// </summary>
    [DotAttributeValue("invhouse")]
    InvertedHouse,

    /// <summary>
    ///     A star shape.
    /// </summary>
    [DotAttributeValue("star")]
    Star,

    /// <summary>
    ///     A note shape.
    /// </summary>
    [DotAttributeValue("note")]
    Note,

    /// <summary>
    ///     A folder shape.
    /// </summary>
    [DotAttributeValue("folder")]
    Folder,

    /// <summary>
    ///     A component shape.
    /// </summary>
    [DotAttributeValue("component")]
    Component,

    /// <summary>
    ///     A tab shape.
    /// </summary>
    [DotAttributeValue("tab")]
    Tab,

    /// <summary>
    ///     Visually, a record is a box, with fields represented by alternating rows of horizontal or vertical subboxes. Use a
    ///     <see cref="DotRecord" /> instance to define the fields of the record and assign it directly to the label attribute of the
    ///     node (
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
    ///         learn more
    ///     </see>
    ///     ).
    /// </summary>
    [DotAttributeValue("record")]
    Record,

    /// <summary>
    ///     Visually, this type of record shape is a box with rounded corers, and fields represented by alternating rows of horizontal or
    ///     vertical subboxes. Use a <see cref="DotRecord" /> instance to define the fields of the record and assign it directly to the
    ///     label attribute of the node (
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
    ///         learn more
    ///     </see>
    ///     ).
    /// </summary>
    [DotAttributeValue("Mrecord")]
    RoundedRecord,


    // --- SYNTHETIC BIOLOGY SHAPES ---
    // see Synthetic Biology Open Language (SBOL): https://en.wikipedia.org/wiki/Synthetic_Biology_Open_Language
    // see https://sbolstandard.org/visual-glyphs/
    // see (these symbols match those by Graphviz): https://fr.m.wikipedia.org/wiki/Fichier:Synthetic_Biology_Open_Language_%28SBOL%29_standard_visual_symbols.png

    /// <summary>
    ///     Synthetic biology: coding sequence (CDS).
    /// </summary>
    [DotAttributeValue("cds")]
    CodingSequence,

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
    UntranslatedRegion,

    /// <summary>
    ///     Synthetic biology: terminator.
    /// </summary>
    [DotAttributeValue("terminator")]
    Terminator,

    /// <summary>
    ///     Synthetic biology: primer binding site.
    /// </summary>
    [DotAttributeValue("primersite")]
    PrimerBindingSite,

    /// <summary>
    ///     Synthetic biology: 5' sticky restriction site.
    /// </summary>
    [DotAttributeValue("restrictionsite")]
    FivePrimeStickyRestrictionSite,

    /// <summary>
    ///     Synthetic biology: ribonuclease site.
    /// </summary>
    [DotAttributeValue("ribosite")]
    RibonucleaseSite,

    /// <summary>
    ///     Synthetic biology: protease site.
    /// </summary>
    [DotAttributeValue("proteasesite")]
    ProteaseSite,

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
    ///     Synthetic biology: no overhang (blunt end).
    /// </summary>
    [DotAttributeValue("noverhang")]
    NoOverhang,

    /// <summary>
    ///     Synthetic biology: assembly scar.
    /// </summary>
    [DotAttributeValue("assembly")]
    AssemblyScar,

    /// <summary>
    ///     Synthetic biology: insulator.
    /// </summary>
    [DotAttributeValue("insulator")]
    Insulator,

    /// <summary>
    ///     Synthetic biology: RNA stability element.
    /// </summary>
    [DotAttributeValue("rnastab")]
    RnaStabilityElement,

    /// <summary>
    ///     Synthetic biology: protein stability element.
    /// </summary>
    [DotAttributeValue("proteinstab")]
    ProteinStabilityElement
}