using System;
using System.Linq;

namespace GiGraph.Dot.Types.EnumHelpers
{
    public static class DotPartialEnumMapper
    {
        public static TPartial ToPartial<TComplete, TPartial>(TComplete complete)
            where TComplete : Enum
            where TPartial : Enum
        {
            var partialMask = GetMask<TPartial>();
            var completeInt = Convert.ToInt32(complete);

            return (TPartial) Convert.ChangeType(
                partialMask & completeInt,
                Enum.GetUnderlyingType(typeof(TPartial))
            );
        }

        public static TComplete ToComplete<TPartial, TComplete>(TPartial partial, TComplete complete)
            where TPartial : Enum
            where TComplete : Enum
        {
            var partialMask = GetMask<TPartial>();
            var partialInt = Convert.ToInt32(partial);
            var completeInt = Convert.ToInt32(complete);

            return (TComplete) Convert.ChangeType(
                partialInt | (~partialMask & completeInt),
                Enum.GetUnderlyingType(typeof(TComplete))
            );
        }

        private static int GetMask<TEnum>()
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
               .Cast<int>()
               .Aggregate(0, (current, value) => current | value);
        }
    }
}