using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographie
{
    public class Cryptographie
    {
        //Cryptage du fichier sérialisé avec la clé entrée 
        public byte[] Crypter(FileStream fs, string cle)
        {
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(cle);
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(cle);

            ICryptoTransform encryptor = cryptic.CreateEncryptor(cryptic.Key, cryptic.IV);

            MemoryStream ms = new MemoryStream();
            //Ouverture en écriture dans le stream de cryptage
            CryptoStream crStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

            StreamWriter swEncrypt = new StreamWriter(crStream);

            //Ecriture dans le flux de cryptage
            swEncrypt.Write(fs);

        
            byte[] encrypted = ms.ToArray();

            //Fermeture des flux 
            ms.Close();
            crStream.Close();
            return encrypted;
        }

        //Décryptage du fichier sérialisé avec la clé entrée 
        public FileStream Decrypter(FileStream fs, string fichierSerialise, string cle)
        {
            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes(cle);
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes(cle);

            ICryptoTransform cryptor = cryptic.CreateDecryptor(cryptic.Key, cryptic.IV);

            string text = null;
            //Récupération du flux crypté ??
            MemoryStream ms = new MemoryStream();

            //Ouverture en écriture dans le stream de cryptage
            CryptoStream crStream = new CryptoStream(ms, cryptor, CryptoStreamMode.Read);

            StreamReader srDecrypt = new StreamReader(crStream);

            //Lecture dans le flux de cryptage
            text = srDecrypt.ReadToEnd();
            
            //Fermeture des flux 
            ms.Close();
            crStream.Close();
            return fs;
        }



       

    }
}

