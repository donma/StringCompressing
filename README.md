# StringCompressing

簡單的做 字串壓縮 純文字轉純文字，作法很簡單，先將 字串 轉 byte[]  => 使用 7z 壓縮 => 轉 base 85 => 輸出

Simple library to compress string 

Concept : string => byte[] => 7z byte[] => convert to base85 string


Dependency:

[SimpleBase](https://www.nuget.org/packages/SimpleBase/ "SimpleBase")

[SevenZipSharp.Interop](https://www.nuget.org/packages/SevenZipSharp.Interop/ "SevenZipSharp.Interop")


Sample Code :

 ```csharp
 
 //Finally Quick Compress String And Decompress String
 Console.WriteLine("Finally.. Quick Compress String And Decompress String");
 var compressedString = Utility.QuickCompressString(str);
 var uncompressFromcompressedString = Utility.QuickDecompressString(compressedString);
 Console.WriteLine("Is equal to Source ?");
 Console.ForegroundColor = ConsoleColor.Blue;
 Console.WriteLine(uncompressFromcompressedString == str);
 Console.ForegroundColor = ConsoleColor.White;
 
  ```


Detail Test Code (no need to read) :

 ```csharp
 
             //var str = "許當麻許功蓋許蓋功當麻許許麻當許當麻許功蓋許蓋功當麻許許麻當許當麻許功蓋許蓋功當麻許許麻當許當麻許功蓋許蓋功當麻許許麻當許當麻許功蓋許蓋功當麻許許麻當許當麻許功蓋許蓋功當麻許許麻當許當麻許功蓋許蓋功當麻許許麻當許當麻許功蓋許蓋功當麻許許麻當";

            //var str = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "story2.txt");

            var str = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "story1.txt");

            Console.WriteLine("Source Length:");
            Console.WriteLine(str.Length);
            Console.WriteLine("\r\n--\r\n");


            Console.WriteLine("Source Byte Length: ");
            Console.WriteLine(Encoding.UTF8.GetBytes(str).Length);
            Console.WriteLine("\r\n--\r\n");

            Console.WriteLine("Source Byte Length After Compressing");
            // var compresedBytes = Utility.CompressBytes(Encoding.UTF8.GetBytes(str));
            var compresedBytes = Utility.CompressBytes7z(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(compresedBytes.Length);
            Console.WriteLine("\r\n--\r\n");



            Console.WriteLine("Get Base85 String After Compressed Byte[]");
            var compressByteToBase85 = Utility.GetBase85(compresedBytes);
            //Console.WriteLine(compressByteToBase85);
            Console.WriteLine("Length:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(compressByteToBase85.Length);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\n==\r\n");
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "result.txt", compressByteToBase85);


            //Reverse To Source 

            Console.WriteLine("Convert Bae85 String to Byte[]");
            Console.WriteLine("Length:");
            var byteFromBase85 = Utility.BytesFromBase85(compressByteToBase85);
            Console.WriteLine(byteFromBase85.Length);
            Console.WriteLine("\r\n--\r\n");


            //Decompress From byte[]
            Console.WriteLine("Decompress Byte[]");
            Console.WriteLine("Length:");
            //  var decompressByte = Utility.DecompressBytes(byteFromBase85);
            var decompressByte = Utility.DecompressBytes7z(byteFromBase85);
            Console.WriteLine(decompressByte.Length);
            Console.WriteLine("\r\n--\r\n");

            //Convert byte[] to Source String
            Console.WriteLine("Source String Length after decompressing:");
            var sourceString = Encoding.UTF8.GetString(decompressByte);
            Console.WriteLine(sourceString.Length);
            Console.WriteLine("\r\n--\r\n");

           

            //Check Result
            Console.WriteLine("Is equal to Source ?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sourceString == str);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\n--\r\n");

 
 
 
 ```
