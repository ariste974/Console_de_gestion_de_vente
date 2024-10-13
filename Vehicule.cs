using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
    abstract class Vehicule
    {
        protected int TarifHoraire;
        public Vehicule(int TarifHoraire) 
        { 
            this.TarifHoraire = TarifHoraire;
        }
        public int tarifHoraire { get { return TarifHoraire; } set { this.TarifHoraire = value; } }
    }
}
