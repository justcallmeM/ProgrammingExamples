using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Security.JWT
{
    /// <summary>
    /// HMAC Key Generator Class
    /// </summary>
    public static class HmacKeyGenerator
    {
        /// <summary>
        /// Generates a secure key for use with HMAC SHA-256. 
        /// The security is ensured by using a cryptographically secure random number generator.
        /// This process typically occurs once and the key should be stored securely.
        /// Do not share this key with anyone. It is essential for ensuring the integrity and authenticity of HMAC-signed data.
        /// Shorter than 32 bytes Keys: May make the HMAC more vulnerable to brute force attacks and other cryptographic exploits.
        /// Longer than 32 bytes Keys: While not directly insecure, excessively long keys do not necessarily provide added security 
        /// compared to a properly sized key and can lead to inefficient processing.
        /// </summary>
        /// <param name="length">Byte size of the key. Recommended to be 32 bytes (256 bits) for HMAC SHA-256.</param>
        /// <returns>A Base64 encoded string representing the secure key</returns>
        public static string GenerateHmacKey(int length)
        {
            var rngBytes = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(rngBytes);
            }

            return Convert.ToBase64String(rngBytes);
        }
    }

    /// <summary>
    /// RSA Key Generator Class
    /// </summary>
    public static class RsaKeyGenerator
    {
        /// <summary>
        /// RSA is an asymmetric encryption algorithm that uses different keys for encryption and decryption.
        /// This method generates a new 2048-bit RSA key pair.
        /// - **Asymmetric Encryption**: Different keys for encryption and decryption, enhancing security by allowing public sharing of the encryption key.
        /// - **Key Sizes**: Commonly 2048 bits or 3072 bits for strong security.
        /// - **Security Basis**: Relies on the mathematical challenge of factoring large prime numbers.
        /// - **Use Cases**: Secure key exchange, digital signatures, and encrypting small pieces of data like a symmetric key (which can then be used for faster bulk data encryption).
        /// </summary>
        /// <returns>A tuple containing the private and public keys as byte arrays.</returns>
        public static (byte[] privateKey, byte[] publicKey) GenerateRsaKeyPair()
        {
            using var rsa = RSA.Create(2048);
            var privateKey = rsa.ExportRSAPrivateKey();
            var publicKey = rsa.ExportSubjectPublicKeyInfo();
            return (privateKey, publicKey);
        }

        /// <summary>
        /// Creates a SecurityKey from a private RSA key.
        /// </summary>
        /// <param name="privateKey">The RSA private key in byte array format.</param>
        /// <returns>An RsaSecurityKey created from the private key.</returns>
        public static RsaSecurityKey CreatePrivateKey(byte[] privateKey)
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKey, out _);
            return new RsaSecurityKey(rsa);
        }

        /// <summary>
        /// Creates a SecurityKey from a public RSA key.
        /// </summary>
        /// <param name="publicKey">The RSA public key in byte array format.</param>
        /// <returns>An RsaSecurityKey created from the public key.</returns>
        public static RsaSecurityKey CreatePublicKey(byte[] publicKey)
        {
            var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(publicKey, out _);
            return new RsaSecurityKey(rsa);
        }
    }

    /// <summary>
    /// ECDSA Key Generator Class
    /// </summary>
    public static class EcdsaKeyGenerator
    {
        /// <summary>
        /// Generates a new 256-bit ECDSA key pair using the NIST P-256 curve.
        /// - **Efficient Security**: Shorter key lengths compared to RSA for the same level of security.
        /// - **Asymmetric Encryption**: Different keys for signature creation and verification.
        /// - **Based on Elliptic Curves**: Security is based on the difficulty of solving the elliptic curve discrete logarithm problem.
        /// - **Use Cases**: Digital signatures, secure communications, cryptocurrencies like Bitcoin.
        /// </summary>
        /// <returns>A tuple containing the private and public keys as byte arrays.</returns>
        public static (byte[] privateKey, byte[] publicKey) GenerateEcdsaKeyPair()
        {
            using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            var privateKey = ecdsa.ExportECPrivateKey();
            var publicKey = ecdsa.ExportSubjectPublicKeyInfo();
            return (privateKey, publicKey);
        }

        /// <summary>
        /// Creates a SecurityKey from a private EC key.
        /// </summary>
        /// <param name="privateKey">The EC private key in byte array format.</param>
        /// <returns>An ECDsaSecurityKey created from the private key.</returns>
        public static ECDsaSecurityKey CreatePrivateKey(byte[] privateKey)
        {
            var ecdsa = ECDsa.Create();
            ecdsa.ImportECPrivateKey(privateKey, out _);
            return new ECDsaSecurityKey(ecdsa);
        }

        /// <summary>
        /// Creates a SecurityKey from a public EC key.
        /// </summary>
        /// <param name="publicKey">The EC public key in byte array format.</param>
        /// <returns>An ECDsaSecurityKey created from the public key.</returns>
        public static ECDsaSecurityKey CreatePublicKey(byte[] publicKey)
        {
            var ecdsa = ECDsa.Create();
            ecdsa.ImportSubjectPublicKeyInfo(publicKey, out _);
            return new ECDsaSecurityKey(ecdsa);
        }
    }
}
