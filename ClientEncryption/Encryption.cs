using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ClientEncryption
{
    public class Encryption
    {
        private RijndaelManaged aes = new RijndaelManaged();

        public Encryption()
        {
        }


        //AES_256 암호화 (메신저 및 비밀번호)
        public string AESEncrypt256(string message, string password)
        {
            byte[] plainMessage = System.Text.Encoding.Unicode.GetBytes(message);
            byte[] Salt = Encoding.ASCII.GetBytes(password.Length.ToString());

            PasswordDeriveBytes Key = new PasswordDeriveBytes(password, Salt);
            ICryptoTransform Encryptor = aes.CreateEncryptor(Key.GetBytes(32), Key.GetBytes(16));

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, Encryptor, CryptoStreamMode.Write);

            cs.Write(plainMessage, 0, plainMessage.Length);
            cs.FlushFinalBlock();
            byte[] CipherBytes = ms.ToArray();

            ms.Close();
            cs.Close();

            return Convert.ToBase64String(CipherBytes);
        }

        //AES_256 복호화(메신저 및 비밀번호)
        public string AESDecrypt256(string message, string password)
        {

            byte[] EncryptedData = Convert.FromBase64String(message);
            byte[] Salt = Encoding.ASCII.GetBytes(password.Length.ToString());

            PasswordDeriveBytes Key = new PasswordDeriveBytes(password, Salt);
            ICryptoTransform Descrptor = aes.CreateDecryptor(Key.GetBytes(32), Key.GetBytes(16));

            MemoryStream ms = new MemoryStream(EncryptedData);
            CryptoStream cs = new CryptoStream(ms, Descrptor, CryptoStreamMode.Read);

            byte[] plainMessage = new byte[EncryptedData.Length];
            int DecryptedCount = cs.Read(plainMessage, 0, plainMessage.Length);

            ms.Close();
            cs.Close();

            return Encoding.Unicode.GetString(plainMessage, 0, DecryptedCount);
        }
    }
}
