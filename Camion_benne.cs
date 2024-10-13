using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
     class Camion_benne:Camion
    {
        string trois_bennes;
        string grues;
        public Camion_benne(float volume, string matiere,string trois_bennes, string grues,int TarifHoraire):base(TarifHoraire)
        {
            this.trois_bennes = trois_bennes;
            this.grues = grues;
            this.TarifHoraire = TarifHoraire;
        }
    }
}
