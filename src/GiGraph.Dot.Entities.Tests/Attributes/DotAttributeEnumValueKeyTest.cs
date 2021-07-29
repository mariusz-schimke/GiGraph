using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Images;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributeEnumValueKeyTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        public static IEnumerable<object[]> EnumTypes =>
            new List<object[]>
            {
                new object[] { typeof(DotAlignment) },
                new object[] { typeof(DotArrayPackingOptions) },
                new object[] { typeof(DotArrowheadParts) },
                new object[] { typeof(DotArrowheadShape) },
                new object[] { typeof(DotClusterVisualizationMode) },
                new object[] { typeof(DotCompassPoint) },
                new object[] { typeof(DotEdgeDirections) },
                new object[] { typeof(DotEdgeOrderingMode) },
                new object[] { typeof(DotEdgeShape) },
                new object[] { typeof(DotFontConvention) },
                new object[] { typeof(DotGraphScaling) },
                new object[] { typeof(DotHorizontalAlignment) },
                new object[] { typeof(DotImageScaling) },
                new object[] { typeof(DotLayoutDirection) },
                new object[] { typeof(DotNodeShape) },
                new object[] { typeof(DotNodeSizing) },
                new object[] { typeof(DotOrientation) },
                new object[] { typeof(DotPackingGranularity) },
                new object[] { typeof(DotRank) },
                new object[] { typeof(DotStyles) },
                new object[] { typeof(DotVerticalAlignment) }
            };

        [Theory]
        [MemberData(nameof(EnumTypes))]
        public void all_enum_properties_have_a_non_empty_attribute_value_assigned(Type enumType)
        {
            foreach (var value in Enum.GetValues(enumType))
            {
                var enumMember = enumType.GetMember(value.ToString()!).First();

                var attribute = enumMember?.GetCustomAttribute<DotAttributeValueAttribute>();
                Assert.NotNull(attribute);

                // null is allowed, but an empty string is considered to be a mistake
                Assert.True(attribute.Value is null || attribute.Value.Length > 0);
            }
        }

        [Theory]
        [MemberData(nameof(EnumTypes))]
        public void enum_properties_have_non_repeating_attribute_values_assigned(Type enumType)
        {
            var mapping = DotAttributeValue.GetMapping(enumType);
            foreach (var item1 in mapping)
            {
                Assert.DoesNotContain(
                    mapping,
                    item2 => !Equals(item1.Key, item2.Key) && string.Equals(item1.Value, item2.Value, StringComparison.OrdinalIgnoreCase)
                );
            }
        }
    }
}