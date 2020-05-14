﻿using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeCollectionWriter : IDotEntityWriter
    {
        IDotEdgeWriter BeginEdge();
        void EndEdge();
    }
}
