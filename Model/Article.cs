using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseRESA
{
    public class Article {
        // Déclaration des variables
        private readonly int id;
        private string titre;
        private string description;
        private readonly DateTime dateCreation;
        private readonly string auteur;
        private string etat;

        // --------------------------------------------------------- PARTIE CONSTRUCTEUR ---------------------------------------------------------

        /// <summary>
        /// Constructeur d'un article de presse sans rubrique associée.
        /// </summary>
        /// <param name="idArticle">L'identifiant de l'article.</param>
        /// <param name="titreArticle">Le titre de l'article.</param>
        /// <param name="descriptionArticle">La description de l'article.</param>
        /// <param name="auteur">L'auteur de l'article.</param>
        /// <param name="dateCreation">La date de création de l'article.</param>
        /// <param name="etat">L'état de l'article.</param>
        public Article(int idArticle, string titreArticle, string descriptionArticle, string auteur, DateTime dateCreation, string etat)
        {
            this.id = idArticle;
            this.titre = titreArticle;
            this.description = descriptionArticle;
            this.dateCreation = dateCreation;
            this.auteur = auteur;
            this.etat = etat;
        }

        // --------------------------------------------------------- PARTIE GETTER ---------------------------------------------------------

        /// <summary>
        /// Getter utilisé pour récupérer l'identifiant de l'article.
        /// </summary>
        /// <returns>Un entier</returns>
        public int GetId() {
            return id;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le titre de l'article.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetTitre() {
            return titre;
        }

        /// <summary>
        /// Getter utilisé pour récupérer la description de l'article.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetDescription() {
            return description;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le mail de l'auteur de l'article.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetAuteur() {
            return auteur;
        }

        /// <summary>
        /// Getter utilisé pour récupérer la date de création de l'article.
        /// </summary>
        /// <returns>Un DateTime</returns>
        public DateTime GetDateCreation() {
            return dateCreation;
        }

        /// <summary>
        /// Getter utilisé pour récupérer l'étât de l'article.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetEtat() {
            return etat;
        }

        // --------------------------------------------------------- PARTIE SETTER ---------------------------------------------------------

        /// <summary>
        /// Setter utilisé pour valoriser le titre de l'article.
        /// </summary>
        /// <param name="titre">Le nouveau titre de l'article concernée.</param>
        public void SetTitre(string titre)
        {
            this.titre = titre;
        }

        /// <summary>
        /// Setter utilisé pour valoriser le descriptif de l'article.
        /// </summary>
        /// <param name="desc">La nouvelle description de l'article concernée.</param>
        public void SetDescription(string desc)
        {
            this.description = desc;
        }

        /// <summary>
        /// Setter utilisé pour valoriser l'état de l'article.
        /// </summary>
        /// <param name="etat">Le nouvel état de l'article concernée.</param>
        public void SetEtat(string etat)
        {
            this.etat = etat;
        }

        // --------------------------------------------------------- AUTRE(S) METHODE(S) ---------------------------------------------------------

        public override string ToString()
        {
            return "Article n°" + GetId() + " - Auteur : " + GetAuteur() + " - Etât : " + GetEtat();
        }
    }
}
