using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entities
{
    [Serializable()]
    //Classe Manager
    public class Manager
    {
        
        //Liste des éléments du manager
        private List<Element> elements;
        //Dossier courant
        private Dossier courant;

        //Encapsulation des champs
        public List<Element> Elements { get => elements; set => elements = value; }
        public Dossier Courant { get => courant; set => courant = value; }

        //Constructeur par défaut
        public Manager()
        {
            Dossier root = new Dossier("root");
            Elements = new List<Element>();
            Elements.Add(root);
            Courant = root;
        }
        
        //Recherche d'un dossier dans toute la hiérarchie
        public Dossier GetDossier(string nom)
        {
            Dossier d = null;
            d = (Dossier)Elements.Find(c => c.Nom == nom);
            while (d == null)
            {
                Dossier iter = null;
                //Recherche dans les sous-dossiers
                foreach (Element e in Elements)
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

        //Affichage de toute la hiérarchie
        public string Afficher()
        {
           string afficher = "";
           foreach(Element e in Elements)
           {
                afficher += "   " +e.ToString();
           }
            return afficher;
        }

        //Ajout d'un dossier nommé dans un autre dossier
        public string AjouterDossier(string nom, string dossier)
        {
            string confirm = "";
            Dossier recherche = GetDossier(dossier);
            if (recherche != null)
            {
                Courant = recherche;
                confirm += "Dossier " + nom + " ajouté à " + Courant.Nom;
                Courant.AjouterDossier(nom);
            }
            else
            {
                //Dossier non trouvé
                throw new Exception("Dossier introuvable");
            }
            return confirm;
        } 

        //Ajout d'un contact dans un dossier
        public string AjouterContact(string dossier, string nom, string prenom, string mail, string societe, Lien stringlien)
        {
            string confirm = "";
            Dossier recherche = GetDossier(dossier);
            if (recherche != null)
            {
                Courant = recherche;
                confirm += "Contact " + nom + " ajouté à " + Courant.Nom;
                Courant.AjouterContact( nom,  prenom,  mail,  societe, stringlien);
            }
            else
            {
                //Dossier non trouvé
                throw new Exception("Dossier introuvable");
            }
            return confirm;

        }
    }
}
