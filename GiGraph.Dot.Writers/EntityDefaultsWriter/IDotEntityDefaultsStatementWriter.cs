﻿using GiGraph.Dot.Writers.EdgeWriters;
using GiGraph.Dot.Writers.NodeWriters;

namespace GiGraph.Dot.Writers.EntityDefaultsWriter
{
    public interface IDotEntityDefaultsStatementWriter
    {
        IDotNodeDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults();

        IDotEdgeDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults();
    }
}
