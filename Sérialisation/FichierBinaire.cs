using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    //Classe FichierBiniaire 
    public class FichierBinaire : IFichierSerialise
    {
        //Flux de lecture/écriture
        private FileStream fs;

        //Constructeur par défaut
        public FichierBinaire(FileStream fs)
        {
            this.fs = fs;
        }
    }
}
