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
        public object Value;
        private string _string;
        private bool _isConverted;
        public Chunk Next;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Chunk(object value)
        {
            Value = value;
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
                return _string;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Init()
        {
            if (_string != null) return;
            _string = Value?.ToString();
            _isConverted = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return String;
        }
    }
}
