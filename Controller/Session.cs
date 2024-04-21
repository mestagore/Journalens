using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseRESA
{
    public class Session
    {
        // Déclaration des variables
        private static int idUtilisateur;
        private static string typeUtilisateur;
        private static FormConnexion fcon;

        // --------------------------------------------------------- PARTIE GETTER ---------------------------------------------------------

        /// <summary>
        /// Getter utilisé pour récupérer l'identifiant de l'utilisateur.
        /// </summary>
        /// <returns>Un entier</returns>
        public static int GetIdUtilisateur()
        {
            return idUtilisateur;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le type du compte de l'utilisateur.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public static string GetTypeUtilisateur()
        {
            return typeUtilisateur;
        }

        // --------------------------------------------------------- PARTIE SETTER ---------------------------------------------------------

        /// <summary>
        /// Setter utilisé pour valoriser l'identifiant du compte de l'utilisateur.
        /// </summary>
        /// <param name="type">L'identifiant du compte de l'utilisateur connecté.</param>
        public static void SetIdUtilisateur(int id) {
            idUtilisateur = id;
        }

        /// <summary>
        /// Setter utilisé pour valoriser le type du compte de l'utilisateur.
        /// </summary>
        /// <param name="type">Le type du compte de l'utilisateur connecté.</param>
        public static void SetTypeCpteUtilisateur(string type)
        {
            typeUtilisateur = type;
        }

        // --------------------------------------------------------- AUTRE(S) METHODE(S) ---------------------------------------------------------

        public static FormConnexion GetFormConnexion()
        {
            return fcon;
        }

        public static void SetformConnexion(FormConnexion f)
        {
            fcon = f;
        }
    }
}
