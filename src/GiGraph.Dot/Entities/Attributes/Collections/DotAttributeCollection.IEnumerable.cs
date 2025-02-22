using System.Collections;

namespace GiGraph.Dot.Entities.Attributes.Collections;

public partial class DotAttributeCollection : IEnumerable<KeyValuePair<string, DotAttribute>>
{
    public IEnumerator<KeyValuePair<string, DotAttribute>> GetEnumerator() => _attributes.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _attributes).GetEnumerator();
}