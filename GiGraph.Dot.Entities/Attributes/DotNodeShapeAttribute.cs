using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A node shape attribute. Assignable to nodes only.
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html">
    ///         View how individual shapes are visualized
    ///     </see>
    ///     .
    /// </summary>
    public class DotNodeShapeAttribute : DotAttribute<DotNodeShape>
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotNodeShapeAttribute(string key, DotNodeShape value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value switch
            {
                DotNodeShape.None => "none",
                DotNodeShape.Box => "box",
                DotNodeShape.Polygon => "polygon",
                DotNodeShape.Ellipse => "ellipse",
                DotNodeShape.Oval => "oval",
                DotNodeShape.Circle => "circle",
                DotNodeShape.Point => "point",
                DotNodeShape.Egg => "egg",
                DotNodeShape.Triangle => "triangle",
                DotNodeShape.PlainText => "plaintext",
                DotNodeShape.Plain => "plain",
                DotNodeShape.Diamond => "diamond",
                DotNodeShape.Trapezium => "trapezium",
                DotNodeShape.Parallelogram => "parallelogram",
                DotNodeShape.House => "house",
                DotNodeShape.Pentagon => "pentagon",
                DotNodeShape.Hexagon => "hexagon",
                DotNodeShape.Septagon => "septagon",
                DotNodeShape.Octagon => "octagon",
                DotNodeShape.DoubleCircle => "doublecircle",
                DotNodeShape.DoubleOctagon => "doubleoctagon",
                DotNodeShape.TripleOctagon => "tripleoctagon",
                DotNodeShape.InvertedTriangle => "invtriangle",
                DotNodeShape.InvertedTrapezium => "invtrapezium",
                DotNodeShape.InvertedHouse => "invhouse",
                DotNodeShape.ClippedDiamond => "Mdiamond",
                DotNodeShape.ClippedSquare => "Msquare",
                DotNodeShape.ClippedCircle => "Mcircle",
                DotNodeShape.Rect => "rect",
                DotNodeShape.Rectangle => "rectangle",
                DotNodeShape.Square => "square",
                DotNodeShape.Star => "star",
                DotNodeShape.Underline => "underline",
                DotNodeShape.Cylinder => "cylinder",
                DotNodeShape.Note => "note",
                DotNodeShape.Tab => "tab",
                DotNodeShape.Folder => "folder",
                DotNodeShape.Box3D => "box3d",
                DotNodeShape.Component => "component",
                DotNodeShape.Promoter => "promoter",
                DotNodeShape.Cds => "cds",
                DotNodeShape.Terminator => "terminator",
                DotNodeShape.Utr => "utr",
                DotNodeShape.PrimerSite => "primersite",
                DotNodeShape.RestrictionSite => "restrictionsite",
                DotNodeShape.FivePrimeOverhang => "fivepoverhang",
                DotNodeShape.ThreePrimeOverhang => "threepoverhang",
                DotNodeShape.NOverhang => "noverhang",
                DotNodeShape.Assembly => "assembly",
                DotNodeShape.Signature => "signature",
                DotNodeShape.Insulator => "insulator",
                DotNodeShape.RiboSite => "ribosite",
                DotNodeShape.RnaStab => "rnastab",
                DotNodeShape.ProteaseSite => "proteasesite",
                DotNodeShape.ProteinStab => "proteinstab",
                DotNodeShape.RightPromoter => "rpromoter",
                DotNodeShape.RightArrow => "rarrow",
                DotNodeShape.LeftArrow => "larrow",
                DotNodeShape.LeftPromoter => "lpromoter",
                DotNodeShape.Record => "record",
                DotNodeShape.RoundedRecord => "Mrecord",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"The specified node shape '{Value}' is not supported.")
            };
        }
    }
}