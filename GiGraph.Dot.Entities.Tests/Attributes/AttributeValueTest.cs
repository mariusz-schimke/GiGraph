using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class AttributeValueTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        public static IEnumerable<object[]> EnumTypes =>
            new List<object[]>
            {
                new object[] { typeof(DotAlignment) },
                new object[] { typeof(DotArrayPackingOptions) },
                new object[] { typeof(DotArrowDirections) },
                new object[] { typeof(DotArrowheadParts) },
                new object[] { typeof(DotArrowheadShape) },
                new object[] { typeof(DotClusterMode) },
                new object[] { typeof(DotCompassPoint) },
                new object[] { typeof(DotEdgeOrderingMode) },
                new object[] { typeof(DotEdgeShape) },
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
                var enumMember = enumType.GetMember(value.ToString()).First();

                var attribute = enumMember?.GetCustomAttribute<DotAttributeValueAttribute>();
                Assert.NotNull(attribute);

                // null is allowed, but an empty string is considered to be a mistake
                Assert.True(attribute.Value is null || attribute.Value.Length > 0);


                // it is assumed that if a key repeats, an exception will be thrown by the mapping method on dictionary creation
                var mapping = (IEnumerable) typeof(DotAttributeValueAttribute).GetMethod(
                        nameof(DotAttributeValueAttribute.GetValueMapping)
                    )
                   .MakeGenericMethod(enumType).Invoke(null, null);

                Assert.NotEmpty(mapping);
            }
        }
    }
}