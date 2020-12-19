using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Identifiers
{
    /// <summary>
    ///     Represents element identifier.
    /// </summary>
    public class DotId : IDotEncodable
    {
        protected readonly string _id;

        /// <summary>
        ///     Creates a new element identifier.
        /// </summary>
        /// <param name="id">
        ///     The identifier to use.
        /// </param>
        public DotId(string id)
        {
            _id = id;
        }

        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        public override string ToString()
        {
            return _id;
        }

        protected internal virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            // use the same identifier escaping pipeline as the one used by entity generators
            return syntaxRules.IdentifierEscaper.Escape(FormatId(options, syntaxRules));
        }

        protected virtual string FormatId(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return _id;
        }

        public static implicit operator string(DotId id)
        {
            return id?._id;
        }

        public static implicit operator DotId(string id)
        {
            return id is { } ? new DotId(id) : null;
        }

        public override bool Equals(object obj)
        {
            return obj is DotId id &&
                   id._id == _id &&
                   id.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            return Tuple.Create(_id, GetType()).GetHashCode();
        }
    }
}