using System.Collections.Generic;
using GiGraph.Dot.Entities.Metadata;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributeMetadataTest
    {
        [Fact]
        public void attributes_metadata_is_compliant_with_the_documentation()
        {
            var metadata = DotAttributeKeys.GetMetadataDictionary();
            Snapshot.Match(new SortedDictionary<string, DotAttributeMetadata>(metadata), "attribute_metadata_map");
        }
    }
}