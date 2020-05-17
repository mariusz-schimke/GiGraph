using GiGraph.Dot.Entities.Attributes.Enums;
using System;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// A node shape attribute. Assignable to nodes only.
    /// To see how each shape is rendered, please go to <see cref="https://www.graphviz.org/doc/info/shapes.html"/>.
    /// </summary>
    public class DotNodeShapeAttribute : DotAttribute<DotNodeShape>
    {
        /// <summary>
        /// Creates a new instance of the attribute with a key of "shape".
        /// </summary>
        /// <param name="value">The value of the attribute.</param>
        public DotNodeShapeAttribute(DotNodeShape value)
            : base("shape", value)
        {
        }

        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotNodeShapeAttribute(string key, DotNodeShape value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue()
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

                case DotNodeShape.InvTriangle:
                    return "invtriangle";

                case DotNodeShape.InvTrapezium:
                    return "invtrapezium";

                case DotNodeShape.InvHouse:
                    return "invhouse";

                case DotNodeShape.MDiamond:
                    return "Mdiamond";

                case DotNodeShape.MSquare:
                    return "Msquare";

                case DotNodeShape.MCircle:
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

                case DotNodeShape.FivePOverhang:
                    return "fivepoverhang";

                case DotNodeShape.ThreePOverhang:
                    return "threepoverhang";

                case DotNodeShape.NOverhang:
                    return "noverhang";

                case DotNodeShape.Assembly:
                    return "assembly";

                case DotNodeShape.Signature:
                    return "signature";

                case DotNodeShape.Insulator:
                    return "insulator";

                case DotNodeShape.Ribosite:
                    return "ribosite";

                case DotNodeShape.RnaStab:
                    return "rnastab";

                case DotNodeShape.Proteasesite:
                    return "proteasesite";

                case DotNodeShape.ProteinStab:
                    return "proteinstab";

                case DotNodeShape.RPromoter:
                    return "rpromoter";

                case DotNodeShape.RArrow:
                    return "rarrow";

                case DotNodeShape.LArrow:
                    return "larrow";

                case DotNodeShape.LPromoter:
                    return "lpromoter";

                case DotNodeShape.Record:
                    return "record";

                case DotNodeShape.MRecord:
                    return "Mrecord";

                default:
                    throw new ArgumentOutOfRangeException(nameof(IDotAttribute.GetDotEncodedValue), $"The specified node shape '{Value}' is not supported.");
            }
        }

        public static implicit operator DotNodeShapeAttribute(DotNodeShape shape)
        {
            return new DotNodeShapeAttribute(shape);
        }
    }
}
