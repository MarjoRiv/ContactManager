using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable()]
    //Classe Dossier, classe fille d'Element
    public class Dossier: Element
    {
        //Liste des contacts et dossiers du dossier actuel
        private List<Element> elements;

        //Constructeur de sérialisation
        public Dossier():base()
        {
            Elements = new List<Element>();
        }

        //Constructeur de Dossier
        public Dossier(string nom):base(nom)
        {
            Elements = new List<Element>();
        }

        //Encapsulation du champ 
        public List<Element> Elements { get => elements; set => elements = value; }

        //Surchage de l'affichage 
        public override string ToString()
        {
            string lastModif = "Création " + Creation;
            if(Creation != Modification)
            {
                lastModif = "Modification " + Modification;
            }
            string afficher = base.ToString();

            afficher += " [D] " + Nom + " ( " + lastModif + " )\n";
            //Affichage des sous-dossiers et contacts
            foreach (Element e in Elements)
            {
                 afficher += "  "+e.ToString();
            }
            return afficher;
        }

        //Recherche d'un dossier dans la sous-hiérarchie
        public Dossier GetDossier(string nom)
        {
            Dossier d = null;
            d = (Dossier) Elements.Find(c => c.Nom == nom);
            while(d == null)
            {
                Dossier iter = null;
                //Recherche dans les sous-dossiers
                foreach(Element e in Elements)
                {
                    if (e is Dossier)
                    {
                        iter = (Dossier)e;
                        d = iter.GetDossier(nom);
                    }
                }
            }
            return d;
        }

        //Ajout d'un dossier dans le dossier actuel
        public Dossier AjouterDossier(string nom)
        {
            Dossier d = new Dossier(nom);
            d.Parent = this;
            Elements.Add(d);
            return d;
        }

        //Ajout d'un contact dans le dossier
        public void AjouterContact(string nom, string prenom, string mail, string societe, Lien lien) 
        {
            Contact c = new Contact(nom, prenom, mail, societe, lien);
            c.Parent = this;
            Elements.Add(c);
                       
        }
    }
}
