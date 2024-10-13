using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
    internal class Salarie : Personne
    {
        
        DateTime date_de_naissance;
        string addresse_postale;
        string adresse_mail;
        int telephone;
        DateTime date_entrée;
        string poste;

        

        public Salarie(int SS,string nom,string prenom,DateTime date_de_naissance,string addresse_postale,string adresse_mail,int telephone, DateTime date_entrée,string poste): base(SS,nom,prenom)
        {
            
            this.date_de_naissance = date_de_naissance;
            this.addresse_postale = addresse_postale;
            this.adresse_mail = adresse_mail;
            this.telephone = telephone;
            this.date_entrée = date_entrée;
            this.poste = poste;

        }
        public int sS { get { return SS; }}
        public DateTime Date_de_naissance { get {  return date_de_naissance; } }
        public string Addresse_postale { get { return addresse_postale; } set { this.addresse_postale = value; } }
        public string Adresse_mail { get {  return adresse_mail; } set { this.Adresse_mail = value; } }
        public int Telephone { get { return telephone; } set { this.telephone = value; } }
        public DateTime Date_entree { get { return date_entrée; } }
        public string Poste { get {  return poste; } set { this.poste = value; } }

        

    }
}
