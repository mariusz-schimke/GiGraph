using System.Collections.Generic;
using GiGraph.Dot.Entities.Metadata;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributeMetadataTest
    {
        [Fact]
        public void attributes_metadata_is_compliant()
        {
            var metadata = DotAttributeKeys.GetMetadataDictionary();
            Snapshot.Match(new SortedDictionary<string, DotAttributeMetadata>(metadata), "attributes_metadata");
        }
    }
}