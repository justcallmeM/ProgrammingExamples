using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Security.JWT
{
    /// <summary>
    /// The implementation of JSON Web Signature (JWS) involves:
    ///     creating a secret key
    ///     → creating JWT token
    ///     → signing the JWT with a secret key using the HMAC algorithm.
    /// </summary>
    public class JwsHmacExample
    {
        public static async Task Execute()
        {
            var secureKey = HmacKeyGenerator.GenerateHmacKey(32);

            var jwtTokenDescriptor = GenerateJwtTokenDescriptor("example@domain.com");

            var jws = CreateSignedJwtToken(jwtTokenDescriptor, secureKey);

            var isValid = await ValidateJwtTokenAsync(jws, secureKey);

            Console.WriteLine($"Is Token Valid: {isValid}");
        }

        /// <summary>
        /// Generates a SecurityTokenDescriptor containing the JWT claims and metadata.
        /// This descriptor does not include signing information.
        /// </summary>
        /// <param name="userEmail">The email of the user to be included in the JWT claims.</param>
        /// <returns>A SecurityTokenDescriptor with the claims, issuer, audience, and expiry set.</returns>
        public static SecurityTokenDescriptor GenerateJwtTokenDescriptor(string userEmail)
        {
            // JWT Claim Names:
            // Registered Claim Names: Predefined claims recommended to be used in JWTs.
            // Public Claim Names: Claims defined by JWT specification or other parties.
            // Private Claim Names: Custom claims defined by the parties using them.

            var claims = new List<Claim>
            {
                // Registered Claim Name "sub" (subject): Identifies the principal that is the subject of the JWT.
                new(JwtRegisteredClaimNames.Sub, userEmail),
                
                // Registered Claim Name "jti" (JWT ID): Provides a unique identifier for the JWT.
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return new SecurityTokenDescriptor
            {
                // "Issuer" (iss): The URL or identifier of the entity that issued the token.
                Issuer = "your-app",

                // "Audience" (aud): Specifies the recipients that the JWT is intended for.
                Audience = "your-app",

                // "Subject" (sub): Contains the claims that identify the subject of the JWT.
                Subject = new ClaimsIdentity(claims),

                // "Expires" (exp): The date and time after which the JWT expires.
                Expires = DateTime.UtcNow.AddMinutes(30)
            };
        }

        /// <summary>
        /// Creates a signed JWT (JWS) token using the HMAC SHA-256 algorithm.
        /// The method takes a SecurityTokenDescriptor and a secret key to produce the signed token.
        /// </summary>
        /// <param name="tokenDescriptor">The SecurityTokenDescriptor containing JWT claims and metadata.</param>
        /// <param name="secretKey">The secret key used to sign the JWT.</param>
        /// <returns>The signed JWT (JWS) as a string.</returns>
        public static string CreateSignedJwtToken(SecurityTokenDescriptor tokenDescriptor, string secretKey)
        {
            // Convert the secret key from a string to a byte array using UTF-8 encoding.
            // This is necessary because cryptographic algorithms work on byte data.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Create signing credentials using the symmetric key and HMAC SHA-256 algorithm.
            // SigningCredentials class specifies the key and algorithm used to sign the token.
            tokenDescriptor.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Use the JsonWebTokenHandler to create and encode the JWT token based on the descriptor.
            var tokenHandler = new JsonWebTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the signed JWT token as a string.
            return token;
        }

        /// <summary>
        /// Validates the signed JWT (JWS) to ensure it is authentic and has not been tampered with.
        /// It checks the issuer, audience, lifetime, and signature of the token against the provided secret key.
        /// </summary>
        /// <param name="token">The signed JWT (JWS) as a string.</param>
        /// <param name="secretKey">The secret key used to validate the JWT signature.</param>
        /// <returns>A boolean indicating whether the token is valid.</returns>
        private static async Task<bool> ValidateJwtTokenAsync(string token, string secretKey)
        {
            var tokenHandler = new JsonWebTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your-app",
                    ValidAudience = "your-app",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                var principal = await tokenHandler.ValidateTokenAsync(token, validationParameters);

                // Optionally, you can check more claims here if needed

                return principal.IsValid;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return false;
            }
        }
    }
}
