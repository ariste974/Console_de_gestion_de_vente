using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinalec_
{
    

     class Noeud
    {
        private Noeud racine ;
        private string valeur;
        private List<Noeud> enfants;

        #region Propriétés
        public string Valeur
        {
            get { return this.valeur; }
            set { this.valeur = value; }
        }

        public List<Noeud> Enfants
        {
            get { return this.enfants; }
        }
        #endregion

        #region Constructeurs
        public Noeud(string valeur)
        {
            this.valeur = valeur;
            this.enfants = new List<Noeud>();
        }
        #endregion

        #region Méthodes publiques
        public void AjouterEnfant(Noeud enfant)
        {
            this.enfants.Add(enfant);
        }

        public void SupprimerEnfant(Noeud enfant)
        {
            this.enfants.Remove(enfant);
        }

        public bool EstFeuille()
        {
            return this.enfants.Count == 0;
        }

        public int NombreEnfants()
        {
            return this.enfants.Count;
        }

        public Noeud GetEnfant(int index)
        {
            if (index < 0 || index >= this.enfants.Count)
            {
                throw new IndexOutOfRangeException("Index d'enfant invalide");
            }
            return this.enfants[index];
        }

        public Noeud RechercherParent(Noeud noeudCourant, Noeud noeudRecherche)
        {
            if (noeudCourant.Enfants.Contains(noeudRecherche))
            {
                return noeudCourant;
            }

            foreach (Noeud enfant in noeudCourant.Enfants)
            {
                Noeud parentTrouve = RechercherParent(enfant, noeudRecherche);
                if (parentTrouve != null)
                {
                    return parentTrouve;
                }
            }

            return null;
        }
        #endregion
    }

}
