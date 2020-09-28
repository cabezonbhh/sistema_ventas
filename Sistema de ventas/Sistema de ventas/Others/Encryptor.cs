using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace Sistema_de_ventas.Connection
{
    public class Encryptor
    {

        public string CnString { get; set; }
        public string DbcnString { get; set; }
        public string AppPwdUnique { get; set; }

        private static Encryptor instance;
        private TripleDESCryptoServiceProvider des;
        private MD5CryptoServiceProvider hashmd5;
        private string key;


        public Encryptor()
        {
            des = new TripleDESCryptoServiceProvider();
            hashmd5 = new MD5CryptoServiceProvider();
            AppPwdUnique = "SISTEMA_DE_VENTAS_BY_EMYSOFT";
            key = "SISTEMA_DE_VENTAS_BY_EMYSOFT";
        }

        public static Encryptor GetEncryptor()
        {
            if (instance == null)
                instance = new Encryptor();
            return instance;
        }
        private byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }


        public string Encrypt(string Data, string Password, int Bits)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(Data);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x0, 0x1, 0x2, 0x1, 0x1D, 0x1E, 0x3, 0x4, 0x5, 0xF, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });
            if (Bits == 128)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else if (Bits == 192)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else if (Bits == 256)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else
                return string.Concat(Bits);
        }


        private byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }


        public string Decrypt(string Data, string Password, int Bits)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(Data);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x0, 0x1, 0x2, 0x1, 0x1D, 0x1E, 0x3, 0x4, 0x5, 0xF, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });

                if (Bits == 128)
                {
                    byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                    return System.Text.Encoding.Unicode.GetString(decryptedData);
                }
                else if (Bits == 192)
                {
                    byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                    return System.Text.Encoding.Unicode.GetString(decryptedData);
                }
                else if (Bits == 256)
                {
                    byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                    return System.Text.Encoding.Unicode.GetString(decryptedData);
                }
                else
                    return string.Concat(Bits);
            }
            catch (Exception ex)
            {
                return "Fail_to_encrypt";
            }
        }

        public string checkServer()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            DbcnString = root.Attributes.Item(0).Value;
            CnString = (this.Decrypt(DbcnString, AppPwdUnique, int.Parse("256")));

            return CnString;
        }

        public bool SavetoXML(object dbcnString)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                root.Attributes.Item(0).Value = dbcnString.ToString();
                XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string ReadfromXML()
        {
            string dbcnString;
            string retorno;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes.Item(0).Value;
                retorno = (this.Decrypt(dbcnString, AppPwdUnique, int.Parse("256")));
                return retorno;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string encriptarTexto(string cadena)
        {
            string encriptado = "";

            if (String.IsNullOrEmpty(cadena))
            {
                encriptado = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(key));
                des.Mode = CipherMode.ECB;
                ICryptoTransform encrypt = des.CreateEncryptor();
                Byte[] buff = UnicodeEncoding.ASCII.GetBytes(cadena);
                encriptado = Convert.ToBase64String(encrypt.TransformFinalBlock(buff,0,buff.Length));
            }
            return encriptado;
        }

        public string desencriptarTexto(string cadena)
        {
            string desencriptado = "";

            if (String.IsNullOrEmpty(cadena))
            {
                desencriptado = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(key));
                des.Mode = CipherMode.ECB;
                ICryptoTransform decrypt = des.CreateDecryptor();
                Byte[] buff = UnicodeEncoding.ASCII.GetBytes(cadena);
                desencriptado = Convert.ToBase64String(decrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            return desencriptado;
        }
    }
}
