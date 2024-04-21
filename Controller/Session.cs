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
        private static FormPresseUtilisateur fuser;
        private static FormPresseAdmin fadmin;

        public static FormConnexion GetFormConnexion() {
            return fcon;
        }

        public static void SetformConnexion(FormConnexion f) {
            fcon = f;
        }

        public static FormPresseUtilisateur GetFormUser() {
            return fuser;
        }

        public static void SetFormUser(FormPresseUtilisateur f) {
            fuser = f;
        }

        public static FormPresseAdmin GetFormAdmin() {
            return fadmin;
        }

        public static void SetFormAdmin(FormPresseAdmin f) {
            fadmin = f;
        }

        public static int GetIdUtilisateur()
        {
            return idUtilisateur;
        }

        public static string GetTypeUtilisateur()
        {
            return typeUtilisateur;
        }

        public static void SetIdUtilisateur(int id) {
            idUtilisateur = id;
        }

        public static void SetTypeCpteUtilisateur(string type)
        {
            typeUtilisateur = type;
        }
    }
}
