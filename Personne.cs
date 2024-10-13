using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
    abstract class Personne
    {
        protected int SS;
        protected string nom;
        protected string prenom;
        public Personne(int SS, string nom, string prenom)
        {
            this.SS = SS;
            this.nom = nom;
            this.prenom = prenom;
        }
        public int SSP{get{ return SS; } }
        public string Prenom { get {  return prenom; } }
        public string Nom {  get { return nom; } }

    }
}
