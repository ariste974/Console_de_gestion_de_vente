using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projetfinalec_
{
    internal class Chauffeur : Salarie
    {
        private int TarifHoraire;
        private List<DateTime> planning;
        private int Commandes_realisees;

        public Chauffeur(int SS, string nom, string prenom, DateTime date_de_naissance, string addresse_postale, string adresse_mail, int telephone, DateTime date_entrée, string poste,int tarifHoraire)
            : base(SS, nom, prenom, date_de_naissance, addresse_postale, adresse_mail, telephone, date_entrée, poste)
        {
            this.TarifHoraire = tarifHoraire;
            this.planning = new List<DateTime>();
            this.Commandes_realisees= 0;
            this.Poste = "Chauffeur";
          
        }

        public int tarifHoraire
        {
            get { return TarifHoraire; }
            set { TarifHoraire = value; }
        }
        public int commandes_realisees
        {
            get { return Commandes_realisees; }
            set { Commandes_realisees = value; }
        }

        public List<DateTime> Planning
        {
            get { return planning; }
        }

        public bool EstDisponible(DateTime date)
        {
            return !planning.Contains(date);
        }

        public void AjouterLivraison(DateTime date)
        {
            if (EstDisponible(date))
            {
                planning.Add(date);
            }
            else
            {
                Console.WriteLine("Le chauffeur n'est pas disponible à cette date.");
            }
        }
    }
}