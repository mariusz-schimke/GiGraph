namespace GiGraph.Dot.Output.Writers.Edges
{
    public interface IDotEndpointGroupWriter : IDotEntityWriter
    {
        IDotEndpointWriter BeginEndpoint();
        void EndEndpoint();
    }
}