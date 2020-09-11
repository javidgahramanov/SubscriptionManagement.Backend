using Microsoft.Extensions.Logging;
using SubscriptionManagement.Service.Contracts.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SubscriptionManagement.Service.Implementation.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly ILogger<PasswordService> _logger;

        public PasswordService(ILogger<PasswordService> logger)
        {
            _logger = logger;
        }

        public (string, string) GeneratePassword(string password)
        {
            var hash = ComputeHash(password, null);

            return (password, hash);
        }

        public bool IsHashValid(string password, string hashValue)
        {
            var hashWithSaltBytes = Convert.FromBase64String(hashValue);

            const int hashSizeInBits = 128;

            const int hashSizeInBytes = hashSizeInBits / 8;

            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            var saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            for (var i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            var expectedHashString = ComputeHash(password, saltBytes);

            return hashValue == expectedHashString;
        }

        private string ComputeHash(string plainText, byte[] saltBytes)
        {
            if (saltBytes == null)
            {
                const int minSaltSize = 4;
                const int maxSaltSize = 8;

                var random = new Random();
                var saltSize = random.Next(minSaltSize, maxSaltSize);

                saltBytes = new byte[saltSize];

                var rng = new RNGCryptoServiceProvider();

                rng.GetNonZeroBytes(saltBytes);
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var plainTextWithSaltBytes =
                new byte[plainTextBytes.Length + saltBytes.Length];

            for (var i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            for (var i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            HashAlgorithm hash = new MD5CryptoServiceProvider();
            var hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            var hashWithSaltBytes = new byte[hashBytes.Length +
                                             saltBytes.Length];

            for (var i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            for (var i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            var hashValue = Convert.ToBase64String(hashWithSaltBytes);

            return hashValue;
        }
    }
}
