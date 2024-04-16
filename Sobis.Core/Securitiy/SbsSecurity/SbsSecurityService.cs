using Sobis.Core.Logging;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Sobis.Core.Securities.SbsSecurity
{
    public class SbsSecurityService : ISecurityService
    {
        private readonly ILoggerService _logger;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private readonly string Path = String.Empty;
        public string Default { get; set; }

        private const string AES_IV = @"!+S1R2D3R4S5B6S7";
        private readonly string aesAnahtar = @"S1R2D3R4S5B6S7!+";

        public SbsSecurityService(ILoggerService logger)
        {
            _logger = logger;
        }

        public string Read(string section, string key)
        {
            Default = Default ?? String.Empty;
            StringBuilder StrBuild = new StringBuilder(256);
            _ = GetPrivateProfileString(section, key, Default, StrBuild, 255, Path);
            return StrBuild.ToString();
        }

        public long Write(string section, string key, string value)
        {
            return WritePrivateProfileString(section, key, value, Path);
        }

        public string Sifrele(string metin)
        {
            using (AesCryptoServiceProvider aesSaglayici = new()
            {
                BlockSize = 128,
                KeySize = 128,

                IV = Encoding.UTF8.GetBytes(AES_IV),
                Key = Encoding.UTF8.GetBytes(aesAnahtar),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                byte[] kaynak = Encoding.Unicode.GetBytes(metin);
                using (ICryptoTransform sifrele = aesSaglayici.CreateEncryptor())
                {
                    byte[] hedef = sifrele.TransformFinalBlock(kaynak, 0, kaynak.Length);
                    return Convert.ToBase64String(hedef);
                }
            }
        }

        public string SifreCoz(string sifreliMetin)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 128,

                IV = Encoding.UTF8.GetBytes(AES_IV),
                Key = Encoding.UTF8.GetBytes(aesAnahtar),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            byte[] kaynak = Convert.FromBase64String(sifreliMetin);
            using (ICryptoTransform decrypt = aesSaglayici.CreateDecryptor())
            {
                byte[] hedef = decrypt.TransformFinalBlock(kaynak, 0, kaynak.Length);
                return Encoding.Unicode.GetString(hedef);
            }
        }

        public string base64Encode(string data)
        {
            string result = string.Empty;
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = Encoding.UTF8.GetBytes(data);
                result = Convert.ToBase64String(encData_byte);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "base64Encode Hatası");
            }

            return result;
        }

        public string base64Decode(string data)
        {
            string result = string.Empty;
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                _ = utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "base64Decode Hatası");
            }
            return result;
        }
    }
}
