using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Metadata
{
    /// <summary>
    ///     The list of DOT attribute keys.
    /// </summary>
    public static class DotAttributeKeys
    {
        [DotAttributeMetadata(DotCompatibleElements.Node | DotCompatibleElements.Cluster, DotCompatibleLayoutEngines.Patchwork, isImplemented: false)]
        public const string Area = "area";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string ArrowSize = "arrowsize";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string ArrowTail = "arrowtail";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string Arrowhead = "arrowhead";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string Background = "_background";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string Bb = "bb";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster)]
        public const string BgColor = "bgcolor";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Center = "center";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Charset = "charset";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg)]
        public const string Class = "class";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot)]
        public const string ClusterRank = "clusterrank";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is actually inherited by clusters
        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string Color = "color";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string ColorScheme = "colorscheme";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string Comment = "comment";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot)]
        public const string Compound = "compound";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Concentrate = "concentrate";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Dot)]
        public const string Constraint = "constraint";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string Damping = "Damping";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string Decorate = "decorate";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string DefaultDist = "defaultdist";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato | DotCompatibleLayoutEngines.Fdp | DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string Dim = "dim";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato | DotCompatibleLayoutEngines.Fdp | DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string Dimen = "dimen";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string Dir = "dir";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string DirEdgeConstraints = "diredgeconstraints";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Distortion = "distortion";

        [DotAttributeMetadata(DotCompatibleElements.Graph, compatibleOutputs: DotCompatibleOutputs.Bitmap | DotCompatibleOutputs.Svg)]
        public const string Dpi = "dpi";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.NotDot, isImplemented: false)]
        public const string ESep = "esep";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string EdgeHref = "edgehref";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string EdgeTarget = "edgetarget";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Cmap)]
        public const string EdgeTooltip = "edgetooltip";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string EdgeUrl = "edgeURL";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string Epsilon = "epsilon";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is actually inherited by clusters
        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string FillColor = "fillcolor";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string FixedSize = "fixedsize";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string FontColor = "fontcolor";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string FontName = "fontname";

        [DotAttributeMetadata(DotCompatibleElements.Graph, compatibleOutputs: DotCompatibleOutputs.Svg, isImplemented: false)]
        public const string FontNames = "fontnames";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string FontPath = "fontpath";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string FontSize = "fontsize";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string ForceLabels = "forcelabels";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node)]
        public const string GradientAngle = "gradientangle";

        [DotAttributeMetadata(DotCompatibleElements.Node, DotCompatibleLayoutEngines.Dot)]
        public const string Group = "group";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string HeadClip = "headclip";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string HeadHref = "headhref";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string HeadLabel = "headlabel";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string HeadLp = "head_lp";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string HeadPort = "headport";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string HeadTarget = "headtarget";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Cmap)]
        public const string HeadTooltip = "headtooltip";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string HeadUrl = "headURL";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Height = "height";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.PostScript | DotCompatibleOutputs.Map)]
        public const string Href = "href";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.PostScript | DotCompatibleOutputs.Map)]
        public const string Id = "id";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Image = "image";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string ImagePath = "imagepath";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string ImagePos = "imagepos";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string ImageScale = "imagescale";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato | DotCompatibleLayoutEngines.Fdp, isImplemented: false)]
        public const string InputScale = "inputscale";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster, DotCompatibleLayoutEngines.Fdp | DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string K = "K";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Dot)]
        public const string LHead = "lhead";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string LHeight = "lheight";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Dot)]
        public const string LTail = "ltail";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string LWidth = "lwidth";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string Label = "label";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string LabelAngle = "labelangle";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string LabelDistance = "labeldistance";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string LabelFloat = "labelfloat";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string LabelFontColor = "labelfontcolor";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string LabelFontName = "labelfontname";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string LabelFontSize = "labelfontsize";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string LabelHref = "labelhref";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster)]
        public const string LabelJust = "labeljust";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node)]
        public const string LabelLoc = "labelloc";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string LabelScheme = "label_scheme";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string LabelTarget = "labeltarget";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Cmap)]
        public const string LabelTooltip = "labeltooltip";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string LabelUrl = "labelURL";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Landscape = "landscape";

        [DotAttributeMetadata(DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, isImplemented: false)]
        public const string Layer = "layer";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string LayerListSep = "layerlistsep";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string LayerSelect = "layerselect";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string LayerSep = "layersep";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string Layers = "layers";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Layout = "layout";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Neato | DotCompatibleLayoutEngines.Fdp)]
        public const string Len = "len";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string Levels = "levels";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string LevelsGap = "levelsgap";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Edge, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string Lp = "lp";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node)]
        public const string Margin = "margin";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato | DotCompatibleLayoutEngines.Fdp, isImplemented: false)]
        public const string MaxIter = "maxiter";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot, isImplemented: false)]
        public const string McLimit = "mclimit";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Circo, isImplemented: false)]
        public const string MinDist = "mindist";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Dot)]
        public const string MinLen = "minlen";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string Mode = "mode";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string Model = "model";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string Mosek = "mosek";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot, isImplemented: false)]
        public const string NewRank = "newrank";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, isImplemented: false)]
        public const string NoJustify = "nojustify";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato, isImplemented: false)]
        public const string NoTranslate = "notranslate";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string NodeSep = "nodesep";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.NotDot, isImplemented: false)]
        public const string Normalize = "normalize";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot, isImplemented: false)]
        public const string NsLimit = "nslimit";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot, isImplemented: false)]
        public const string NsLimit1 = "nslimit1";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Node, DotCompatibleLayoutEngines.Dot)]
        public const string Ordering = "ordering";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Node)]
        public const string Orientation = "orientation";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string OutputOrder = "outputorder";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.NotDot, isImplemented: false)]
        public const string Overlap = "overlap";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Prism, isImplemented: false)]
        public const string OverlapScaling = "overlap_scaling";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Prism, isImplemented: false)]
        public const string OverlapShrink = "overlap_shrink";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Pack = "pack";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string PackMode = "packmode";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Pad = "pad";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string Page = "page";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string PageDir = "pagedir";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is actually inherited by clusters
        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster)]
        public const string PenColor = "pencolor";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is actually inherited by clusters
        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string PenWidth = "penwidth";

        [DotAttributeMetadata(DotCompatibleElements.Cluster | DotCompatibleElements.Node)]
        public const string Peripheries = "peripheries";

        [DotAttributeMetadata(DotCompatibleElements.Node, DotCompatibleLayoutEngines.Neato | DotCompatibleLayoutEngines.Fdp, isImplemented: false)]
        public const string Pin = "pin";

        [DotAttributeMetadata(DotCompatibleElements.Node | DotCompatibleElements.Edge, isImplemented: false)]
        public const string Pos = "pos";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string Quadtree = "quadtree";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string Quantum = "quantum";

        // based on the documentation, the attribute is not supported by the root graph, but when set, it is actually inherited by subgraphs
        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Subgraph, DotCompatibleLayoutEngines.Dot)]
        public const string Rank = "rank";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot)]
        public const string RankDir = "rankdir";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot | DotCompatibleLayoutEngines.Twopi)]
        public const string RankSep = "ranksep";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Ratio = "ratio";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot, isImplemented: false)]
        public const string ReMinCross = "remincross";

        [DotAttributeMetadata(DotCompatibleElements.Node, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string Rects = "rects";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Regular = "regular";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string RepulsiveForce = "repulsiveforce";

        [DotAttributeMetadata(DotCompatibleElements.Graph, compatibleOutputs: DotCompatibleOutputs.Bitmap | DotCompatibleOutputs.Svg)]
        public const string Resolution = "resolution";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Node, DotCompatibleLayoutEngines.Circo | DotCompatibleLayoutEngines.Twopi)]
        public const string Root = "root";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Rotate = "rotate";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Sfdp)]
        public const string Rotation = "rotation";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Dot)]
        public const string SameHead = "samehead";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Dot)]
        public const string SameTail = "sametail";

        [DotAttributeMetadata(DotCompatibleElements.Node, isImplemented: false)]
        public const string SamplePoints = "samplepoints";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.NotDot, isImplemented: false)]
        public const string Scale = "scale";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Dot, isImplemented: false)]
        public const string SearchSize = "searchsize";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.NotDot, isImplemented: false)]
        public const string Sep = "sep";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Shape = "shape";

        [DotAttributeMetadata(DotCompatibleElements.Node, isImplemented: false)]
        public const string ShapeFile = "shapefile";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Node | DotCompatibleElements.Edge, DotCompatibleLayoutEngines.Dot, isImplemented: false)]
        public const string ShowBoxes = "showboxes";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Sides = "sides";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Size = "size";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Skew = "skew";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Sfdp, isImplemented: false)]
        public const string Smoothing = "smoothing";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node)]
        public const string SortV = "sortv";

        [DotAttributeMetadata(DotCompatibleElements.Graph)]
        public const string Splines = "splines";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.Neato | DotCompatibleLayoutEngines.Fdp, isImplemented: false)]
        public const string Start = "start";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string Style = "style";

        [DotAttributeMetadata(DotCompatibleElements.Graph, compatibleOutputs: DotCompatibleOutputs.Svg)]
        public const string StyleSheet = "stylesheet";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string TailClip = "tailclip";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string TailHref = "tailhref";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string TailLabel = "taillabel";

        [DotAttributeMetadata(DotCompatibleElements.Edge, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string TailLp = "tail_lp";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string TailPort = "tailport";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string TailTarget = "tailtarget";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Cmap)]
        public const string TailTooltip = "tailtooltip";

        [DotAttributeMetadata(DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string TailUrl = "tailURL";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Map)]
        public const string Target = "target";

        [DotAttributeMetadata(DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.Cmap)]
        public const string Tooltip = "tooltip";

        [DotAttributeMetadata(DotCompatibleElements.Graph, compatibleOutputs: DotCompatibleOutputs.Bitmap, isImplemented: false)]
        public const string TrueColor = "truecolor";

        [DotAttributeMetadata(DotCompatibleElements.Graph | DotCompatibleElements.Cluster | DotCompatibleElements.Node | DotCompatibleElements.Edge, compatibleOutputs: DotCompatibleOutputs.Svg | DotCompatibleOutputs.PostScript | DotCompatibleOutputs.Map)]
        public const string Url = "URL";

        [DotAttributeMetadata(DotCompatibleElements.Node, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string Vertices = "vertices";

        [DotAttributeMetadata(DotCompatibleElements.Graph, isImplemented: false)]
        public const string Viewport = "viewport";

        [DotAttributeMetadata(DotCompatibleElements.Graph, DotCompatibleLayoutEngines.NotDot, isImplemented: false)]
        public const string VoroMargin = "voro_margin";

        [DotAttributeMetadata(DotCompatibleElements.Edge)]
        public const string Weight = "weight";

        [DotAttributeMetadata(DotCompatibleElements.Node)]
        public const string Width = "width";

        [DotAttributeMetadata(DotCompatibleElements.Graph, compatibleOutputs: DotCompatibleOutputs.Xdot, isImplemented: false)]
        public const string XDotVersion = "xdotversion";

        [DotAttributeMetadata(DotCompatibleElements.Node | DotCompatibleElements.Edge)]
        public const string XLabel = "xlabel";

        [DotAttributeMetadata(DotCompatibleElements.Node | DotCompatibleElements.Edge, DotCompatibleLayoutEngines.None, isImplemented: false)]
        public const string Xlp = "xlp";

        [DotAttributeMetadata(DotCompatibleElements.Node, isImplemented: false)]
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
                    Metadata = property.GetCustomAttribute<DotAttributeMetadataAttribute>()
                })
               .ToDictionary(
                    key => key.Key,
                    element => new DotAttributeMetadata(
                        element.Key,
                        element.Metadata.CompatibleElements,
                        element.Metadata.CompatibleLayoutEngines,
                        element.Metadata.CompatibleOutputs
                    )
                );
        }
    }
}