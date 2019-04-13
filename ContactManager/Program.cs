using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Serialisation;

namespace ContactManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Création du manager de contacts
            Manager contactManager = new Manager();
            //Affichage du menu
            AfficherMenu();
            //Lecture de la commande entrée par l'utilisateur
            string lecture = Console.ReadLine();
            //Tant que l'utilisateur ne veut pas sortir
            while (lecture != "sortir")
            {
                //Cas des diiférentes commandes
                switch (lecture.Split(' ').ElementAt(0))
                {
                    //Affichage des contacts
                   case "afficher":
                        Console.WriteLine(contactManager.Afficher());
                       
                        break;
                     //Chargement du fichier
                    case "charger":
                        //Choix entre sérialistaion binaire et xml
                        Serialisation.Serialisation deserialisation = ChoixSerialisation();
                        try
                        {
                            //Désérialisation
                            contactManager = deserialisation.Deserialiser(lecture.Split(' ').ElementAt(1),lecture.Split(' ').ElementAt(2));
                        }
                        catch (Exception e)
                        {
                            //Cas d'erreur de chargement du fichier
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Chargement du fichier impossible");
                        }
                        
                        break;
                    case "enregistrer":
                        //Choix entre sérialistaion binaire et xml
                        Serialisation.Serialisation serialisation = ChoixSerialisation();
                        try {
                            //Sérialisation
                            serialisation.Serialiser(contactManager, lecture.Split(' ').ElementAt(1), lecture.Split(' ').ElementAt(2));
                        }
                        catch(Exception e)
                        {
                            //Cas d'erreur de chargement du fichier
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Chargement du fichier impossible");
                        }
                    
                        break;
                    case "ajouterdossier":
                        //Vérification des paramètres
                        if (lecture.Split(' ').Count() == 3)
                        {
                            //Ajout de dossier
                            Console.WriteLine(contactManager.AjouterDossier(lecture.Split(' ').ElementAt(1), lecture.Split(' ').ElementAt(2)));
                           
                        }
                        else
                        {
                            //Paramètres invalides
                            Console.WriteLine("Veuillez entrer : ajouterdossier nouveaudossier dossierparent");
                        }
                        break;
                    case "ajoutercontact":
                        //Vérification des paramètres
                        if (lecture.Split(' ').Count() == 7)
                        {
                                Console.WriteLine(contactManager.AjouterContact(lecture.Split(' ').ElementAt(1),
                                lecture.Split(' ').ElementAt(2),
                                lecture.Split(' ').ElementAt(3),
                                lecture.Split(' ').ElementAt(4),
                                lecture.Split(' ').ElementAt(5),
                                (Lien) Enum.Parse(typeof(Lien), lecture.Split(' ').ElementAt(6))
                               ));

                        }
                        else
                        {
                            //Paramètres invalides
                            Console.WriteLine("Veuillez entrer : ajouterdossier nouveaudossier dossierparent");
                        }
                        break;
                    default:
                        //Commande inconnue
                        Console.WriteLine("Commande inconnue");
                        break;
                }
                //Affichage du menu
                AfficherMenu();
                //Lecture de la commande 
                lecture = Console.ReadLine();
            }
            
        }


        //Affichage du menu 
        private static void AfficherMenu()
        {
            Console.WriteLine("Taper une commande parmi celles-ci:");
            Console.WriteLine("sortir");
            Console.WriteLine("afficher");
            Console.WriteLine("charger nomFichier cleCryptage");
            Console.WriteLine("enregistrer nomFichier cleCryptage");
            Console.WriteLine("ajouterdossier nomNouveauDossier dossierParent");
            Console.WriteLine("ajoutercontact dossier nom prenom mail societe lien");
            
        }

        //Choix de sérialisation
        private static Serialisation.Serialisation ChoixSerialisation()
        {
            Console.WriteLine("Entrez le type de sérialisation souhaité (binaire ou xml)");
            string s = Console.ReadLine();
            while (s != "binaire" && s != "xml")
            {
                Console.WriteLine("Type non valide");
                s = Console.ReadLine();
            }
            Serialisation.Serialisation serialisation;
            if (s == "binaire")
            {
               SerialisationBinaire sb =new SerialisationBinaire();
                serialisation = sb;
            }
            else if(s == "xml")
            {
                SerialisationXML sx = new SerialisationXML();
                serialisation = sx;

            }
            else
            {
                Console.WriteLine("Type invalide");
                serialisation = null;
            }
            return serialisation;
        }

    }
}
