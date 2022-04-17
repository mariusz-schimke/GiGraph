using System.Collections.Generic;
using GiGraph.Dot.Output.Metadata;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

public class DotAttributeMetadataTest
{
    [Fact]
    public void attributes_metadata_is_compliant_with_the_documentation()
    {
        Snapshot.Match(
            new SortedDictionary<string, DotAttributeMetadata>(DotAttributeKeys.MetadataDictionary),
            "attribute_metadata_map"
        );
    }
}