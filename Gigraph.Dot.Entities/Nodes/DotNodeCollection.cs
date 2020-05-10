using System;
using System.Collections;
using System.Collections.Generic;

namespace Gigraph.Dot.Entities.Nodes
{
    public class DotNodeCollection : IDotEntity, IEnumerable<DotNode>
    {
        protected readonly List<DotNode> _nodes = new List<DotNode>();

        public virtual DotNode Add(DotNode node)
        {
            _nodes.Add(node);
            return node;
        }

        public virtual DotNode Add(string id)
        {
            return Add(new DotNode(id));
        }

        public virtual int Remove(DotNode node)
        {
            var result = 0;

            while (_nodes.Remove(node))
            {
                result++;
            }

            return result;
        }

        public virtual int Remove(string id)
        {
            return RemoveAll(node => node.Id == id);
        }

        public virtual int RemoveAll(Predicate<DotNode> match)
        {
            return _nodes.RemoveAll(match);
        }

        public virtual void Clear()
        {
            _nodes.Clear();
        }

        public virtual IEnumerator<DotNode> GetEnumerator()
        {
            return ((IEnumerable<DotNode>)_nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotNode>)_nodes).GetEnumerator();
        }
    }
}
