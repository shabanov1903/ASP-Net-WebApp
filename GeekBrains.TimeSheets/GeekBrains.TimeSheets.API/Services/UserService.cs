using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GeekBrains.TimeSheets.API.DTO;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GeekBrains.TimeSheets.API.Services
{
    public sealed class UserService
    {
        public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";
        
        // Функция аутентификации
        public TokenResponse Authenticate(string id)
        {
            TokenResponse tokenResponse = new TokenResponse();
            tokenResponse.Token = GenerateJwtToken(id, 15);
            RefreshToken refreshToken = GenerateRefreshToken(id);
            tokenResponse.RefreshToken = refreshToken.Token;
            return tokenResponse;
        }

        // Генерация нового токена обновления и возврат структуры
        public TokenResponse RefreshToken(string id)
        {
            return new TokenResponse
            {
                Token = GenerateJwtToken(id, 15),
                RefreshToken = GenerateRefreshToken(id).Token
            };
        }

        // Генерация нового токена
        private string GenerateJwtToken(string id, int minutes)
        {
            JwtSecurityTokenHandler tokenHandler = new
            JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);
            SecurityTokenDescriptor tokenDescriptor = new
            SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Генерация нового токена обновления
        // Запись хеша в токен и фиксация времени генерации
        private RefreshToken GenerateRefreshToken(string id)
        {
            RefreshToken refreshToken = new RefreshToken();
            refreshToken.Expires = DateTime.Now.AddMinutes(360);
            refreshToken.Token = GenerateJwtToken(id, 360);
            return refreshToken;
        }

        // Набор функций для проверки хэшированного пароля
        public bool CheckHashPassword(byte[] passwordFromDb, string password, byte[] salt)
        {
            return ChechMass(passwordFromDb, HashPassword(password, salt));
        }

        // Генерация новой соли
        public byte[] GetNewSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return salt;
        }

        // Хеширование пароля
        public byte[] HashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return Encoding.ASCII.GetBytes(hashed);
        }

        // Сравнение массивов
        public bool ChechMass(byte[] arr1, byte[] arr2)
        {
            var isArrayEqual = true;
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr2.Length; i++)
                {
                    if (arr2[i] != arr1[i])
                    {
                        isArrayEqual = false;
                    }
                }
            }
            else
            {
                isArrayEqual = false;
            }
            return isArrayEqual;
        }
    }
}
