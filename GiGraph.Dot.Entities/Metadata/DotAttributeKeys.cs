using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     The list of DOT attribute keys.
    /// </summary>
    public static class DotAttributeKeys
    {
        [DotAttributeSupport(DotElementSupport.Node | DotElementSupport.Cluster, DotLayoutEngineSupport.Patchwork)]
        public const string Area = "area";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string ArrowSize = "arrowsize";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string ArrowTail = "arrowtail";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string Arrowhead = "arrowhead";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Background = "_background";

        [DotAttributeSupport(DotElementSupport.Graph, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string Bb = "bb";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster)]
        public const string BgColor = "bgcolor";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Center = "center";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Charset = "charset";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg)]
        public const string Class = "class";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string ClusterRank = "clusterrank";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string Color = "color";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string ColorScheme = "colorscheme";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string Comment = "comment";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string Compound = "compound";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Concentrate = "concentrate";

        [DotAttributeSupport(DotElementSupport.Edge, DotLayoutEngineSupport.Dot)]
        public const string Constraint = "constraint";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string Damping = "Damping";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string Decorate = "decorate";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string DefaultDist = "defaultdist";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp | DotLayoutEngineSupport.Sfdp)]
        public const string Dim = "dim";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp | DotLayoutEngineSupport.Sfdp)]
        public const string Dimen = "dimen";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string Dir = "dir";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string DirEdgeConstraints = "diredgeconstraints";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Distortion = "distortion";

        [DotAttributeSupport(DotElementSupport.Graph, outputFormats: DotOutputFormatSupport.Bitmap | DotOutputFormatSupport.Svg)]
        public const string Dpi = "dpi";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.NotDot)]
        public const string ESep = "esep";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string EdgeHref = "edgehref";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string EdgeTarget = "edgetarget";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string EdgeTooltip = "edgetooltip";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string EdgeUrl = "edgeURL";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string Epsilon = "epsilon";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string FillColor = "fillcolor";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string FixedSize = "fixedsize";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string FontColor = "fontcolor";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string FontName = "fontname";

        [DotAttributeSupport(DotElementSupport.Graph, outputFormats: DotOutputFormatSupport.Svg)]
        public const string FontNames = "fontnames";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string FontPath = "fontpath";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string FontSize = "fontsize";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string ForceLabels = "forcelabels";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node)]
        public const string GradientAngle = "gradientangle";

        [DotAttributeSupport(DotElementSupport.Node, DotLayoutEngineSupport.Dot)]
        public const string Group = "group";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string HeadClip = "headclip";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string HeadHref = "headhref";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string HeadLabel = "headlabel";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string HeadLp = "head_lp";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string HeadPort = "headport";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string HeadTarget = "headtarget";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string HeadTooltip = "headtooltip";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string HeadUrl = "headURL";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Height = "height";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.PostScript | DotOutputFormatSupport.Map)]
        public const string Href = "href";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.PostScript | DotOutputFormatSupport.Map)]
        public const string Id = "id";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Image = "image";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string ImagePath = "imagepath";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string ImagePos = "imagepos";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string ImageScale = "imagescale";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string InputScale = "inputscale";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster, DotLayoutEngineSupport.Fdp | DotLayoutEngineSupport.Sfdp)]
        public const string K = "K";

        [DotAttributeSupport(DotElementSupport.Edge, DotLayoutEngineSupport.Dot)]
        public const string LHead = "lhead";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string LHeight = "lheight";

        [DotAttributeSupport(DotElementSupport.Edge, DotLayoutEngineSupport.Dot)]
        public const string LTail = "ltail";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string LWidth = "lwidth";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string Label = "label";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string LabelAngle = "labelangle";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string LabelDistance = "labeldistance";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string LabelFloat = "labelfloat";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string LabelFontColor = "labelfontcolor";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string LabelFontName = "labelfontname";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string LabelFontSize = "labelfontsize";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string LabelHref = "labelhref";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster)]
        public const string LabelJust = "labeljust";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node)]
        public const string LabelLoc = "labelloc";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string LabelScheme = "label_scheme";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string LabelTarget = "labeltarget";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string LabelTooltip = "labeltooltip";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string LabelUrl = "labelURL";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Landscape = "landscape";

        [DotAttributeSupport(DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string Layer = "layer";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string LayerListSep = "layerlistsep";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string LayerSelect = "layerselect";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string LayerSep = "layersep";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Layers = "layers";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Layout = "layout";

        [DotAttributeSupport(DotElementSupport.Edge, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string Len = "len";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Levels = "levels";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string LevelsGap = "levelsgap";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string Lp = "lp";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node)]
        public const string Margin = "margin";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string MaxIter = "maxiter";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string McLimit = "mclimit";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Circo)]
        public const string MinDist = "mindist";

        [DotAttributeSupport(DotElementSupport.Edge, DotLayoutEngineSupport.Dot)]
        public const string MinLen = "minlen";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string Mode = "mode";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string Model = "model";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string Mosek = "mosek";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string NewRank = "newrank";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string NoJustify = "nojustify";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato)]
        public const string NoTranslate = "notranslate";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string NodeSep = "nodesep";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.NotDot)]
        public const string Normalize = "normalize";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string NsLimit = "nslimit";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string NsLimit1 = "nslimit1";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Node, DotLayoutEngineSupport.Dot)]
        public const string Ordering = "ordering";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Node)]
        public const string Orientation = "orientation";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string OutputOrder = "outputorder";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.NotDot)]
        public const string Overlap = "overlap";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Prism)]
        public const string OverlapScaling = "overlap_scaling";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Prism)]
        public const string OverlapShrink = "overlap_shrink";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Pack = "pack";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string PackMode = "packmode";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Pad = "pad";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Page = "page";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string PageDir = "pagedir";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster)]
        public const string PenColor = "pencolor";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string PenWidth = "penwidth";

        [DotAttributeSupport(DotElementSupport.Cluster | DotElementSupport.Node)]
        public const string Peripheries = "peripheries";

        [DotAttributeSupport(DotElementSupport.Node, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string Pin = "pin";

        [DotAttributeSupport(DotElementSupport.Node | DotElementSupport.Edge)]
        public const string Pos = "pos";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Quadtree = "quadtree";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Quantum = "quantum";

        [DotAttributeSupport(DotElementSupport.Subgraph, DotLayoutEngineSupport.Dot)]
        public const string Rank = "rank";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string RankDir = "rankdir";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot | DotLayoutEngineSupport.Twopi)]
        public const string RankSep = "ranksep";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Ratio = "ratio";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string ReMinCross = "remincross";

        [DotAttributeSupport(DotElementSupport.Node, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string Rects = "rects";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Regular = "regular";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string RepulsiveForce = "repulsiveforce";

        [DotAttributeSupport(DotElementSupport.Graph, outputFormats: DotOutputFormatSupport.Bitmap | DotOutputFormatSupport.Svg)]
        public const string Resolution = "resolution";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Node, DotLayoutEngineSupport.Circo | DotLayoutEngineSupport.Twopi)]
        public const string Root = "root";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Rotate = "rotate";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Rotation = "rotation";

        [DotAttributeSupport(DotElementSupport.Edge, DotLayoutEngineSupport.Dot)]
        public const string SameHead = "samehead";

        [DotAttributeSupport(DotElementSupport.Edge, DotLayoutEngineSupport.Dot)]
        public const string SameTail = "sametail";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string SamplePoints = "samplepoints";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.NotDot)]
        public const string Scale = "scale";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Dot)]
        public const string SearchSize = "searchsize";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.NotDot)]
        public const string Sep = "sep";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Shape = "shape";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string ShapeFile = "shapefile";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Node | DotElementSupport.Edge, DotLayoutEngineSupport.Dot)]
        public const string ShowBoxes = "showboxes";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Sides = "sides";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Size = "size";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Skew = "skew";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Smoothing = "smoothing";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node)]
        public const string SortV = "sortv";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Splines = "splines";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string Start = "start";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge)]
        public const string Style = "style";

        [DotAttributeSupport(DotElementSupport.Graph, outputFormats: DotOutputFormatSupport.Svg)]
        public const string StyleSheet = "stylesheet";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string TailClip = "tailclip";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string TailHref = "tailhref";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string TailLabel = "taillabel";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string TailLp = "tail_lp";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string TailPort = "tailport";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string TailTarget = "tailtarget";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string TailTooltip = "tailtooltip";

        [DotAttributeSupport(DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string TailUrl = "tailURL";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string Target = "target";

        [DotAttributeSupport(DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string Tooltip = "tooltip";

        [DotAttributeSupport(DotElementSupport.Graph, outputFormats: DotOutputFormatSupport.Bitmap)]
        public const string TrueColor = "truecolor";

        [DotAttributeSupport(DotElementSupport.Graph | DotElementSupport.Cluster | DotElementSupport.Node | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.PostScript | DotOutputFormatSupport.Map)]
        public const string Url = "URL";

        [DotAttributeSupport(DotElementSupport.Node, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string Vertices = "vertices";

        [DotAttributeSupport(DotElementSupport.Graph)]
        public const string Viewport = "viewport";

        [DotAttributeSupport(DotElementSupport.Graph, DotLayoutEngineSupport.NotDot)]
        public const string VoroMargin = "voro_margin";

        [DotAttributeSupport(DotElementSupport.Edge)]
        public const string Weight = "weight";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Width = "width";

        [DotAttributeSupport(DotElementSupport.Graph, outputFormats: DotOutputFormatSupport.Xdot)]
        public const string XDotVersion = "xdotversion";

        [DotAttributeSupport(DotElementSupport.Node | DotElementSupport.Edge)]
        public const string XLabel = "xlabel";

        [DotAttributeSupport(DotElementSupport.Node | DotElementSupport.Edge, outputFormats: DotOutputFormatSupport.WriteOnly)]
        public const string Xlp = "xlp";

        [DotAttributeSupport(DotElementSupport.Node)]
        public const string Z = "z";

        private static readonly Lazy<Dictionary<string, DotAttributeMetadata>> _metadata = new Lazy<Dictionary<string, DotAttributeMetadata>>(BuildMetadataDictionary);

        /// <summary>
        ///     Gets a dictionary where the key is an attribute key, and the value is its metadata (what elements, layout engines, and output
        ///     formats it is supported by).
        /// </summary>
        public static Dictionary<string, DotAttributeMetadata> MetadataDictionary => _metadata.Value;

        private static Dictionary<string, DotAttributeMetadata> BuildMetadataDictionary()
        {
            return typeof(DotAttributeKeys)
               .GetFields(BindingFlags.Static | BindingFlags.Public)
               .Select(property => new
                {
                    Key = (string) property.GetValue(null),
                    Metadata = property.GetCustomAttribute<DotAttributeSupportAttribute>()
                })
               .ToDictionary(
                    key => key.Key,
                    element => new DotAttributeMetadata(
                        element.Key,
                        element.Metadata.Elements,
                        element.Metadata.LayoutEngines,
                        element.Metadata.OutputFormats
                    )
                );
        }
    }
}