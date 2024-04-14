﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseRESA
{
    public class Utilisateur {
        // Déclaration des variables
        private string email;
        private string nom;
        private string prenom;
        private DateTime dateInscription;
        private DateTime? dateFermeture;
        private int nbAvertissement; 
        private string telephone;
        private string portable;
        private string typeCpte;

        // --------------------------------------------------------- PARTIE CONSTRUCTEUR ---------------------------------------------------------

        /// <summary>
        /// Constructeur d'un utilisateur avec toutes ses informations.
        /// </summary>
        // CG0002C - Connexion d'un utilisateur avec un compte fermé
        public Utilisateur(string email, string nom, string prenom, DateTime dateInscrit, DateTime dateFermeture, int nbAvertissement, string telephone, string mobile, string typeCpte)
        {
            this.email = email;
            this.nom = nom;
            this.prenom = prenom;
            this.dateInscription = dateInscrit;
            this.dateFermeture = dateFermeture;
            this.nbAvertissement = nbAvertissement;
            this.telephone = telephone;
            this.portable = mobile;
            this.typeCpte = typeCpte;
        }

        /// <summary>
        /// Constructeur d'un utilisateur avec toutes ses informations (sauf la date de fermeture).
        /// </summary>
        // CG0002D - Connexion d'un utilisateur en règle
        public Utilisateur(string email, string nom, string prenom, DateTime dateInscrit, int nbAvertissement, string telephone, string mobile, string typeCpte)
        {
            this.email = email;
            this.nom = nom;
            this.prenom = prenom;
            this.dateInscription = dateInscrit;
            this.nbAvertissement = nbAvertissement;
            this.telephone = telephone;
            this.portable = mobile;
            this.typeCpte = typeCpte;
        }

        // --------------------------------------------------------- PARTIE GETTER ---------------------------------------------------------

        /// <summary>
        /// Getter utilisé pour récupérer le mail de l'utilisateur.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetEmail()
        {
            return email;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le nom de l'utilisateur.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetNom()
        {
            return this.nom;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le prénom de l'utilisateur.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetPrenom()
        {
            return this.prenom;
        }

        /// <summary>
        /// Getter utilisé pour récupérer la date d'inscription de l'utilisateur.
        /// </summary>
        /// <returns>Un DateTime</returns>
        public DateTime GetDateInscription()
        {
            return this.dateInscription;
        }

        /// <summary>
        /// Getter utilisé pour récupérer la date de fermeture de l'utilisateur.
        /// </summary>
        /// <returns>Un DateTime</returns>
        public DateTime? GetDateFermeture()
        {
            return this.dateFermeture;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le nombre d'avertissement de l'utilisateur.
        /// </summary>
        /// <returns>Un entier</returns>
        public int GetNbAvertissement() {
            return this.nbAvertissement;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le numéro de téléphone de l'utilisateur.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetTelephone()
        {
            return this.telephone;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le numéro de portable de l'utilisateur.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetPortable()
        {
            return this.portable;
        }

        /// <summary>
        /// Getter utilisé pour récupérer le type du compte de l'utilisateur.
        /// </summary>
        /// <returns>Une chaîne de caractère</returns>
        public string GetTypeCpte()
        {
            return this.typeCpte;
        }

        // --------------------------------------------------------- PARTIE SETTER ---------------------------------------------------------

        /// <summary>
        /// Setter utilisé pour valoriser la date d'inscription de l'utilisateur.
        /// </summary>
        public void SetDateFermeture(DateTime dateFermeture) {
            this.dateFermeture = dateFermeture;
        }

        /// <summary>
        /// Setter utilisé pour incrémenter un avertissement à l'utilisateur.
        /// </summary>
        public void SetNbAvertissement() {
            this.nbAvertissement += 1;
        }

        /// <summary>
        /// Setter utilisé pour valoriser le numéro de téléphone de l'utilisateur.
        /// </summary>
        public void SetTelephone(string telephone)
        {
            this.telephone = telephone;
        }

        /// <summary>
        /// Setter utilisé pour valoriser le numéro de portable de l'utilisateur.
        /// </summary>
        public void SetMobile(string mobile)
        {
            this.portable = mobile;
        }

        // --------------------------------------------------------- AUTRE(S) METHODE(S) ---------------------------------------------------------

        public override string ToString()
        {
            return GetNom().ToUpper() + " " + GetPrenom() + " - Mail : " + GetEmail();
        }
    }
}