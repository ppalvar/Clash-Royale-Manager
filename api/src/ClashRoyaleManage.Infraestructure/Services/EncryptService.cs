using System.Security.Cryptography;
using System.Text;
using ClashRoyaleManager.Application.Services;

namespace ClashRoyaleManager.Infraestructure.Services;

public class EncryptService : IEncryptService
{
    public string Encrypt(string text)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            string hash = Convert.ToBase64String(bytes);

            return hash;
        }
    }

    public bool Decrypt(string input, string hash)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            string inputHash = Convert.ToBase64String(bytes);

            return inputHash == hash;
        }
    }
}
