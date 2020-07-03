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
            switch (Value)
            {
                case DotNodeShape.None:
                    return "none";

                case DotNodeShape.Box:
                    return "box";

                case DotNodeShape.Polygon:
                    return "polygon";

                case DotNodeShape.Ellipse:
                    return "ellipse";

                case DotNodeShape.Oval:
                    return "oval";

                case DotNodeShape.Circle:
                    return "circle";

                case DotNodeShape.Point:
                    return "point";

                case DotNodeShape.Egg:
                    return "egg";

                case DotNodeShape.Triangle:
                    return "triangle";

                case DotNodeShape.PlainText:
                    return "plaintext";

                case DotNodeShape.Plain:
                    return "plain";

                case DotNodeShape.Diamond:
                    return "diamond";

                case DotNodeShape.Trapezium:
                    return "trapezium";

                case DotNodeShape.Parallelogram:
                    return "parallelogram";

                case DotNodeShape.House:
                    return "house";

                case DotNodeShape.Pentagon:
                    return "pentagon";

                case DotNodeShape.Hexagon:
                    return "hexagon";

                case DotNodeShape.Septagon:
                    return "septagon";

                case DotNodeShape.Octagon:
                    return "octagon";

                case DotNodeShape.DoubleCircle:
                    return "doublecircle";

                case DotNodeShape.DoubleOctagon:
                    return "doubleoctagon";

                case DotNodeShape.TripleOctagon:
                    return "tripleoctagon";

                case DotNodeShape.InvertedTriangle:
                    return "invtriangle";

                case DotNodeShape.InvertedTrapezium:
                    return "invtrapezium";

                case DotNodeShape.InvertedHouse:
                    return "invhouse";

                case DotNodeShape.ClippedDiamond:
                    return "Mdiamond";

                case DotNodeShape.ClippedSquare:
                    return "Msquare";

                case DotNodeShape.ClippedCircle:
                    return "Mcircle";

                case DotNodeShape.Rect:
                    return "rect";

                case DotNodeShape.Rectangle:
                    return "rectangle";

                case DotNodeShape.Square:
                    return "square";

                case DotNodeShape.Star:
                    return "star";

                case DotNodeShape.Underline:
                    return "underline";

                case DotNodeShape.Cylinder:
                    return "cylinder";

                case DotNodeShape.Note:
                    return "note";

                case DotNodeShape.Tab:
                    return "tab";

                case DotNodeShape.Folder:
                    return "folder";

                case DotNodeShape.Box3D:
                    return "box3d";

                case DotNodeShape.Component:
                    return "component";

                case DotNodeShape.Promoter:
                    return "promoter";

                case DotNodeShape.Cds:
                    return "cds";

                case DotNodeShape.Terminator:
                    return "terminator";

                case DotNodeShape.Utr:
                    return "utr";

                case DotNodeShape.PrimerSite:
                    return "primersite";

                case DotNodeShape.RestrictionSite:
                    return "restrictionsite";

                case DotNodeShape.FivePrimeOverhang:
                    return "fivepoverhang";

                case DotNodeShape.ThreePrimeOverhang:
                    return "threepoverhang";

                case DotNodeShape.NOverhang:
                    return "noverhang";

                case DotNodeShape.Assembly:
                    return "assembly";

                case DotNodeShape.Signature:
                    return "signature";

                case DotNodeShape.Insulator:
                    return "insulator";

                case DotNodeShape.RiboSite:
                    return "ribosite";

                case DotNodeShape.RnaStab:
                    return "rnastab";

                case DotNodeShape.ProteaseSite:
                    return "proteasesite";

                case DotNodeShape.ProteinStab:
                    return "proteinstab";

                case DotNodeShape.RightPromoter:
                    return "rpromoter";

                case DotNodeShape.RightArrow:
                    return "rarrow";

                case DotNodeShape.LeftArrow:
                    return "larrow";

                case DotNodeShape.LeftPromoter:
                    return "lpromoter";

                case DotNodeShape.Record:
                    return "record";

                case DotNodeShape.RoundedRecord:
                    return "Mrecord";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified node shape '{Value}' is not supported.");
            }
        }
    }
}