using System;
using System.IO;
using System.Security.Cryptography;

public class StringEncryption
{
    // Encryption and decryption methods found on https://ianvink.wordpress.com/2022/12/03/a-straightforward-way-in-c-net-to-encrypt-and-decrypt-a-string-using-aes/ (I stole the code)
    // I have zero clue how encryption works at the moment and to be honest, it seems a little too smart even for me
    // Maybe I'll learn it later idk

    public string StringEncrypt(string inputString, string encryptionPassword)
    {
        // Convert the inputString string to a byte array
        byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(inputString);

        // Derive a new encryptionPassword using the PBKDF2 algorithm and a random salt
        Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(encryptionPassword, 20);

        // Use the encryptionPassword to encrypt the inputString
        Aes encryptor = Aes.Create();
        encryptor.Key = passwordBytes.GetBytes(32);
        encryptor.IV = passwordBytes.GetBytes(16);
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plaintextBytes, 0, plaintextBytes.Length);
            }
            return Convert.ToBase64String(ms.ToArray());
        }
    }

    public string StringDecrypt(string encrypted, string encryptionPassword)
    {
        // Convert the encrypted string to a byte array
        byte[] encryptedBytes = Convert.FromBase64String(encrypted);

        // Derive the encryptionPassword using the PBKDF2 algorithm
        Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(encryptionPassword, 20);

        // Use the encryptionPassword to decrypt the encrypted string
        Aes encryptor = Aes.Create();
        encryptor.Key = passwordBytes.GetBytes(32);
        encryptor.IV = passwordBytes.GetBytes(16);
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(encryptedBytes, 0, encryptedBytes.Length);
            }
            return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}