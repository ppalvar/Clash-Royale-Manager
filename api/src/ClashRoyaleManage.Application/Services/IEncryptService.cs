namespace ClashRoyaleManager.Application.Services;

public interface IEncryptService
{
    string Encrypt(string text);
    bool Decrypt(string input, string hash);
}