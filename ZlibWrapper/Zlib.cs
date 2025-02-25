using System;
using System.Runtime.InteropServices;

namespace ZlibWrapper
{
    public enum ZlibResult
    {
        Z_OK = 0,
        Z_STREAM_END = 1,
        Z_NEED_DICT = 2,
        Z_ERRNO = -1,
        Z_STREAM_ERROR = -2,
        Z_DATA_ERROR = -3,
        Z_MEM_ERROR = -4,
        Z_BUF_ERROR = -5,
        Z_VERSION_ERROR = -6
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct z_stream
    {
        public IntPtr next_in;
        public uint avail_in;
        public uint total_in;

        public IntPtr next_out;
        public uint avail_out;
        public uint total_out;

        public IntPtr msg;
        public IntPtr state;

        public IntPtr zalloc;
        public IntPtr zfree;
        public IntPtr opaque;

        public int data_type;
        public uint adler;
        public uint reserved;
    }

    public static class Zlib
    {
        private const string ZLIB_DLL = "zlib1.dll";

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string zlibVersion();

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult deflateInit_(
            ref z_stream strm,
            int level,
            string version,
            int stream_size);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult deflate(
            ref z_stream strm,
            int flush);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult deflateEnd(
            ref z_stream strm);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult inflateInit_(
            ref z_stream strm,
            string version,
            int stream_size);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult inflate(
            ref z_stream strm,
            int flush);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult inflateEnd(
            ref z_stream strm);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult compress(
            byte[] dest,
            ref uint destLen,
            byte[] source,
            uint sourceLen);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult compress2(
            byte[] dest,
            ref uint destLen,
            byte[] source,
            uint sourceLen,
            int level);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult uncompress(
            byte[] dest,
            ref uint destLen,
            byte[] source,
            uint sourceLen);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr zError(int err);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint adler32(
            uint adler,
            byte[] buf,
            uint len);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint crc32(
            uint crc,
            byte[] buf,
            uint len);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult deflateSetDictionary(
            ref z_stream strm,
            byte[] dictionary,
            uint dictLength);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult inflateSetDictionary(
            ref z_stream strm,
            byte[] dictionary,
            uint dictLength);

        [DllImport(ZLIB_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern ZlibResult inflateSync(
            ref z_stream strm);
    }
}