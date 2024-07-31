using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json.Linq;

namespace Security.JWT
{
    /// <summary>
    /// The implementation of JSON Web Encryption (JWE) involves:
    ///     1. Generate a Content Encryption Key (CEK) to encrypt the payload.
    ///     2. Encrypt the CEK with an RSA public key.
    ///     3. Encrypt the payload using the CEK and AES algorithm.
    ///     4. Create JWE including header, encrypted key, IV, ciphertext, and authentication tag.
    ///     5. Decrypt the JWE using the RSA private key.
    /// </summary>
    public class JweExample
    {
        public static void Execute()
        {
            var (privateKey, publicKey) = RsaKeyGenerator.GenerateRsaKeyPair();

            var rsaPrivateKey = RsaKeyGenerator.CreatePrivateKey(privateKey);
            var rsaPublicKey = RsaKeyGenerator.CreatePublicKey(publicKey);

            var jwe = CreateEncryptedJwt("example@domain.com", rsaPublicKey);

            var decryptedPayload = DecryptJwe(jwe, rsaPrivateKey);

            Console.WriteLine($"Decrypted Payload: {decryptedPayload}");
        }

        /// <summary>
        /// Generates an encrypted JWT (JWE) token.
        /// </summary>
        /// <param name="userEmail">The email of the user to be included in the JWT claims.</param>
        /// <param name="rsaPublicKey">The RSA public key used to encrypt the CEK.</param>
        /// <returns>The encrypted JWT (JWE) as a string.</returns>
        public static string CreateEncryptedJwt(string userEmail, RsaSecurityKey rsaPublicKey)
        {
            // Step 1: Create the JWT payload as a JSON string
            var payload = new JObject(
                new JProperty(JwtRegisteredClaimNames.Sub, userEmail),
                new JProperty(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ).ToString();

            // Step 2: Generate a Content Encryption Key (CEK) for the payload encryption using AES.
            using var aes = Aes.Create();
            aes.KeySize = 256;
            aes.GenerateKey(); // Generate a random key.
            aes.GenerateIV();  // Generate a random Initialization Vector (IV).
            var cek = aes.Key; // CEK (Content Encryption Key) used to encrypt the payload.
            var iv = aes.IV;   // IV (Initialization Vector) ensures that the same plaintext does not encrypt to the same ciphertext.

            // Step 3: Encrypt the CEK with an RSA public key.
            var rsa = rsaPublicKey.Rsa;
            // Other algorithms: Yes, other algorithms like ECDH-ES can also be used for key encryption.
            var encryptedCek = rsa.Encrypt(cek, RSAEncryptionPadding.OaepSHA256); // RSA-OAEP (Optimal Asymmetric Encryption Padding) is used for security.

            // Step 4: Encrypt the payload using the CEK and AES algorithm.
            using var encryptor = aes.CreateEncryptor(cek, iv); // Create an AES encryptor with the CEK and IV.
            var payloadBytes = Encoding.UTF8.GetBytes(payload); // Convert the payload to bytes because encryption algorithms operate on byte data.
            // The '0' and 'Length' in TransformFinalBlock indicate the start index and number of bytes to be encrypted.
            var ciphertext = encryptor.TransformFinalBlock(payloadBytes, 0, payloadBytes.Length);

            // Step 5: Create a JWE header.
            var header = new JObject(
                new JProperty("alg", "RSA-OAEP"),
                new JProperty("enc", "A256CBC-HS512"),
                new JProperty("typ", "JWT")
            );

            // Step 6: Generate an authentication tag over the ciphertext and additional authenticated data (AAD).
            var aad = Encoding.UTF8.GetBytes(header.ToString()); // AAD (Additional Authenticated Data) authenticates the header.
            using var hmac = new HMACSHA256(cek); // HMAC-SHA256 authenticates the ciphertext to ensure integrity.
            // TransformBlock processes the additional authenticated data (AAD).
            hmac.TransformBlock(aad, 0, aad.Length, aad, 0);
            // TransformFinalBlock processes the ciphertext to produce the final hash (authTag).
            hmac.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
            var authTag = hmac.Hash;

            // Step 7: Concatenate the Base64URL encoded parts into a JWE.
            var jweToken = string.Join(".",
                Base64UrlEncoder.Encode(header.ToString()),
                Base64UrlEncoder.Encode(encryptedCek),
                Base64UrlEncoder.Encode(iv),
                Base64UrlEncoder.Encode(ciphertext),
                Base64UrlEncoder.Encode(authTag));

            return jweToken;
        }

        /// <summary>
        /// Decrypts the encrypted JWT (JWE) token.
        /// </summary>
        /// <param name="jweToken">The encrypted JWT (JWE) as a string.</param>
        /// <param name="rsaPrivateKey">The RSA private key used to decrypt the CEK.</param>
        /// <returns>The decrypted payload as a string.</returns>
        public static string DecryptJwe(string jweToken, RsaSecurityKey rsaPrivateKey)
        {
            var segments = jweToken.Split('.');
            if (segments.Length != 5)
            {
                throw new ArgumentException("Invalid JWE format");
            }

            // Extract and decode each part of the JWE token
            // The header is not used in the decryption process but is essential for the JWT structure
            var header = Base64UrlEncoder.DecodeBytes(segments[0]); // The header explains the encryption algorithms used.
            var encryptedCek = Base64UrlEncoder.DecodeBytes(segments[1]); // The encrypted Content Encryption Key (CEK).
            var iv = Base64UrlEncoder.DecodeBytes(segments[2]); // The Initialization Vector (IV) used for AES encryption.
            var ciphertext = Base64UrlEncoder.DecodeBytes(segments[3]); // The encrypted payload (ciphertext).
            var authTag = Base64UrlEncoder.DecodeBytes(segments[4]); // The authentication tag ensuring the integrity of the payload.

            // Decrypt the CEK with the RSA private key
            var rsa = rsaPrivateKey.Rsa;
            var cek = rsa.Decrypt(encryptedCek, RSAEncryptionPadding.OaepSHA256);

            using var aes = Aes.Create();
            aes.Key = cek; // Set the AES key to the decrypted CEK.
            aes.IV = iv; // Set the AES IV to the extracted IV.

            // Create a decryptor to decrypt the payload
            using var decryptor = aes.CreateDecryptor(); // AES CreateDecryptor() reverses the encryption process.
            var decryptedBytes = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length); // Decrypt the ciphertext.
            var decryptedPayload = Encoding.UTF8.GetString(decryptedBytes); // Convert the decrypted bytes back to a string.

            return decryptedPayload;
        }
    }
}
