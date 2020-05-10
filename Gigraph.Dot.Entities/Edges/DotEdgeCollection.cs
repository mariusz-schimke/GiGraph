using System;
using System.Collections;
using System.Collections.Generic;

namespace Gigraph.Dot.Entities.Edges
{
    public class DotEdgeCollection : IDotEntity, IEnumerable<DotEdge>
    {
        protected readonly List<DotEdge> _edges = new List<DotEdge>();

        public virtual DotEdge Add(DotEdge edge)
        {
            _edges.Add(edge);
            return edge;
        }

        public virtual DotEdge Add(string leftNodeId, string rightNodeId)
        {
            return Add(new DotEdge(leftNodeId, rightNodeId));
        }

        public virtual int Remove(DotEdge node)
        {
            var result = 0;

            while (_edges.Remove(node))
            {
                result++;
            }

            return result;
        }

        public virtual int Remove(string leftNodeId, string rightNodeId)
        {
            return RemoveAll(edge => edge.LeftNodeId == leftNodeId &&
                                     edge.RightNodeId == rightNodeId);
        }

        public virtual int RemoveAll(Predicate<DotEdge> match)
        {
            return _edges.RemoveAll(match);
        }

        public virtual void Clear()
        {
            _edges.Clear();
        }

        public virtual IEnumerator<DotEdge> GetEnumerator()
        {
            return ((IEnumerable<DotEdge>)_edges).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotEdge>)_edges).GetEnumerator();
        }
    }
}
