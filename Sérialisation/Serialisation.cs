using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Serialisation
{
    //Classe abstraite pour sérialiser et désérialiser le fichier de contacts
    public abstract class Serialisation
    {
        //Sérialisation et cryptage de Manager 
        public abstract void Serialiser(Manager manager, string fichierSerialise,string cle);
        //Désérialisation et décryptage de Manager
        public abstract Manager Deserialiser(string fichierSerialise,string cle);
    }
}
