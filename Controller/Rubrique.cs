using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseRESA
{
    public class Rubrique {
        // Déclaration des variables
        private int id;
        private string nom;

        // --------------------------------------------------------- PARTIE CONSTRUCTEUR ---------------------------------------------------------

        /// <summary>
        /// Constructeur d'une rubrique.
        /// </summary>
        public Rubrique(int idRubrique, string nomRubrique)
        {
            this.id = idRubrique;
            this.nom = nomRubrique;
        }

        // --------------------------------------------------------- PARTIE GETTER ---------------------------------------------------------

        /// <summary>
        /// Getter utilisé pour récupérer l'identifiant de la rubrique.
        /// </summary>
        /// <returns>Un entier</returns>
        public int GetId()
        {
            return this.id;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le nom de la rubrique.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetNom()
        {
            return this.nom;
        }

        // --------------------------------------------------------- AUTRE(S) METHODE(S) ---------------------------------------------------------

        public override string ToString()
        {
            return this.GetId() + " - " + this.GetNom();
        }
    }
}
