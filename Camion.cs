using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
     class Camion:Vehicule
    {
        float volume;
        string matiere;
        public Camion(int TarifHoraire) : base(TarifHoraire)
        {
           
            this.TarifHoraire = 7;
        }

        public override string ToString()
        {
            return "Camion";
        }
    }
}
