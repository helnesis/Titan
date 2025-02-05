using System.Security.Cryptography;

namespace Titan.API.Services.Misc;

public sealed class RsaService
{
    private const int GetKeyLength = 2048;
    
    private byte[]? _privateKey;
    private byte[]? _publicKey;
    
    /// <summary>
    /// Decrypt the given data using the provided IV.
    /// </summary>
    /// <param name="data">Encrypted data</param>
    /// <returns>A byte array that contains the decrypted data.</returns>
    public Span<byte> Decrypt(ReadOnlySpan<byte> data)
    {
        if (_privateKey == null)
            return [];
        
        using var rsa = RSA.Create(GetKeyLength);
        rsa.ImportRSAPrivateKey(_privateKey, out _);
        
        var dest = new byte[GetKeyLength / 8];
        return rsa.TryDecrypt(data: data, destination: dest, padding: RSAEncryptionPadding.OaepSHA256, out _) ? dest.AsSpan() : [];
    }
 
    /// <summary>
    /// Generate a new RSA key pair.
    /// </summary>
    /// <returns>The public RSA key.</returns>
    public byte[] GenerateKeys()
    {
        if (_publicKey != null)
            return _publicKey;
         
        using var rsa = RSA.Create(GetKeyLength);
        _privateKey = rsa.ExportRSAPrivateKey();
        _publicKey = rsa.ExportRSAPublicKey();

        return _publicKey;
    }
}