using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Security.JWT
{
    /// <summary>
    /// The implementation of JSON Web Signature (JWS) with ECDSA involves:
    ///     creating an EC key pair
    ///     → creating a JWT token
    ///     → signing the JWT with a private EC key.
    /// </summary>
    public class JwsEcdsaExample
    {
        public static async Task Execute()
        {
            var (privateKey, publicKey) = EcdsaKeyGenerator.GenerateEcdsaKeyPair();

            var ecPrivateKey = EcdsaKeyGenerator.CreatePrivateKey(privateKey);
            var ecPublicKey = EcdsaKeyGenerator.CreatePublicKey(publicKey);

            var jwtTokenDescriptor = GenerateJwtTokenDescriptor("example@domain.com");

            var jws = CreateSignedJwtToken(jwtTokenDescriptor, ecPrivateKey);

            var isValid = await ValidateJwtToken(jws, ecPublicKey);

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
            var claims = new List<Claim>
            {
                // Registered Claim Name "sub" (subject): Identifies the principal that is the subject of the JWT.
                new(JwtRegisteredClaimNames.Sub, userEmail),
                
                // Registered Claim Name "jti": Provides a unique identifier for the JWT.
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
        /// Creates a signed JWT (JWS) token using the ECDSA SHA-256 algorithm.
        /// The method takes a SecurityTokenDescriptor and an EC private key to produce the signed token.
        /// </summary>
        /// <param name="tokenDescriptor">The SecurityTokenDescriptor containing JWT claims and metadata.</param>
        /// <param name="privateKey">The EC private key used to sign the JWT.</param>
        /// <returns>The signed JWT (JWS) as a string.</returns>
        public static string CreateSignedJwtToken(SecurityTokenDescriptor tokenDescriptor, ECDsaSecurityKey privateKey)
        {
            // Create signing credentials using the ECDSA private security key and ECDSA SHA-256 algorithm.
            // SigningCredentials class specifies the key and algorithm used to sign the token.
            tokenDescriptor.SigningCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.EcdsaSha256);

            // Use the JsonWebTokenHandler to create and encode the JWT token based on the descriptor.
            var tokenHandler = new JsonWebTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the signed JWT token as a string.
            return token;
        }

        /// <summary>
        /// Validates the signed JWT (JWS) to ensure it is authentic and has not been tampered with.
        /// It checks the issuer, audience, lifetime, and signature of the token against the provided public key.
        /// </summary>
        /// <param name="token">The signed JWT (JWS) as a string.</param>
        /// <param name="publicKey">The EC public key used to validate the JWT signature.</param>
        /// <returns>A boolean indicating whether the token is valid.</returns>
        public static async Task<bool> ValidateJwtToken(string token, ECDsaSecurityKey publicKey)
        {
            var tokenHandler = new JsonWebTokenHandler();

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
                    IssuerSigningKey = publicKey
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
