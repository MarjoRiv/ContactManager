using System;

namespace Entities
{
    [Serializable()]
    //Classe Element
    public class Element
    {
        //Nom de l'élément
        private string nom;
        //Date de création de l'élément
        private DateTime creation;
        //Date de modification de l'élément
        private DateTime modification;
        //Dossier parent de l'élément
        private Dossier parent;


        //Encapsulation des champs
        public string Nom { get => nom; set => nom = value; }
        public DateTime Modification { get => modification; set => modification = value; }
        public DateTime Creation { get => creation; set => creation = value; }
        public Dossier Parent { get => parent; set => parent = value; }

        //Constructeur par défaut 
        public Element(){
            Nom = "Nouveau Dossier";
            Creation = DateTime.Now;
            Modification = DateTime.Now;
            Parent = null;
        }

        //Constructeur de l'élément
        public Element(string nom)
        {

            Nom = nom;
            Creation = DateTime.Now;
            Modification = DateTime.Now;
            Parent = null;

        }

        //Surchage de l'affichage
        public override string ToString()
        {
            string afficher = "";
            if (Parent != null)
            {
                afficher += "Parent " + Parent.Nom;
            }
            return afficher;
        } 

}
}