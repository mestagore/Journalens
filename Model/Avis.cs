using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseRESA
{
    public class Avis
    {
        // Déclaration des variables
        private readonly int identifiant;
        private readonly DateTime dateCreation;
        private string commentaire;
        private readonly int idArticle;
        private readonly string auteurCom;

        // --------------------------------------------------------- PARTIE CONSTRUCTEUR ---------------------------------------------------------

        /// <summary>
        /// Constructeur d'un avis.
        /// </summary>
        /// <param name="idAvis">L'identifiant de l'avis'.</param>
        /// <param name="comAvis">Le contenu de l'avis.</param>
        /// <param name="idArticle">L'identifiant de l'article concerné.</param>
        /// <param name="auteur">L'identifiant du compte de .</param>
        public Avis(int idAvis, DateTime dateCreation, string comAvis, int idArticle, string auteur)
        {
            this.identifiant = idAvis;
            this.dateCreation = dateCreation;
            this.commentaire = comAvis;
            this.idArticle = idArticle;
            this.auteurCom = auteur;
        }

        // --------------------------------------------------------- PARTIE GETTER ---------------------------------------------------------

        /// <summary>
        /// Getter utilisé pour récupérer l'identifiant de l'avis.
        /// </summary>
        /// <returns>Un entier</returns>
        public int GetId()
        {
            return this.identifiant;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le contenu de l'avis.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetCommentaire() {
            return this.commentaire;
        }

        public string GetAuteur() {
            return this.auteurCom;
        }

        public int GetArticleConcerne() {
            return this.idArticle;
        }

        /// <summary>
        /// Getter utilisé pour récupérer la date de création de l'avis.
        /// </summary>
        /// <returns>Un DateTime</returns>
        public DateTime GetDateCreation()
        {
            return dateCreation;
        }
        // --------------------------------------------------------- PARTIE SETTER ---------------------------------------------------------

        /// <summary>
        /// Setter utilisé pour valoriser le commentaire d'un avis.
        /// </summary>
        /// <param name="newName">Le nouveau contenu de l'avis.</param>
        public void SetCom(string newCom)
        {
            this.commentaire = newCom;
        }

        // --------------------------------------------------------- AUTRE(S) METHODE(S) ---------------------------------------------------------

        public override string ToString()
        {
            return "Avis n°" + GetId() + " - Auteur : " + GetAuteur();
        }
    }
}
