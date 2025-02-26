using System.Reflection;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Enums;

public class DotEnumsTest
{
    public static IEnumerable<object[]> EnumTypes { get; } = GetAllEnumTypes()
        .Select(t => new[] { t })
        .ToArray();

    public static IEnumerable<Type> GetAllEnumTypes()
    {
        // get only the enum types used as attribute values (they belong to the Types namespace)
        var types = Assembly.LoadFrom("GiGraph.Dot.dll")
            .GetTypes()
            .Where(t => t.IsEnum)
            .Where(t => t.Namespace?.StartsWith("GiGraph.Dot.Types") is true)
            .ToArray();

        Assert.NotEmpty(types);
        return types;
    }

    [Theory]
    [MemberData(nameof(EnumTypes))]
    public void all_enums_are_of_int_type(Type enumType)
    {
        // the thing is that some enum mapping methods and those that perform bitwise operations assume that the enums are of type int
        // (otherwise they will throw an exception in runtime)
        Assert.True(Enum.GetUnderlyingType(enumType) == typeof(int));
    }
}