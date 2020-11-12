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
        [DotAttributeSupport(DotEntityTypes.Node | DotEntityTypes.Cluster, DotLayoutEngineSupport.Patchwork)]
        public const string Area = "area";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string ArrowSize = "arrowsize";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string ArrowTail = "arrowtail";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string Arrowhead = "arrowhead";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Background = "_background";

        [DotAttributeSupport(DotEntityTypes.Graph, outputFormats: DotOutputFormatSupport.Output)]
        public const string Bb = "bb";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster)]
        public const string BgColor = "bgcolor";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Center = "center";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Charset = "charset";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg)]
        public const string Class = "class";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string ClusterRank = "clusterrank";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string Color = "color";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string ColorScheme = "colorscheme";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string Comment = "comment";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string Compound = "compound";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Concentrate = "concentrate";

        [DotAttributeSupport(DotEntityTypes.Edge, DotLayoutEngineSupport.Dot)]
        public const string Constraint = "constraint";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string Damping = "Damping";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string Decorate = "decorate";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string DefaultDist = "defaultdist";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp | DotLayoutEngineSupport.Sfdp)]
        public const string Dim = "dim";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp | DotLayoutEngineSupport.Sfdp)]
        public const string Dimen = "dimen";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string Dir = "dir";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string DirEdgeConstraints = "diredgeconstraints";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Distortion = "distortion";

        [DotAttributeSupport(DotEntityTypes.Graph, outputFormats: DotOutputFormatSupport.Bitmap | DotOutputFormatSupport.Svg)]
        public const string Dpi = "dpi";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.NonDot)]
        public const string ESep = "esep";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string EdgeHref = "edgehref";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string EdgeTarget = "edgetarget";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string EdgeTooltip = "edgetooltip";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string EdgeUrl = "edgeURL";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string Epsilon = "epsilon";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string FillColor = "fillcolor";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string FixedSize = "fixedsize";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string FontColor = "fontcolor";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string FontName = "fontname";

        [DotAttributeSupport(DotEntityTypes.Graph, outputFormats: DotOutputFormatSupport.Svg)]
        public const string FontNames = "fontnames";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string FontPath = "fontpath";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string FontSize = "fontsize";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string ForceLabels = "forcelabels";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node)]
        public const string GradientAngle = "gradientangle";

        [DotAttributeSupport(DotEntityTypes.Node, DotLayoutEngineSupport.Dot)]
        public const string Group = "group";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string HeadClip = "headclip";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string HeadHref = "headhref";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string HeadLabel = "headlabel";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Output)]
        public const string HeadLp = "head_lp";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string HeadPort = "headport";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string HeadTarget = "headtarget";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string HeadTooltip = "headtooltip";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string HeadUrl = "headURL";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Height = "height";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.PostScript | DotOutputFormatSupport.Map)]
        public const string Href = "href";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.PostScript | DotOutputFormatSupport.Map)]
        public const string Id = "id";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Image = "image";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string ImagePath = "imagepath";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string ImagePos = "imagepos";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string ImageScale = "imagescale";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string InputScale = "inputscale";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster, DotLayoutEngineSupport.Fdp | DotLayoutEngineSupport.Sfdp)]
        public const string K = "K";

        [DotAttributeSupport(DotEntityTypes.Edge, DotLayoutEngineSupport.Dot)]
        public const string LHead = "lhead";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster, outputFormats: DotOutputFormatSupport.Output)]
        public const string LHeight = "lheight";

        [DotAttributeSupport(DotEntityTypes.Edge, DotLayoutEngineSupport.Dot)]
        public const string LTail = "ltail";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster, outputFormats: DotOutputFormatSupport.Output)]
        public const string LWidth = "lwidth";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string Label = "label";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string LabelAngle = "labelangle";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string LabelDistance = "labeldistance";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string LabelFloat = "labelfloat";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string LabelFontColor = "labelfontcolor";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string LabelFontName = "labelfontname";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string LabelFontSize = "labelfontsize";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string LabelHref = "labelhref";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster)]
        public const string LabelJust = "labeljust";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node)]
        public const string LabelLoc = "labelloc";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string LabelScheme = "label_scheme";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string LabelTarget = "labeltarget";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string LabelTooltip = "labeltooltip";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string LabelUrl = "labelURL";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Landscape = "landscape";

        [DotAttributeSupport(DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string Layer = "layer";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string LayerListSep = "layerlistsep";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string LayerSelect = "layerselect";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string LayerSep = "layersep";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Layers = "layers";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Layout = "layout";

        [DotAttributeSupport(DotEntityTypes.Edge, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string Len = "len";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Levels = "levels";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string LevelsGap = "levelsgap";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Output)]
        public const string Lp = "lp";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node)]
        public const string Margin = "margin";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string MaxIter = "maxiter";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string McLimit = "mclimit";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Circo)]
        public const string MinDist = "mindist";

        [DotAttributeSupport(DotEntityTypes.Edge, DotLayoutEngineSupport.Dot)]
        public const string MinLen = "minlen";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string Mode = "mode";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string Model = "model";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string Mosek = "mosek";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string NewRank = "newrank";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string NoJustify = "nojustify";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Neato)]
        public const string NoTranslate = "notranslate";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string NodeSep = "nodesep";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.NonDot)]
        public const string Normalize = "normalize";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string NsLimit = "nslimit";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string NsLimit1 = "nslimit1";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Node, DotLayoutEngineSupport.Dot)]
        public const string Ordering = "ordering";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Node)]
        public const string Orientation = "orientation";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string OutputOrder = "outputorder";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.NonDot)]
        public const string Overlap = "overlap";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Prism)]
        public const string OverlapScaling = "overlap_scaling";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Prism)]
        public const string OverlapShrink = "overlap_shrink";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Pack = "pack";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string PackMode = "packmode";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Pad = "pad";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Page = "page";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string PageDir = "pagedir";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster)]
        public const string PenColor = "pencolor";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is inherited by clusters
        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string PenWidth = "penwidth";

        [DotAttributeSupport(DotEntityTypes.Cluster | DotEntityTypes.Node)]
        public const string Peripheries = "peripheries";

        [DotAttributeSupport(DotEntityTypes.Node, DotLayoutEngineSupport.Neato | DotLayoutEngineSupport.Fdp)]
        public const string Pin = "pin";

        [DotAttributeSupport(DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string Pos = "pos";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Quadtree = "quadtree";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Quantum = "quantum";

        [DotAttributeSupport(DotEntityTypes.Subgraph, DotLayoutEngineSupport.Dot)]
        public const string Rank = "rank";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string RankDir = "rankdir";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot | DotLayoutEngineSupport.Twopi)]
        public const string RankSep = "ranksep";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Ratio = "ratio";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string ReMinCross = "remincross";

        [DotAttributeSupport(DotEntityTypes.Node, outputFormats: DotOutputFormatSupport.Output)]
        public const string Rects = "rects";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Regular = "regular";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string RepulsiveForce = "repulsiveforce";

        [DotAttributeSupport(DotEntityTypes.Graph, outputFormats: DotOutputFormatSupport.Bitmap | DotOutputFormatSupport.Svg)]
        public const string Resolution = "resolution";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Node, DotLayoutEngineSupport.Circo | DotLayoutEngineSupport.Twopi)]
        public const string Root = "root";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Rotate = "rotate";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Rotation = "rotation";

        [DotAttributeSupport(DotEntityTypes.Edge, DotLayoutEngineSupport.Dot)]
        public const string SameHead = "samehead";

        [DotAttributeSupport(DotEntityTypes.Edge, DotLayoutEngineSupport.Dot)]
        public const string SameTail = "sametail";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string SamplePoints = "samplepoints";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.NonDot)]
        public const string Scale = "scale";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Dot)]
        public const string SearchSize = "searchsize";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.NonDot)]
        public const string Sep = "sep";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Shape = "shape";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string ShapeFile = "shapefile";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Node | DotEntityTypes.Edge, DotLayoutEngineSupport.Dot)]
        public const string ShowBoxes = "showboxes";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Sides = "sides";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Size = "size";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Skew = "skew";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Sfdp)]
        public const string Smoothing = "smoothing";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node)]
        public const string SortV = "sortv";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Splines = "splines";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.Fdp)]
        public const string Start = "start";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string Style = "style";

        [DotAttributeSupport(DotEntityTypes.Graph, outputFormats: DotOutputFormatSupport.Svg)]
        public const string StyleSheet = "stylesheet";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string TailClip = "tailclip";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string TailHref = "tailhref";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string TailLabel = "taillabel";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Output)]
        public const string TailLp = "tail_lp";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string TailPort = "tailport";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string TailTarget = "tailtarget";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string TailTooltip = "tailtooltip";

        [DotAttributeSupport(DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string TailUrl = "tailURL";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Map)]
        public const string Target = "target";

        [DotAttributeSupport(DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.Cmap)]
        public const string Tooltip = "tooltip";

        [DotAttributeSupport(DotEntityTypes.Graph, outputFormats: DotOutputFormatSupport.Bitmap)]
        public const string TrueColor = "truecolor";

        [DotAttributeSupport(DotEntityTypes.Graph | DotEntityTypes.Cluster | DotEntityTypes.Node | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Svg | DotOutputFormatSupport.PostScript | DotOutputFormatSupport.Map)]
        public const string Url = "URL";

        [DotAttributeSupport(DotEntityTypes.Node, outputFormats: DotOutputFormatSupport.Output)]
        public const string Vertices = "vertices";

        [DotAttributeSupport(DotEntityTypes.Graph)]
        public const string Viewport = "viewport";

        [DotAttributeSupport(DotEntityTypes.Graph, DotLayoutEngineSupport.NonDot)]
        public const string VoroMargin = "voro_margin";

        [DotAttributeSupport(DotEntityTypes.Edge)]
        public const string Weight = "weight";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Width = "width";

        [DotAttributeSupport(DotEntityTypes.Graph, outputFormats: DotOutputFormatSupport.Xdot)]
        public const string XDotVersion = "xdotversion";

        [DotAttributeSupport(DotEntityTypes.Node | DotEntityTypes.Edge)]
        public const string XLabel = "xlabel";

        [DotAttributeSupport(DotEntityTypes.Node | DotEntityTypes.Edge, outputFormats: DotOutputFormatSupport.Output)]
        public const string Xlp = "xlp";

        [DotAttributeSupport(DotEntityTypes.Node)]
        public const string Z = "z";

        // TODO: można dodać wtedy do GetKeyMapping() parametr określający engine
        // można też dodać metodę z lambdą na kolekcji atrybutów, która pobiera metadane dla atrybutu
        // można do GetKeyMapping() dodać zwracania ścieżki do właściwości oraz od razu metadanych właściwości

        /// <summary>
        ///     Gets a dictionary where the key is an attribute key, and the value is a flags enumeration indicating what DOT elements the
        ///     key is supported by.
        /// </summary>
        public static Dictionary<string, DotEntityTypes> GetSupportMapping()
        {
            return typeof(DotAttributeKeys)
               .GetFields(BindingFlags.Static | BindingFlags.Public)
               .Select(property => new
                {
                    Key = (string) property.GetValue(null),
                    property.GetCustomAttribute<DotAttributeSupportAttribute>().Entities
                })
               .ToDictionary(
                    key => key.Key,
                    value => value.Entities
                );
        }
    }
}