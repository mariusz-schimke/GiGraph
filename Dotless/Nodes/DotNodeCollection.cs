using Dotless.Core;
using System.Collections;
using System.Collections.Generic;

namespace Dotless.Nodes
{
    public class DotNodeCollection : IDotEntity, IEnumerable<DotNode>
    {
        protected readonly List<DotNode> _nodes = new List<DotNode>();

        public DotNode Add(DotNode node)
        {
            _nodes.Add(node);
            return node;
        }

        public DotNode Add(string id)
        {
            return Add(new DotNode(id));
        }

        public int Remove(DotNode node)
        {
            var result = 0;

            while (_nodes.Remove(node))
            {
                result++;
            }

            return result;
        }

        public int Remove(string id)
        {
            return _nodes.RemoveAll(node => node.Id == id);
        }

        public IEnumerator<DotNode> GetEnumerator()
        {
            return ((IEnumerable<DotNode>)_nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotNode>)_nodes).GetEnumerator();
        }
    }
}
