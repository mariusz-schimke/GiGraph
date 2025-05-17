using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Types.Edges;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Endpoints;

public class DotEndpointTest
{
    [Fact]
    public void endpoint_id_must_not_be_null()
    {
        Assert.Throws<ArgumentNullException>(() => new DotEndpoint(null!, port: null));
    }

    [Fact]
    public void endpoint_port_is_null()
    {
        Assert.Null(new DotEndpoint("", port: null).Port);
        Assert.Null(new DotEndpoint("", compassPoint: null).Port);
        Assert.Null(new DotEndpoint("", portName: null, compassPoint: null).Port);
    }

    [Fact]
    public void endpoint_port_is_not_null()
    {
        Assert.NotNull(new DotEndpoint("", port: new DotEndpointPort(DotCompassPoint.Default)).Port);
        Assert.NotNull(new DotEndpoint("", compassPoint: DotCompassPoint.Default).Port);
        Assert.NotNull(new DotEndpoint("", portName: "", compassPoint: null).Port);
        Assert.NotNull(new DotEndpoint("", portName: null, compassPoint: DotCompassPoint.Default).Port);

        var ep = new DotEndpoint("", portName: "", compassPoint: DotCompassPoint.Default);
        Assert.NotNull(ep.Port);
        Assert.Equal("", ep.Port.Name);
        Assert.Equal(DotCompassPoint.Default, ep.Port.CompassPoint);
    }

    [Fact]
    public void endpoints_are_equal()
    {
        var id1 = new DotEndpoint("1");
        var id2 = new DotEndpoint("1");
        Assert.True(id1.IsSameEndpoint(id2));
    }

    [Fact]
    public void endpoints_are_not_equal()
    {
        var id1 = new DotEndpoint("1");
        var id2 = new DotEndpoint("2");
        Assert.False(id1.IsSameEndpoint(id2));
    }

    [Fact]
    public void endpoint_and_cluster_endpoint_are_not_equal()
    {
        var id1 = new DotEndpoint("1");
        var id2 = new DotClusterEndpoint("1");
        Assert.False(id1.IsSameEndpoint(id2));
    }
}