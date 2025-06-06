﻿using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Graphs.Charset;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the label to display on the graph. It may be plain text (<see cref="string"/>) or HTML (
    ///         <see cref="DotHtmlString"/>). See also <see cref="DotFormattedTextBuilder"/> for text justification and simple formatting
    ///         and <see cref="DotHtmlBuilder"/> for custom text styling and defining tables. The latter one gives the most possibilities
    ///         (specifying font, size, color, style, images, etc.).
    ///     </para>
    ///     <para>
    ///         Examples:
    ///         <list type="bullet">
    ///             <item>
    ///                 <description>
    ///                     <see cref="Label"/> = "My label";
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <description>
    ///                     <see cref="Label"/> = new <see cref="DotHtmlBold"/>("My label");
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <description>
    ///                     <see cref="Label"/> = (<see cref="DotHtmlString"/>) "&lt;b&gt;My label&lt;/b&gt;";
    ///                 </description>
    ///             </item>
    ///         </list>
    ///     </para>
    /// </summary>
    DotLabel? Label { get; set; }

    /// <summary>
    ///     Specifies the character encoding used when interpreting string input as a text label. The default value is "UTF-8". The other
    ///     legal value is "iso-8859-1" or, equivalently, "Latin1". The charset attribute is case-insensitive. Note that if the character
    ///     encoding used in the input does not match the charset value, the resulting output may be very strange. See also
    ///     <see cref="DotCharsets"/> to use predefined values.
    /// </summary>
    /// <remarks>
    ///     Following are the legal values:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 "utf-8" / "utf8" (default value),
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 "iso-8859-1" / "ISO_8859-1" / "ISO8859-1" / "ISO-IR-100" / "Latin1" / "l1" / "latin-1",
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 "big-5" / "big5" (see
    ///                 <see href="https://en.wikipedia.org/wiki/Big5">
    ///                     the Big-5 Chinese encoding
    ///                 </see>
    ///                 ).
    ///             </description>
    ///         </item>
    ///     </list>
    /// </remarks>
    string? Charset { get; set; }

    /// <summary>
    ///     Comments are inserted into output. Device-dependent.
    /// </summary>
    string? Comment { get; set; }

    /// <summary>
    ///     Tooltip annotation attached to the graph (svg, cmap only). If unset, Graphviz will use the <see cref="Label"/> attribute if
    ///     defined.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }

    /// <summary>
    ///     <para>
    ///         Specifies a list of directories in which to look for image files used by nodes, referenced either by the
    ///         <see cref="DotNodeImageAttributes.Path"/> of their <see cref="IDotNodeRootAttributes.Image"/> attributes, or from the IMG
    ///         element in HTML-like labels. The string should be a list of (absolute or relative) path names, each separated by a
    ///         semicolon (for Windows) or a colon (all other OS). The first directory in which a file of the given name is found will be
    ///         used to load the image.
    ///     </para>
    ///     <para>
    ///         If not set, relative path names for image files will be interpreted with respect to the current working directory.
    ///     </para>
    /// </summary>
    string? ImageDirectories { get; set; }

    /// <summary>
    ///     <para>
    ///         Allows the graph author to provide an identifier for graph objects which is to be included in the output (svg,
    ///         postscript, map only).
    ///     </para>
    ///     <para>
    ///         Normal <see cref="DotEscapeString.NodeIdPlaceholder"/>, <see cref="DotEscapeString.EdgeDefinitionPlaceholder"/>,
    ///         <see cref="DotEscapeString.GraphIdPlaceholder"/> substitutions can be applied (see <see cref="DotFormattedTextBuilder"/>
    ///         ). Note, however, that <see cref="DotEscapeString.EdgeDefinitionPlaceholder"/> does not provide a unique ID for
    ///         multi-edges.
    ///     </para>
    ///     <para>
    ///         If provided, it is the responsibility of the provider to keep ID values unique for its intended downstream use. If no ID
    ///         attribute is provided, then a unique internal ID is used. However, this value is unpredictable by the graph writer.
    ///     </para>
    ///     <para>
    ///         If the graph provides an ID attribute, this will be used as a prefix for internally generated attributes. By making
    ///         internally-used attributes distinct, the user can include multiple image maps in the same document.
    ///     </para>
    /// </summary>
    DotEscapeString? ObjectId { get; set; }
}