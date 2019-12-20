using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StrandedStringBuilder
{
    /// <summary>
    /// Represents a mutable string of characters.
    /// </summary>
    /// <remarks>
    /// This is not thread safe.
    /// </remarks>
    public sealed class StringBuilder
    {
        private Chunk _first;
        private Chunk _last;

        /// <summary>
        /// Gets the number of characters.
        /// </summary>
        public int Count
        {
            get
            {
                var len = 0;
                var chunk = _first;
                while (chunk != null)
                {
                    len += chunk.Length;
                    chunk = chunk.Next;
                }
                return len;
            }
        }

        /// <summary>
        /// Appends the supplied <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to append.</param>
        /// <returns>The current instance of <see cref="StringBuilder"/>.</returns>
        public StringBuilder Append(object value)
        {
            var next = new Chunk(value);
            if (_first == null)
            {
                _first = _last = next;
            }
            else
            {
                _last.Next = next;
                _last = next;
            }
            return this;
        }

        /// <summary>
        /// Removes a sequence of characters at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The starting index.</param>
        /// <param name="length">The length to remove.</param>
        /// <returns>The current instance of <see cref="StringBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index"/> less than zero.
        /// <paramref name="length"/> less than zero.
        /// <paramref name="index"/> out of range.
        /// <paramref name="length"/> out of range.
        /// </exception>
        public StringBuilder Remove(int index, int length)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            if (length == 0)
                return this;

            var lengthAtChunk = 0;
            var previous = default(Chunk);
            var chunkWithIndex = _first;

            while (chunkWithIndex != null)
            {
                lengthAtChunk += chunkWithIndex.Length;
                if (index < lengthAtChunk) break;
                previous = chunkWithIndex;
                chunkWithIndex = chunkWithIndex.Next;
            }

            if (chunkWithIndex == null)
                throw new ArgumentOutOfRangeException(nameof(index));

            var lengthPastIndex = lengthAtChunk - index;
            var lengthBeforeIndex = chunkWithIndex.Length - lengthPastIndex;
            var lengthRemaining = Math.Max(0, length - lengthPastIndex);
            var chunksPassed = 0;
            var firstChunk = default(Chunk);
            var secondChunk = default(Chunk);

            var before = chunkWithIndex.String.Substring(0, lengthBeforeIndex);
            var after = chunkWithIndex.String.Substring(lengthBeforeIndex + Math.Min(length, lengthPastIndex));

            if (lengthRemaining > 0)
            {
                var current = chunkWithIndex.Next;
                while (lengthRemaining > 0 && current != null)
                {
                    chunksPassed++;
                    if (lengthRemaining >= current.Length)
                    {
                        lengthRemaining -= current.Length;
                        current = current.Next;
                        if (lengthRemaining == 0)
                        {
                            secondChunk = current;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        if (current.Length == lengthRemaining)
                        {
                            lengthRemaining = 0;
                            break;
                        }
                        secondChunk = new Chunk(current.String.Substring(lengthRemaining));
                        secondChunk.Next = current.Next;
                        lengthRemaining = 0;
                        break;
                    }
                }
            }

            if (lengthRemaining > 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            if (before.Length > 0)
                firstChunk = new Chunk(before);

            if (secondChunk == null && after.Length > 0)
                secondChunk = new Chunk(after);

            firstChunk = firstChunk ?? new Chunk("");
            secondChunk = secondChunk ?? new Chunk("");
            firstChunk.Next = secondChunk;

            if (chunksPassed == 0 && secondChunk.Next == null)
            {
                secondChunk.Next = chunkWithIndex.Next;
            }

            if (previous != null)
            {
                previous.Next = firstChunk;
            }
            else
            {
                _first = firstChunk;
            }
            if (secondChunk.Next == null)
            {
                _last = secondChunk;
            }

            return this;
        }

        /// <summary>
        /// Replaces all occurrences of <paramref name="findValue"/> with <paramref name="replaceValue"/>.
        /// </summary>
        /// <param name="findValue">The value to find.</param>
        /// <param name="replaceValue">The value to replace wherever <paramref name="findValue"/> is found.</param>
        /// <returns>The current instance of <see cref="StringBuilder"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="findValue"/> is null or empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="replaceValue"/> is null.</exception>
        public StringBuilder Replace(string findValue, string replaceValue)
        {
            if (string.IsNullOrEmpty(findValue))
                throw new ArgumentException(nameof(findValue));
            if (replaceValue == null)
                throw new ArgumentNullException(nameof(replaceValue));

            var s = ToString().Replace(findValue, replaceValue);
            _first = _last = new Chunk(s);

            return this;
        }

        /// <summary>
        /// Inserts the provided <paramref name="value"/> at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index to insert the value.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>The current instance of <see cref="StringBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index"/> less than zero.
        /// <paramref name="index"/> greater than the length.
        /// </exception>
        public StringBuilder Insert(int index, object value)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (_first == null)
                throw new ArgumentOutOfRangeException(nameof(index));

            var len = 0;
            var prev = default(Chunk);
            var chunk = _first;

            while (chunk != null)
            {
                var prevLen = len;
                len += chunk.Length;
                if (index < len)
                {
                    var next = chunk.Next;
                    var leftLen = index - prevLen;
                    var left = new Chunk(chunk.String.Substring(0, leftLen));
                    var right = new Chunk(chunk.String.Substring(leftLen));
                    var middle = new Chunk(value);
                    left.Next = middle;
                    middle.Next = right;
                    right.Next = next;
                    if (next == null)
                    {
                        _last = right;
                    }
                    if (prev == null)
                    {
                        _first = left;
                    }
                    else
                    {
                        prev.Next = left;
                    }
                    return this;
                }
                prev = chunk;
                chunk = chunk.Next;
            }

            throw new ArgumentOutOfRangeException(nameof(index));
        }

        /// <summary>
        /// Converts the value of this instance to a System.String.
        /// </summary>
        /// <returns>A string whose value is the same as this instance.</returns>
        public override unsafe string ToString()
        {
            var array = new char[Count];
            fixed (char* target = array)
            {
                var i = 0;
                var chunk = _first;
                while (chunk != null)
                {
                    var value = chunk.String;
                    fixed (char* source = value)
                    {
                        var vl = value.Length;
                        for (int j = 0; j < vl; j++)
                        {
                            target[i++] = source[j];
                        }
                    }
                    chunk = chunk.Next;
                }
                return new string(target, 0, array.Length);
            }
        }
    }
}
