# StringCompressing

簡單的做 字串壓縮 純文字轉純文字，作法很簡單，先將 字串 轉 byte[]  => 使用 7z 壓縮 => 轉 base 85 => 輸出

Simple library to compress string 

Concept : string => byte[] => 7z byte[] => convert to base85 string


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
