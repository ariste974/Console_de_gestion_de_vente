using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
     class Camion_citerne : Camion
    {
        string cuve;
        public Camion_citerne(float volume, string matiere, string cuve, int TarifHoraire):base(TarifHoraire)
        {
            this.cuve = cuve;       
        }
    }
}
