using Dotless.DotBuilders.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.DotBuilders
{
    public class DotTokenCollectionReader
    {
        protected readonly ICollection<IDotToken> _tokens;
        private int _position = 0;

        public int Position
        {
            get => _position;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Position));
                }

                _position = value;
            }
        }
        public DotTokenCollectionReader(ICollection<IDotToken> tokens)
        {
            _tokens = tokens;
        }

        public IDotToken? Current
        {
            get
            {
                return Position < _tokens.Count
                    ? _tokens.ElementAt(Position)
                    : null;
            }
        }

        public bool CurrentIs<T>()
            where T : IDotToken
        {
            return Current is T;
        }

        public bool IsLast => Position == _tokens.Count - 1;

        public bool Next()
        {
            return Next(out _);
        }

        public bool Next(out IDotToken? token)
        {
            if (Peek(out token))
            {
                Position++;
                return true;
            }

            return false;
        }

        public bool NextUntil<TToken>(out IDotToken? token)
            where TToken : IDotToken
        {
            if (Peek<TToken>())
            {
                Next(out token);
                return false;
            }

            return Next(out token);
        }

        public bool Peek(out IDotToken? token)
        {
            if (!IsLast)
            {
                token = _tokens.ElementAt(Position + 1);
                return true;
            }

            token = null;
            return false;
        }

        public IDotToken? Peek()
        {
            Peek(out var token);
            return token;
        }

        public bool Peek<TToken>()
            where TToken : IDotToken
        {
            return Peek(out var token) && token is TToken;
        }

        public bool PeekUntil<TSearchedToken, TStopToken>()
            where TSearchedToken : IDotToken
            where TStopToken : IDotToken
        {
            foreach (var token in _tokens.Skip(Position + 1))
            {
                if (token is TSearchedToken)
                {
                    return true;
                }

                if (token is TStopToken)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
