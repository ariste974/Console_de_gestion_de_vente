using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
     class Voiture : Vehicule
        
    {
        
        int nombre_passager;
        public Voiture(int nombre_passager, int TarifHoraire): base(TarifHoraire)
        {
            this.nombre_passager = nombre_passager;
            this.TarifHoraire = 5;
        }
    }
}
