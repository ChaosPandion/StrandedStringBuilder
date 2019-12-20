using System;
using System.Collections.Generic;
using System.Text;

namespace StrandedStringBuilder
{
    internal sealed class Chunk
    {
        public object Value;
        private string _string;
        private bool _isConverted;
        public Chunk Next;

        public Chunk(object value)
        {
            Value = value;
        }

        public int Length
        {
            get
            {
                if (!_isConverted) Init();
                return _string?.Length ?? 0;
            }
        }

        public string String
        {
            get
            {
                if (!_isConverted) Init();
                return _string;
            }
        }

        private void Init()
        {
            if (_string != null) return;
            _string = Value?.ToString();
            _isConverted = true;
        }

        public override string ToString()
        {
            return String;
        }
    }
}
