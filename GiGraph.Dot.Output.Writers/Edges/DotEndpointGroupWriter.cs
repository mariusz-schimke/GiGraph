﻿namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEndpointGroupWriter : DotEntityWriter, IDotEndpointGroupWriter
    {
        public DotEndpointGroupWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
        }

        public virtual IDotEndpointWriter BeginEndpoint()
        {
            return new DotEndpointWriter(_tokenWriter, _configuration);
        }

        public virtual void EndEndpoint()
        {
            _tokenWriter.NodeSeparator(linger: true)
               .Space(linger: true);
        }

        public override void EndComment()
        {
            _tokenWriter.Space();
        }
    }
}