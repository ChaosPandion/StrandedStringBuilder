using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace StrandedStringBuilder
{
    [DebuggerStepThrough]
    internal sealed class Chunk
    {
        public object? Value;
        private string? _string;
        private bool _isConverted;
        public Chunk? Next;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Chunk(object? value)
        {
            Value = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Chunk(string value)
        {
            Value = value;
            _isConverted = true;
            _string = value;
        }

        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (!_isConverted) Init();
                return _string?.Length ?? 0;
            }
        }

        public string String
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (!_isConverted) Init();
                return _string!;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Init()
        {
            if (_isConverted) return;
            _string = Value switch  
            {
                null => string.Empty,
                StringProducer sp => sp(),
                Func<string> f => f(),
                _ => Value.ToString()
            } ?? string.Empty;
            _isConverted = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return String;
        }

        public static Chunk Empty => new(string.Empty);
        public static Chunk NewLine => new(Environment.NewLine);
    }
}
