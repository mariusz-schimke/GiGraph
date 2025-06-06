using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Types.Geometry;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableSizeTest
{
    [Fact]
    public void size_setter_with_params_sets_all_properties()
    {
        var table = new DotHtmlTable();

        Assert.Null(table.Size.Width);
        Assert.Null(table.Size.Height);
        Assert.Null(table.Size.Fixed);

        table.Size.Fixed = true;
        table.Size.Set(1, 2);
        Assert.Equal(1, table.Size.Width);
        Assert.Equal(2, table.Size.Height);
        Assert.True(table.Size.Fixed);

        table.Size.Set(4, 3, false);
        Assert.Equal(4, table.Size.Width);
        Assert.Equal(3, table.Size.Height);
        Assert.False(table.Size.Fixed);
    }

    [Fact]
    public void size_setter_with_record_sets_all_properties()
    {
        var table = new DotHtmlTable();

        Assert.Null(table.Size.Width);
        Assert.Null(table.Size.Height);
        Assert.Null(table.Size.Fixed);

        var size = new DotSize(1.234, 2.94567);

        table.Size.Set(size);
        Assert.Equal(1, table.Size.Width);
        Assert.Equal(2, table.Size.Height);
        Assert.Null(table.Size.Fixed);

        size = new DotSize(1.3, 3.9, DotSizing.Fixed);
        table.Size.Set(size);
        Assert.Equal(1, table.Size.Width);
        Assert.Equal(3, table.Size.Height);
        Assert.True(table.Size.Fixed);

        size = new DotSize(1, 2, DotSizing.Auto);
        table.Size.Set(size);
        Assert.False(table.Size.Fixed);

        size = new DotSize(1, 2, DotSizing.Shape);
        table.Size.Set(size);
        Assert.False(table.Size.Fixed);
    }
}