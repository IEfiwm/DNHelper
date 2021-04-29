using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public static class Cryptography
    {
        /// <summary>
        /// Encrypt your data with encryptionKey using Aes
        /// </summary>
        /// <param name="clearText"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        public static string Encrypt(string clearText, string encryptionKey)
        {
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    encryptor.Key = pdb.GetBytes(32);

                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);

                            cs.Close();
                        }

                        clearText = System.Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch
            {
                return null;
            }

            return clearText;
        }

        /// <summary>
        /// Decrypt your Encrypted string
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string encryptionKey)
        {
            try
            {
                if (cipherText == null)
                {
                    return null;
                }

                cipherText = cipherText.Replace(" ", "+");


                byte[] cipherBytes = System.Convert.FromBase64String(cipherText);

                using (var encryptor = Aes.Create())
                {
                    var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    encryptor.Key = pdb.GetBytes(32);

                    encryptor.IV = pdb.GetBytes(16);

                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return cipherText;
        }

        public static string HashUsingSha512(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            using (var sha = System.Security.Cryptography.SHA512.Create())
            {
                return System.Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(text)));
            }
        }

        public static string HashUsingSha1(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            using (var sha = System.Security.Cryptography.SHA1.Create())
            {
                return System.Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(text)));
            }
        }

        #region Extension
        /// <summary>
        /// Encrypt your data with encryptionKey using Aes
        /// </summary>
        /// <param name="clearText"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        public static string ToEncrypt(this string clearText, string encryptionKey)
        {
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    encryptor.Key = pdb.GetBytes(32);

                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);

                            cs.Close();
                        }

                        clearText = System.Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch
            {
                return null;
            }

            return clearText;
        }

        /// <summary>
        /// Decrypt your Encrypted string
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        public static string ToDecrypt(this string cipherText, string encryptionKey)
        {
            try
            {
                if (cipherText == null)
                {
                    return null;
                }

                cipherText = cipherText.Replace(" ", "+");


                byte[] cipherBytes = System.Convert.FromBase64String(cipherText);

                using (var encryptor = Aes.Create())
                {
                    var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    encryptor.Key = pdb.GetBytes(32);

                    encryptor.IV = pdb.GetBytes(16);

                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return cipherText;
        }

        public static string ToSha512(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            using (var sha = System.Security.Cryptography.SHA512.Create())
            {
                return System.Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(text)));
            }
        }

        public static string ToSha1(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            using (var sha = System.Security.Cryptography.SHA1.Create())
            {
                return System.Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(text)));
            }
        }
        #endregion
    }
}
