using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// A node shape attribute. Assignable to nodes only.
    /// <see href="https://www.graphviz.org/doc/info/shapes.html">View how individual shapes are visualized</see>.
    /// </summary>
    public class DotShapeAttribute : DotCommonAttribute<DotShape>
    {
        /// <summary>
        /// Creates a new instance of the attribute with a key of "shape".
        /// </summary>
        /// <param name="value">The value of the attribute.</param>
        public DotShapeAttribute(DotShape value)
            : base("shape", value)
        {
        }

        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotShapeAttribute(string key, DotShape value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            switch (Value)
            {
                case DotShape.None:
                    return "none";

                case DotShape.Box:
                    return "box";

                case DotShape.Polygon:
                    return "polygon";

                case DotShape.Ellipse:
                    return "ellipse";

                case DotShape.Oval:
                    return "oval";

                case DotShape.Circle:
                    return "circle";

                case DotShape.Point:
                    return "point";

                case DotShape.Egg:
                    return "egg";

                case DotShape.Triangle:
                    return "triangle";

                case DotShape.PlainText:
                    return "plaintext";

                case DotShape.Plain:
                    return "plain";

                case DotShape.Diamond:
                    return "diamond";

                case DotShape.Trapezium:
                    return "trapezium";

                case DotShape.Parallelogram:
                    return "parallelogram";

                case DotShape.House:
                    return "house";

                case DotShape.Pentagon:
                    return "pentagon";

                case DotShape.Hexagon:
                    return "hexagon";

                case DotShape.Septagon:
                    return "septagon";

                case DotShape.Octagon:
                    return "octagon";

                case DotShape.DoubleCircle:
                    return "doublecircle";

                case DotShape.DoubleOctagon:
                    return "doubleoctagon";

                case DotShape.TripleOctagon:
                    return "tripleoctagon";

                case DotShape.InvertedTriangle:
                    return "invtriangle";

                case DotShape.InvertedTrapezium:
                    return "invtrapezium";

                case DotShape.InvertedHouse:
                    return "invhouse";

                case DotShape.MDiamond:
                    return "Mdiamond";

                case DotShape.MSquare:
                    return "Msquare";

                case DotShape.MCircle:
                    return "Mcircle";

                case DotShape.Rect:
                    return "rect";

                case DotShape.Rectangle:
                    return "rectangle";

                case DotShape.Square:
                    return "square";

                case DotShape.Star:
                    return "star";

                case DotShape.Underline:
                    return "underline";

                case DotShape.Cylinder:
                    return "cylinder";

                case DotShape.Note:
                    return "note";

                case DotShape.Tab:
                    return "tab";

                case DotShape.Folder:
                    return "folder";

                case DotShape.Box3D:
                    return "box3d";

                case DotShape.Component:
                    return "component";

                case DotShape.Promoter:
                    return "promoter";

                case DotShape.Cds:
                    return "cds";

                case DotShape.Terminator:
                    return "terminator";

                case DotShape.Utr:
                    return "utr";

                case DotShape.PrimerSite:
                    return "primersite";

                case DotShape.RestrictionSite:
                    return "restrictionsite";

                case DotShape.FivePrimeOverhang:
                    return "fivepoverhang";

                case DotShape.ThreePrimeOverhang:
                    return "threepoverhang";

                case DotShape.NOverhang:
                    return "noverhang";

                case DotShape.Assembly:
                    return "assembly";

                case DotShape.Signature:
                    return "signature";

                case DotShape.Insulator:
                    return "insulator";

                case DotShape.RiboSite:
                    return "ribosite";

                case DotShape.RnaStab:
                    return "rnastab";

                case DotShape.ProteaseSite:
                    return "proteasesite";

                case DotShape.ProteinStab:
                    return "proteinstab";

                case DotShape.RightPromoter:
                    return "rpromoter";

                case DotShape.RightArrow:
                    return "rarrow";

                case DotShape.LeftArrow:
                    return "larrow";

                case DotShape.LeftPromoter:
                    return "lpromoter";

                case DotShape.Record:
                    return "record";

                case DotShape.MRecord:
                    return "Mrecord";

                default:
                    throw new ArgumentOutOfRangeException(nameof(IDotAttribute.GetDotEncodedValue), $"The specified node shape '{Value}' is not supported.");
            }
        }

        public static implicit operator DotShapeAttribute(DotShape shape)
        {
            return new DotShapeAttribute(shape);
        }
    }
}
