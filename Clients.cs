using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
    class Clients : Personne
    {

        DateTime date_de_naissance;
        string addresse_postale;
        string adresse_mail;
        int telephone;
     
        double montant;

        public Clients(int SS, string nom, string prenom, DateTime date_de_naissance, string addresse_postale, string adresse_mail, int telephone) : base(SS, nom, prenom)
        {
            this.date_de_naissance = date_de_naissance;
            this.addresse_postale = addresse_postale;
            this.adresse_mail = adresse_mail;
            this.telephone = telephone;
            this.montant = 0;
        }

 
        public override string ToString()
        {
            return nom + " " + prenom;
        }






        public DateTime Date_de_naissance { get { return date_de_naissance; } }
        public string Addresse_postale { get { return addresse_postale; } set { this.addresse_postale = value; } }
        public string Adresse_mail { get { return adresse_mail; } set { this.Adresse_mail = value; } }
        public int Telephone { get { return telephone; } set { this.telephone = value; } }
        public double Montant { get { return montant; } set { montant = value; } }
    }

}
