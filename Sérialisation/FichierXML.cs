using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    //CLasse FichierXML
    public class FichierXML:IFichierSerialise
    {
        //Flux de lecture/écriture
        private FileStream fs;

        //Constructeur par défaut
        public FichierXML(FileStream fs)
        {
            this.fs = fs;
        }
    }
}
