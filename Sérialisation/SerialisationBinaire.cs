using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cryptographie;
using Entities;

namespace Serialisation
{
    //Classe fille de sérialisation binaire
    public class SerialisationBinaire : Serialisation
    {
        //Surchage de la méthode Serialiser
        public override void Serialiser(Manager manager,string fichierSerialise, string cle) 
        {
           //Création du fichier
           FileStream fs = new FileStream(fichierSerialise, FileMode.Create);
            //Création du fichier impossible
            if (fs ==null)
            {
                throw new Exception();
            }
            //Sérialisation
           BinaryFormatter bf = new BinaryFormatter();
           bf.Serialize(fs, manager);
            //Cryptage
           Cryptographie.Cryptographie cryptographie = new Cryptographie.Cryptographie();
           cryptographie.Crypter(fs, cle);
            //Fermeture du fichier
           fs.Close();

        }

        //Surchage de la méthode Deserialiser
        public override Manager Deserialiser(string fichierSerialise,string cle)
        {
            
            Manager m = new Manager();
            //Ouverture du fichier
            FileStream fs = new FileStream(fichierSerialise, FileMode.Open, FileAccess.Read);
            //Ouverture du fichier impossible
            if (fs == null)
            {
                throw new Exception();
            }
            BinaryFormatter bf = new BinaryFormatter();
            //Décryptage
            Cryptographie.Cryptographie cryptographie = new Cryptographie.Cryptographie();
            fs = cryptographie.Decrypter(fs, fichierSerialise, cle);
            //Désérialisation
            m = (Manager) bf.Deserialize(fs);
            
            //Fermeture du fichier
            fs.Close();
            return m;
        }
    }
}
