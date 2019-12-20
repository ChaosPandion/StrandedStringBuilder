using System;
using System.Runtime.CompilerServices;

namespace MagicStringBuilder
{
    public sealed unsafe class MagicBuilder
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private char[] _Buffer;
        private int _Count;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(char value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(char value, int length) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value, length); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(char[] value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(char[] value, int length) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value, length); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(string value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(string value, int length) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value, length); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(bool value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(int value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(uint value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(long value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(ulong value) { _Count = _Append(ref _Buffer, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Append(object o)
        {
            if (o == null) { return this; }
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Boolean: return Append((Boolean)o);
                case TypeCode.Char: return Append((Char)o);
                case TypeCode.Byte: return Append((Byte)o);
                case TypeCode.SByte: return Append((SByte)o);
                case TypeCode.Int16: return Append((Int16)o);
                case TypeCode.UInt16: return Append((UInt16)o);
                case TypeCode.Int32: return Append((Int32)o);
                case TypeCode.UInt32: return Append((UInt32)o);
                case TypeCode.Int64: return Append((Int64)o);
                case TypeCode.UInt64: return Append((UInt64)o);
                case TypeCode.String: return Append((String)o);
                default: return Append(o.ToString());
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Insert(int index, char value) { _Count = _Insert(ref _Buffer, index, _Count, _Buffer.Length, value); return this; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Insert(int index, string value) { _Count = _Insert(ref _Buffer, index, _Count, _Buffer.Length, value); return this; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Remove(int index, int length) { _Count = _Remove(_Buffer, index, index + length, _Count); return this; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder Clear() { _Count = 0; return this; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder(int capacity) { _Buffer = new char[capacity]; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MagicBuilder() { _Buffer = new char[64]; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() { return new string(_Buffer, 0, _Count); }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, char s)
        {
            if (nt == pt) { t = _Grow(t, nt, nt, nt + 1); }
            t[nt++] = s; return nt;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, char s, int si)
        {
            if (si <= 0) { return nt; }
            int ti = nt + si;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            while (--si >= 0) { t[nt++] = s; }
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, string s, int si)
        {
            if (si <= 0) { return nt; }
            int ti = nt + si;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* ss = s, tt = t) _Copy(ss, tt + nt, si);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, string s)
        {
            if (s == null) { return nt; }
            int si = s.Length; if (si == 0) { return nt; }
            if (si == 1 && nt != pt) { t[nt++] = s[0]; return nt; }
            int ti = nt + si;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* ss = s, tt = t) _Copy(ss, tt + nt, si);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, char[] s, int si)
        {
            if (si <= 0) { return nt; }
            if (si == 1 && nt != pt) { t[nt++] = s[0]; return nt; }
            int ti = nt + si;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* ss = s, tt = t) _Copy(ss, tt + nt, si);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, char[] s)
        {
            if (s == null) { return nt; }
            int si = s.Length; if (si == 0) { return nt; }
            if (si == 1 && nt != pt) { t[nt++] = s[0]; return nt; }
            int ti = nt + si;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* ss = s, tt = t) _Copy(ss, tt + nt, si);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, bool s)
        {
            string sss = s ? "true" : "false";
            int si = sss.Length;
            int ti = nt + si;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* ss = sss, tt = t) _Copy(ss, tt + nt, si);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, int s)
        {
            const int pr = 11; int nr = pr;
            var r = stackalloc char[pr];
            bool n = (s < 0);
            if (s <= 0) { r[--nr] = (char)('0' - (s % 10)); s = -(s / 10); }
            while (s != 0) { r[--nr] = (char)('0' + (s % 10)); s /= 10; }
            if (n) { r[--nr] = '-'; }

            int ri = pr - nr; int ti = nt + ri;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* tt = t) _Copy(r + nr, tt + nt, ri);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, uint s)
        {
            const int pr = 10; int nr = pr;
            var r = stackalloc char[pr];
            if (s == 0) { r[--nr] = '0'; }
            while (s != 0) { r[--nr] = (char)('0' + (s % 10)); s /= 10; }

            int ri = pr - nr; int ti = nt + ri;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* tt = t) _Copy(r + nr, tt + nt, ri);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, long s)
        {
            const int pr = 20; int nr = pr;
            var r = stackalloc char[pr];
            bool n = (s < 0);
            if (s <= 0) { r[--nr] = (char)('0' - (s % 10)); s = -(s / 10); }
            while (s != 0) { r[--nr] = (char)('0' + (s % 10)); s /= 10; }
            if (n) { r[--nr] = '-'; }

            int ri = pr - nr; int ti = nt + ri;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* tt = t) _Copy(r + nr, tt + nt, ri);
            return ti;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Append(ref char[] t, int nt, int pt, ulong s)
        {
            const int pr = 20; int nr = pr;
            var r = stackalloc char[pr];
            if (s == 0) { r[--nr] = '0'; }
            while (s != 0) { r[--nr] = (char)('0' + (s % 10)); s /= 10; }

            int ri = pr - nr; int ti = nt + ri;
            if (ti > pt) { t = _Grow(t, nt, pt, ti); }
            fixed (char* tt = t) _Copy(r + nr, tt + nt, ri);
            return ti;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Insert(ref char[] t, int nt, int ot, int pt, char s)
        {
            int l = ot + 1;
            if (l > pt) { t = _Grow(t, ot, pt, l); }
            fixed (char* tt = t) _CopyS(tt + nt, tt + nt + 1, ot - nt);
            t[nt] = s;
            return l;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Insert(ref char[] t, int nt, int ot, int pt, string s, int si)
        {
            if (si < 1) { return ot; }
            int l = ot + si;
            if (l > pt) { t = _Grow(t, ot, pt, l); }
            fixed (char* ss = s, tt = t)
            {
                _CopyS(tt + nt, tt + nt + si, ot - nt);
                _Copy(ss, tt + nt, si);
            }
            return l;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Insert(ref char[] t, int nt, int ot, int pt, string s)
        {
            return (s == null) ? ot : _Insert(ref t, nt, ot, pt, s, s.Length);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _Remove(char[] t, int nt, int ot, int pt)
        {
            if (ot > pt) { ot = pt; }
            if (nt >= ot) { return pt; }
            if (pt > ot) { fixed (char* tt = t) _Copy(tt + ot, tt + nt, pt - ot); }
            return pt - ot + nt;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static char[] _Grow(char[] source, int old_count, int old_capacity, int new_count)
        {
            const int min_step = 1 << 6;
            const int max_step = 1 << 20;

            int new_capacity = old_capacity + (old_capacity <= min_step ? min_step : old_capacity >= max_step ? max_step : old_capacity);
            if (new_count > new_capacity) { new_capacity = new_count; }

            var target = new char[new_capacity];
            if (old_count > 0) { fixed (char* ss = source, tt = target) _Copy(ss, tt, old_count); }
            return target;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void _Copy(char* s, char* t, int i)
        {
            while (i >= 16)
            {
                ((ulong*)t)[0] = ((ulong*)s)[0];
                ((ulong*)t)[1] = ((ulong*)s)[1];
                ((ulong*)t)[2] = ((ulong*)s)[2];
                ((ulong*)t)[3] = ((ulong*)s)[3];
                s = (char*)((ulong*)s + 4);
                t = (char*)((ulong*)t + 4);
                i -= 16;
            }
            switch (i)
            {
                case 0: break;
                case 1: ((ushort*)t)[0] = ((ushort*)s)[0]; break;
                case 2: ((uint*)t)[0] = ((uint*)s)[0]; break;
                case 3: ((uint*)t)[0] = ((uint*)s)[0]; ((ushort*)t)[2] = ((ushort*)s)[2]; break;
                case 4: ((ulong*)t)[0] = ((ulong*)s)[0]; break;
                case 5: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ushort*)t)[4] = ((ushort*)s)[4]; break;
                case 6: ((ulong*)t)[0] = ((ulong*)s)[0]; ((uint*)t)[2] = ((uint*)s)[2]; break;
                case 7: ((ulong*)t)[0] = ((ulong*)s)[0]; ((uint*)t)[2] = ((uint*)s)[2]; ((ushort*)t)[6] = ((ushort*)s)[6]; break;
                case 8: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; break;
                case 9: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; ((ushort*)t)[8] = ((ushort*)s)[8]; break;
                case 10: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; ((uint*)t)[4] = ((uint*)s)[4]; break;
                case 11: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; ((uint*)t)[4] = ((uint*)s)[4]; ((ushort*)t)[10] = ((ushort*)s)[10]; break;
                case 12: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; ((ulong*)t)[2] = ((ulong*)s)[2]; break;
                case 13: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; ((ulong*)t)[2] = ((ulong*)s)[2]; ((ushort*)t)[12] = ((ushort*)s)[12]; break;
                case 14: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; ((ulong*)t)[2] = ((ulong*)s)[2]; ((uint*)t)[6] = ((uint*)s)[6]; break;
                case 15: ((ulong*)t)[0] = ((ulong*)s)[0]; ((ulong*)t)[1] = ((ulong*)s)[1]; ((ulong*)t)[2] = ((ulong*)s)[2]; ((uint*)t)[6] = ((uint*)s)[6]; ((ushort*)t)[14] = ((ushort*)s)[14]; break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void _CopyS(char* s, char* t, int i)
        {
            if ((s < t) && ((s + i) > t)) { while (--i >= 0) { t[i] = s[i]; } }
            else { _Copy(s, t, i); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}