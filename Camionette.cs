using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
     class Camionette : Vehicule
    {
        string usage;
        public Camionette( int TarifHoraire) : base(TarifHoraire)
        {

            this.TarifHoraire = 6;
        }
        public override string ToString()
        {
            return "Camionette";
        }
    }
}
