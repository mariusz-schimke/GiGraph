namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The size attributes of an HTML table (&lt;table&gt;) and an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableTableCellSizeAttributes
{
    /// <summary>
    ///     Specifies the minimum width, in points, of the object. The width includes the contents, any spacing and the border. Unless
    ///     <see cref="FixedSize"/> is true, the width will be expanded to allow the contents to fit. The maximum value is 65535.
    /// </summary>
    int? Width { get; set; }

    /// <summary>
    ///     Specifies the minimum height, in points, of the object. The height includes the contents, any spacing and the border. Unless
    ///     <see cref="FixedSize"/> is true, the height will be expanded to allow the contents to fit. The maximum value is 65535.
    /// </summary>
    int? Height { get; set; }

    /// <summary>
    ///     Specifies whether the values given by the <see cref="Width"/> and <see cref="Height"/> attributes are enforced. False allows
    ///     the object to grow so that all its contents will fit (default). True fixes the object size to its given <see cref="Width"/>
    ///     and <see cref="Height"/>. Both of these attributes must be supplied.
    /// </summary>
    bool? FixedSize { get; set; }
}