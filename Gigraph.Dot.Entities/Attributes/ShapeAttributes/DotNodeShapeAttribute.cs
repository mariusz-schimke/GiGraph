using Gigraph.Dot.Entities.Attributes.ShapeAttributes;
using System;

namespace Gigraph.Dot.Entities.Attributes
{
    /// <summary>
    /// A node shape attribute. Assignable to nodes only.
    /// To see how specific shapes are rendered, please go to <seealso cref="https://www.graphviz.org/doc/info/shapes.html"/>.
    /// </summary>
    public class DotNodeShapeAttribute : DotAttribute<DotNodeShape>
    {
        public static string AttributeKey => "shape";

        public DotNodeShapeAttribute(DotNodeShape value)
            : base(AttributeKey, value)
        {
        }

        protected override string GetValueAsString()
        {
            switch (_value)
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
                    throw new ArgumentOutOfRangeException($"The specified node shape '{_value}' is not supported.");
            }
        }
    }
}
