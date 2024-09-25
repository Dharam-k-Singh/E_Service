using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class CryptoEngin
    {
        public const string CryptoKey = "lazydog";

        //public static string Encrypt(string input, string key)
        //{
        //    byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
        //    TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
        //    tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
        //    tripleDES.Mode = CipherMode.ECB;
        //    tripleDES.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform cTransform = tripleDES.CreateEncryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
        //    tripleDES.Clear();
        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}

        //public static string Decrypt(string input, string key)
        //{
        //    byte[] inputArray = Convert.FromBase64String(input);
        //    TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
        //    tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
        //    tripleDES.Mode = CipherMode.ECB;
        //    tripleDES.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform cTransform = tripleDES.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
        //    tripleDES.Clear();
        //    return UTF8Encoding.UTF8.GetString(resultArray);
        //}

        public const string passPhrase = "Pas5pr@se";        // can be any string
        public const  string saltValue = "s@1tValue";        // can be any string
        public const string hashAlgorithm = "SHA1";             // can be "MD5"
        public const int passwordIterations = 2;                  // can be any number
        public const string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        public const int keySize = 256;
        
        public static string Encrypt(string plainText)
        {
            try
            {
                if (plainText != null && plainText != "")
                {
                    // Convert strings into byte arrays.
                    // Let us assume that strings only contain ASCII codes.
                    // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                    // encoding.
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                    // Convert our plaintext into a byte array.
                    // Let us assume that plaintext contains UTF8-encoded characters.
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                    // First, we must create a password, from which the key will be derived.
                    // This password will be generated from the specified passphrase and
                    // salt value. The password will be created using the specified hash
                    // algorithm. Password creation can be done in several iterations.
                    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                    // Use the password to generate pseudo-random bytes for the encryption
                    // key. Specify the size of the key in bytes (instead of bits).
                    byte[] keyBytes = password.GetBytes(keySize / 8);

                    // Create uninitialized Rijndael encryption object.
                    RijndaelManaged symmetricKey = new RijndaelManaged();

                    // It is reasonable to set encryption mode to Cipher Block Chaining
                    // (CBC). Use default options for other symmetric key parameters.
                    symmetricKey.Mode = CipherMode.CBC;

                    // Generate encryptor from the existing key bytes and initialization
                    // vector. Key size will be defined based on the number of the key
                    // bytes.
                    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                    // Define memory stream which will be used to hold encrypted data.
                    MemoryStream memoryStream = new MemoryStream();

                    // Define cryptographic stream (always use Write mode for encryption).
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                    // Start encrypting.
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                    // Finish encrypting.
                    cryptoStream.FlushFinalBlock();

                    // Convert our encrypted data from a memory stream into a byte array.
                    byte[] cipherTextBytes = memoryStream.ToArray();

                    // Close both streams.
                    memoryStream.Close();
                    cryptoStream.Close();

                    // Convert encrypted data into a base64-encoded string.
                    string cipherText = Convert.ToBase64String(cipherTextBytes);

                    // Return encrypted string.
                    return cipherText;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("URL has been tempered.");
            }
            
        }

        
        public static string Decrypt(string cipherText)
        {
            try
            {
                if (cipherText != null && cipherText != "")
                {

                    // Convert strings defining encryption key characteristics into byte
                    // arrays. Let us assume that strings only contain ASCII codes.
                    // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                    // encoding.
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                    // Convert our ciphertext into a byte array.
                    byte[] cipherTextBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));

                    // First, we must create a password, from which the key will be
                    // derived. This password will be generated from the specified
                    // passphrase and salt value. The password will be created using
                    // the specified hash algorithm. Password creation can be done in
                    // several iterations.
                    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                    // Use the password to generate pseudo-random bytes for the encryption
                    // key. Specify the size of the key in bytes (instead of bits).
                    byte[] keyBytes = password.GetBytes(keySize / 8);

                    // Create uninitialized Rijndael encryption object.
                    RijndaelManaged symmetricKey = new RijndaelManaged();

                    // It is reasonable to set encryption mode to Cipher Block Chaining
                    // (CBC). Use default options for other symmetric key parameters.
                    symmetricKey.Mode = CipherMode.CBC;

                    // Generate decryptor from the existing key bytes and initialization
                    // vector. Key size will be defined based on the number of the key
                    // bytes.
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                    // Define memory stream which will be used to hold encrypted data.
                    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                    // Define cryptographic stream (always use Read mode for encryption).
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    // Since at this point we don't know what the size of decrypted data
                    // will be, allocate the buffer long enough to hold ciphertext;
                    // plaintext is never longer than ciphertext.
                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                    // Start decrypting.
                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                    // Close both streams.
                    memoryStream.Close();
                    cryptoStream.Close();

                    // Convert decrypted data into a string.
                    // Let us assume that the original plaintext string was UTF8-encoded.
                    string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                    // Return decrypted string.
                    return plainText;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("URL has been tempered.");
            }
        }

    }
}
