using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
     class Camion_frigorifique : Camion
    {
        int nb_caisse;
        public Camion_frigorifique(float volume, string matiere,int nb_caisse, int TarifHoraire):base(TarifHoraire) 
        {
            this.nb_caisse = nb_caisse;
        
        }
    }
}
