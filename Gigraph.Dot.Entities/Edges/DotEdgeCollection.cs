using System.Collections;
using System.Collections.Generic;

namespace Gigraph.Dot.Entities.Edges
{
    public class DotEdgeCollection : IDotEntity, IEnumerable<DotEdge>
    {
        protected readonly List<DotEdge> _edges = new List<DotEdge>();

        public DotEdge Add(DotEdge edge)
        {
            _edges.Add(edge);
            return edge;
        }

        public DotEdge Add(string leftNodeId, string rightNodeId)
        {
            return Add(new DotEdge(leftNodeId, rightNodeId));
        }

        public int Remove(DotEdge node)
        {
            var result = 0;

            while (_edges.Remove(node))
            {
                result++;
            }

            return result;
        }

        public int Remove(string leftNodeId, string rightNodeId)
        {
            return _edges.RemoveAll(edge => edge.LeftNodeId == leftNodeId &&
                                            edge.RightNodeId == rightNodeId);
        }

        public IEnumerator<DotEdge> GetEnumerator()
        {
            return ((IEnumerable<DotEdge>)_edges).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotEdge>)_edges).GetEnumerator();
        }
    }
}
