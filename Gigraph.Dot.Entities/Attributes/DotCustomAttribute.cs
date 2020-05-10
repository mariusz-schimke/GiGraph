namespace Gigraph.Dot.Entities.Attributes
{
    public class DotCustomAttribute : DotAttribute<string>
    {
        public DotCustomAttribute(string key, string value)
            : base(key, value)
        {
        }
    }
}
