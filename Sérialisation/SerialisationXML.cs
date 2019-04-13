using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisation
{
    //Classe fille de sérialisation XML
    public class SerialisationXML : Serialisation
    {
        //Surchage de la méthode Serialiser
        public override void Serialiser(Manager manager, string fichierSerialise,string cle)
        {
            //Création du fichier
            FileStream fs = new FileStream(fichierSerialise, FileMode.Create);
            //Création du fichier impossible
            if (fs == null)
            {
                throw new Exception();
            }

            //Sérialisation
            XmlSerializer xf = new XmlSerializer(typeof(Manager));
            xf.Serialize(fs, manager);

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
            FileStream fs = new FileStream(fichierSerialise, FileMode.Open);
            //Ouverture du fichier impossible
            if (fs == null)
            {
                throw new Exception();
            }
            XmlSerializer xf = new XmlSerializer(typeof(Manager));

            //Décryptage
            Cryptographie.Cryptographie cryptographie = new Cryptographie.Cryptographie();

          
            fs = cryptographie.Decrypter(fs, fichierSerialise, cle);

            //Désérialisation
            m = (Manager) xf.Deserialize(fs);

            //Fermeture du fichier
            fs.Close();
            return m;
        }
    }
}
