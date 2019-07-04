module PInvoke
open System.Runtime.InteropServices

// void** compress2(int32_t a1, int32_t* a2, int32_t a3, int32_t a4, void** a5) {
[<DllImport("lib\\ZLIB1.DLL", EntryPoint = "compress2", CharSet = CharSet.Ansi, SetLastError = false)>]
extern int private Compress(
  byte& destBytes,
  int& destLength,
  byte& srcBytes,
  int srcLength,
  int compressionLevel);

// void** uncompress(int32_t a1, int32_t* a2, int32_t a3, int32_t a4)
[<DllImport("lib\\ZLIB1.DLL", EntryPoint = "uncompress", CharSet = CharSet.Ansi, SetLastError = false)>]
extern int private Uncompress(
  byte& destBytes,
  int& destLength,
  byte& srceBytes,
  int srcLength);

let compress srcBytes =
    let length = Array.length srcBytes
    let mutable destLength = System.Convert.ToInt32( float length + (float length * 0.001) + 12.0)
    let mutable array : byte[] = Array.zeroCreate destLength
    match Compress(&array.[0], &destLength, &srcBytes.[0], length, 9) with
    | 0 ->
        System.Array.Resize<byte>(&array, destLength)
        Ok array
    | x -> Error x

//public static byte[] UncompressChunk(ref byte[] iBytes, int outSize)
let decompress (srcBytes,desiredOutSize) =
    let length = Array.length srcBytes
    let mutable destLength = desiredOutSize
    let mutable array = Array.zeroCreate destLength
    match Uncompress(&array.[0], &destLength, &srcBytes.[0],length) with
    | 0 ->
        System.Array.Resize(&array, destLength)
        Ok array
    | x -> Error x





