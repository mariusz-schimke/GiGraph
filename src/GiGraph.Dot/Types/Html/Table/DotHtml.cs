using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     HTML table or table cell style options.
/// </summary>
/// <param name="RoundedCorners">
///     True indicates that the table will have rounded corners. This probably works best if the outmost cells have no borders, or
///     their cell spacing is sufficiently large. If it is desirable to have borders around the cells, use HR (
///     <see cref="DotHtmlHorizontalRule"/>) and VR (<see cref="DotHtmlVerticalRule"/>) elements, or the column and row formatting
///     attributes of the table.
/// </param>
/// <param name="RadialFill">
///     True indicates that the table will have a radial gradient fill if a <see cref="DotGradientColor"/> is specified for the
///     background.
/// </param>
public record DotHtmlTableStyleOptions(bool? RoundedCorners = null, bool? RadialFill = null);