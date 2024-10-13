using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
    internal class Commande
    {
        Clients client;
        double prix;
        DateTime date_livraison;
        Vehicule vehicule;
        string trajet;
        Chauffeur chauffeur;
        bool paiementEffectue;
        int distance;
        bool commandefinalisee;
        int numero;
      
        public Commande(Clients client, double prix, DateTime date_livraison,Vehicule vehicule,int numero)
        {
            this.client = client;
            this.prix = prix;   
            this.date_livraison = date_livraison;
            this.vehicule = vehicule;
            this.paiementEffectue = false;
            this.commandefinalisee = false;
            this.numero = numero;
        }

        public void Afficher()
        {
            Console.WriteLine("Détails de la commande :");
            Console.WriteLine("Client : " + client.ToString());
            Console.WriteLine("Prix : " + prix);
            Console.WriteLine("Date de livraison : " + date_livraison);
            Console.WriteLine("Véhicule : " + vehicule.ToString());
            Console.WriteLine(trajet);
            Console.WriteLine("Chauffeur : " + (chauffeur != null ? chauffeur.Nom+" "+chauffeur.Prenom : "Non assigné"));
            Console.WriteLine("Paiement effectué : " + (paiementEffectue ? "Oui" : "Non"));
            Console.WriteLine("Commande réalisée : " + (commandefinalisee ? "Oui" : "Non"));
        }

        public void AssignerChauffeur(Chauffeur chauffeur)
        {
            if (chauffeur.EstDisponible(date_livraison))
            {
                this.chauffeur = chauffeur;
                chauffeur.AjouterLivraison(date_livraison);

            }
            else
            {
                Console.WriteLine("Le chauffeur n'est pas disponible pour cette date de livraison.");
            }
        }
        public double Prix { get { return prix; } set { this.prix = value; } }
        public Clients Client { get { return client; } set { this.client = value; } }
        public Chauffeur Chauffeurs { get { return chauffeur; } set { this.chauffeur = value; } }
        public int Distance { get { return distance; } set { this.distance = value; } }
        public string Trajet { get { return trajet; } set { this.trajet = value; } }
        public bool PaiementEffectue { get { return paiementEffectue; } set { this.paiementEffectue = value; } }
        public DateTime Date_livraison { get { return date_livraison; } set { this.date_livraison = value; } }
        public int Numero { get { return numero; } set { this.numero = value; } }
        public bool Commandefinalisee { get { return commandefinalisee; } set { this.commandefinalisee = value; } }


        public void AssignerPrixLivraison()
        {
            this.prix += (this.chauffeur.tarifHoraire + this.vehicule.tarifHoraire) * this.distance;
        }
        public void EffectuerPaiement()
        {
            paiementEffectue = true;
        }
 
        public void FinaiserLivraison()
        {
            if (paiementEffectue) {
                commandefinalisee = true;
            }
        }
        public void AjouterCommandeChauffeur()
        {
            if (this.commandefinalisee == true){
                this.chauffeur.commandes_realisees += 1;
            }
        }
    }
}
