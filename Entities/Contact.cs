using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    [Serializable()]
    //Classe Contact, classe fille d'Element
    public class Contact:Element
    {
        //Prénom du contact
        private string prenom;
        //Mail du contact
        private string mail;
        //Société du contact
        private string societe;
        //Type de raltion du contact
        private Lien relation;


        //Constructeur de contact
        public Contact(string nom, string prenom, string mail, string societe,
                Lien lien) : base(nom)
        {
            Prenom = prenom;
            //Vérification du mail
            if (mail.Contains("@"))
            {
                Mail = mail;
            }
            else
            {
                throw new ArgumentException("L'adresse mail n'est pas valide");
            }
            Societe = societe;
            Relation = lien;
            
        }

        //Constructeur pour la sérialisation
        public Contact() : base()
        {
                        
        }

        //Encapsulation des champsb dans des propriétés
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Societe { get => societe; set => societe = value; }
        internal Lien Relation { get => relation; set => relation = value; }


        // Surchage de l'affichage 
        public override string ToString()
        {
            string afficher = base.ToString();
            afficher += " [C] " + Nom + " "+ Prenom + "( " + Societe + " ) " + Mail + " Lien: " +Relation;
            return afficher;
        }
    }
}
