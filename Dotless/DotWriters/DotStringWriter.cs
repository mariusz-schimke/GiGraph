using Dotless.DotWriters.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotless.DotWriters
{
    // TODO: dać możliwość przekazania strumienia, żeby do niego zapisywało
    public abstract partial class DotStringWriter
    {
        protected readonly List<StringBuilder> _lines = new List<StringBuilder>();
        protected readonly DotFormattingOptions _options;
        protected readonly int _level;

        protected DotStringWriter(DotFormattingOptions options, int level = 0)
        {
            _options = options;
            _level = level;
            AppendLine();
        }

        public virtual DotStringWriter WriteToken(string token)
        {
            Append(token);
            return this;
        }

        public virtual TContext AssertContext<TContext>()
            where TContext : DotWriterContext
        {
            return this as TContext
                ?? throw new InvalidCastException($"The current DOT writer context {GetType().Name} cannot be accessed as {typeof(TContext).Name}.");
        }

        protected virtual void Append(string value)
        {
            _lines[_lines.Count - 1].Append(value);
        }

        protected virtual void AppendLine()
        {
            _lines.Add(new StringBuilder());
        }

        public static GraphContext CreateGraphWriter(string? name, bool strict, bool directed)
        {
            throw new NotImplementedException();
        }
    }
}
