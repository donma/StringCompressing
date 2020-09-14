using SevenZip;
using SimpleBase;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace StringCompressing
{
    public class Utility
    {
        public static string GetBase85(byte[] bytedata)
        {

            if (bytedata == null)
            {
                throw new NullReferenceException();
            }
            return Base85.Ascii85.Encode(bytedata);
        }

        public static byte[] BytesFromBase85(string base85str)
        {

            if (string.IsNullOrEmpty(base85str))
            {
                throw new NullReferenceException();
            }

            Span<byte> result = Base85.Ascii85.Decode(base85str);

            return result.ToArray();
        }

        public static byte[] CompressBytes7z(byte[] source)
        {
            return SevenZip.SevenZipCompressor.CompressBytes(source);
        }

        public static byte[] DecompressBytes7z(byte[] source)
        {

            return SevenZip.SevenZipExtractor.ExtractBytes(source);
        }

        public static byte[] CompressBytes(byte[] source)
        {
            using (var resultMStream = new MemoryStream())
            using (var zipStream = new GZipStream(resultMStream, System.IO.Compression.CompressionLevel.Optimal))
            {
                zipStream.Write(source, 0, source.Length);
                zipStream.Close();
                return resultMStream.ToArray();
            }
        }

        public static byte[] DecompressBytes(byte[] source)
        {
            using (var compressedStream = new MemoryStream(source))
            using (var zipStream = new GZipStream(compressedStream, System.IO.Compression.CompressionMode.Decompress))
            using (var result = new MemoryStream())
            {
                zipStream.CopyTo(result);
                return result.ToArray();
            }
        }


        public static string QuickCompressString(string uncompressString)
        {
            return GetBase85((CompressBytes7z((Encoding.UTF8.GetBytes(uncompressString)))));
        }

        public static string QuickDecompressString(string compressedString)
        {
            return Encoding.UTF8.GetString((DecompressBytes7z((BytesFromBase85(compressedString)))));
        }
    }
}
