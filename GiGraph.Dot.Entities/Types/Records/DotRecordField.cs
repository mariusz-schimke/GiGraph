using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Records
{
    public abstract class DotRecordField : IDotEncodableValue
    {
        protected internal abstract string GetDotEncoded(DotGenerationOptions options, bool hasParent);
        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncoded(options, hasParent: false);

        public static implicit operator DotRecordField(string text)
        {
            return new DotRecordTextField(text);
        }
    }
}