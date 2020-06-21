using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Records
{
    /// <summary>
    /// Represents a record that can be used as the label of a record-based node (<see href="http://www.graphviz.org/doc/info/shapes.html#record"/>). 
    /// </summary>
    public class DotRecord : DotRecordField
    {
        protected const bool FlipDefault = false;

        /// <summary>
        /// Gets the fields of the record.
        /// </summary>
        public virtual DotRecordField[] Fields { get; }

        /// <summary>
        /// Gets or sets the value indicating whether the orientation of the record should be changed from horizontal to vertical,
        /// or the other way round. The initial orientation of a record node depends on the <see cref="IDotGraphAttributes.LayoutDirection"/>  attribute.
        /// If this attribute is <see cref="DotRankDirection.TopToBottom"/> (the default) or <see cref="DotRankDirection.BottomToTop"/>,
        /// corresponding to vertical layouts, the top-level fields in a record are displayed horizontally.
        /// If, however, this attribute is <see cref="DotRankDirection.LeftToRight"/> or <see cref="DotRankDirection.RightToLeft"/>,
        /// corresponding to horizontal layouts, the top-level fields are displayed vertically. 
        /// </summary>
        public virtual bool Flip { get; set; } = FlipDefault;

        /// <summary>
        /// Creates a new record instance.
        /// </summary>
        /// <param name="flip">Determines whether the orientation of the record should be changed from horizontal to vertical,
        /// or the other way round. The initial orientation of a record node depends on the <see cref="IDotGraphAttributes.LayoutDirection"/>  attribute.
        /// If this attribute is <see cref="DotRankDirection.TopToBottom"/> (the default) or <see cref="DotRankDirection.BottomToTop"/>,
        /// corresponding to vertical layouts, the top-level fields in a record are displayed horizontally.
        /// If, however, this attribute is <see cref="DotRankDirection.LeftToRight"/> or <see cref="DotRankDirection.RightToLeft"/>,
        /// corresponding to horizontal layouts, the top-level fields are displayed vertically.</param>
        /// <param name="fields">The fields to initialize the record with.</param>
        public DotRecord(bool flip, params DotRecordField[] fields)
        {
            Fields = fields ?? throw new ArgumentNullException(nameof(fields), "Field collection cannot be null.");
            Flip = flip;
        }

        /// <summary>
        /// Creates a new record instance.
        /// </summary>
        /// <param name="fields">The fields to initialize the record with.</param>
        public DotRecord(params DotRecordField[] fields)
            : this(FlipDefault, fields)
        {
        }

        /// <summary>
        /// Creates a new record instance.
        /// </summary>
        /// <param name="fields">The fields to initialize the record with.</param>
        /// <param name="flip">Determines whether the orientation of the record should be changed from horizontal to vertical,
        /// or the other way round. The initial orientation of a record node depends on the <see cref="IDotGraphAttributes.LayoutDirection"/>  attribute.
        /// If this attribute is <see cref="DotRankDirection.TopToBottom"/> (the default) or <see cref="DotRankDirection.BottomToTop"/>,
        /// corresponding to vertical layouts, the top-level fields in a record are displayed horizontally.
        /// If, however, this attribute is <see cref="DotRankDirection.LeftToRight"/> or <see cref="DotRankDirection.RightToLeft"/>,
        /// corresponding to horizontal layouts, the top-level fields are displayed vertically.</param>
        public DotRecord(IEnumerable<DotRecordField> fields, bool flip = FlipDefault)
            : this(flip, fields?.ToArray())
        {
        }

        /// <summary>
        /// Creates a new record instance.
        /// </summary>
        /// <param name="flip">Determines whether the orientation of the record should be changed from horizontal to vertical,
        /// or the other way round. The initial orientation of a record node depends on the <see cref="IDotGraphAttributes.LayoutDirection"/>  attribute.
        /// If this attribute is <see cref="DotRankDirection.TopToBottom"/> (the default) or <see cref="DotRankDirection.BottomToTop"/>,
        /// corresponding to vertical layouts, the top-level fields in a record are displayed horizontally.
        /// If, however, this attribute is <see cref="DotRankDirection.LeftToRight"/> or <see cref="DotRankDirection.RightToLeft"/>,
        /// corresponding to horizontal layouts, the top-level fields are displayed vertically.</param>
        /// <param name="fields">The fields to initialize the record with.</param>
        public DotRecord(bool flip, params string[] fields)
            : this(fields, flip)
        {
        }

        /// <summary>
        /// Creates a new record instance.
        /// </summary>
        /// <param name="fields">The fields to initialize the record with.</param>
        public DotRecord(params string[] fields)
            : this(FlipDefault, fields)
        {
        }

        /// <summary>
        /// Creates a new record instance.
        /// </summary>
        /// <param name="fields">The fields to initialize the record with.</param>
        /// <param name="flip">Determines whether the orientation of the record should be changed from horizontal to vertical,
        /// or the other way round. The initial orientation of a record node depends on the <see cref="IDotGraphAttributes.LayoutDirection"/>  attribute.
        /// If this attribute is <see cref="DotRankDirection.TopToBottom"/> (the default) or <see cref="DotRankDirection.BottomToTop"/>,
        /// corresponding to vertical layouts, the top-level fields in a record are displayed horizontally.
        /// If, however, this attribute is <see cref="DotRankDirection.LeftToRight"/> or <see cref="DotRankDirection.RightToLeft"/>,
        /// corresponding to horizontal layouts, the top-level fields are displayed vertically.</param>
        public DotRecord(IEnumerable<string> fields, bool flip = FlipDefault)
            : this(fields?.Select(field => new DotRecordTextField(field)), flip)
        {
        }

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules, bool hasParent)
        {
            var result = new StringBuilder();

            var braces = new[] { hasParent, Flip }.Where(x => x).ToList();
            var fields = Fields.Select(field => field.GetDotEncoded(options, syntaxRules, hasParent: true));

            braces.ForEach(brace => result.Append("{ "));
            result.Append(string.Join(" | ", fields));
            braces.ForEach(brace => result.Append(" }"));

            return result.ToString();
        }

        public static implicit operator DotRecord(DotRecordField[] fields)
        {
            return fields is {} ? new DotRecord(fields) : null;
        }

        public static implicit operator DotRecord(string[] fields)
        {
            return fields is {} ? new DotRecord(fields) : null;
        }
    }
}