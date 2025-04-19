using GiGraph.Dot.Output.EnumHelpers;
using GiGraph.Dot.Types.Html.Table;
using GiGraph.Dot.Types.Styling;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public class DotEnumMetadataTest
{
    [Fact]
    public void returns_all_set_non_zero_flags()
    {
        var metadata = new DotEnumMetadata(typeof(DotStyles));

        var flags = metadata.GetSetFlags((DotStyles) 0);
        Assert.Empty(flags);

        flags = metadata.GetSetFlags(DotStyles.Bold | DotStyles.Dashed | DotStyles.Invisible);
        Assert.Equal(3, flags.Length);
    }

    [Fact]
    public void returns_all_non_compound_flags()
    {
        var metadata = new DotEnumMetadata(typeof(DotHtmlTableBorders));

        var flags = metadata.GetSetFlags(DotHtmlTableBorders.Horizontal);
        Assert.Equal(2, flags.Length);
    }
}