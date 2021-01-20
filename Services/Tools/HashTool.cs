using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Hashing Tool
/// </summary>
public static class Hash
{
    /// <summary>
    /// Create SHA256 Hash
    /// </summary>
    /// <param name="str">String Parameter</param>
    /// <returns>SHA 256 Hash</returns>
    public static string CreateSHA256(this string str)
    {
        SHA256 hash = SHA256.Create();
        UTF8Encoding encoder = new();
        byte[] combined = encoder.GetBytes(str);
        hash.ComputeHash(combined);
        string delimitedHexHash = BitConverter.ToString(hash.Hash);
        return delimitedHexHash.Replace("-", "");
    }

    /// <summary>
    /// Create SHA256 Hash Async
    /// </summary>
    /// <param name="str">String Parameter</param>
    /// <returns>SHA 256 Hash</returns>
    public static async Task<string> CreateSHA256Async(this string str)
    {
        return await Task.Run(() =>
        {
            SHA256 hash = SHA256.Create();
            UTF8Encoding encoder = new();
            byte[] combined = encoder.GetBytes(str);
            hash.ComputeHash(combined);
            string delimitedHexHash = BitConverter.ToString(hash.Hash);
            return delimitedHexHash.Replace("-", "");
        });
    }
}