-- Table ETAT_VALID
CREATE TABLE IF NOT EXISTS ETAT_VALID (
    idValid INT PRIMARY KEY AUTO_INCREMENT,
    nomValid VARCHAR(100) NOT NULL
);

-- Table RUBRIQUE
CREATE TABLE IF NOT EXISTS RUBRIQUE (
    idRubrique INT PRIMARY KEY AUTO_INCREMENT,
    nomRubrique VARCHAR(255) NOT NULL
);

-- Table TYPE_CPTE
CREATE TABLE IF NOT EXISTS TYPE_CPTE (
    idTypeCpte INT(1) PRIMARY KEY AUTO_INCREMENT,
    nomTypeCpte VARCHAR(5) NOT NULL
);

-- Table COMPTE
CREATE TABLE IF NOT EXISTS COMPTE (
    numAdherent INT PRIMARY KEY AUTO_INCREMENT,
    adrMailCompte VARCHAR(150) UNIQUE,
    passeHash VARCHAR(255) NOT NULL,
    nomCompte VARCHAR(150) NOT NULL,
    prenomCompte VARCHAR(150) NOT NULL,
    dateInscription DATE NOT NULL,
    dateFermeture DATE,
    nbAvertissement INT(1),
    noTelCompte VARCHAR(15),
    noPortableCompte VARCHAR(15),
    typeCpte INT(1),
    FOREIGN KEY (typeCpte) REFERENCES TYPE_CPTE(idTypeCpte)
);

-- Table ARTICLE
CREATE TABLE IF NOT EXISTS ARTICLE (
    idArticle INT PRIMARY KEY AUTO_INCREMENT,
    titreArticle VARCHAR(500),
    descriptionArticle VARCHAR(500),
    dateArticleCreation DATE NOT NULL,
    auteurArticle INT NOT NULL,
    idValid INT NOT NULL,
    FOREIGN KEY (idValid) REFERENCES ETAT_VALID(idValid),
    FOREIGN KEY (auteurArticle) REFERENCES COMPTE(numAdherent)
);

-- Table AVIS
CREATE TABLE IF NOT EXISTS AVIS (
    idAvis INT PRIMARY KEY AUTO_INCREMENT,
    commentaire TEXT NOT NULL,
    idArticle INT,
    idAdherent INT,
    FOREIGN KEY (idArticle) REFERENCES ARTICLE(idArticle),
    FOREIGN KEY (idAdherent) REFERENCES COMPTE(numAdherent)
);

-- Table de liaison entre ARTICLE et RUBRIQUE (N-N)
CREATE TABLE IF NOT EXISTS ARTICLE_RUBRIQUE (
    idArticle INT,
    idRubrique INT,
    PRIMARY KEY (idArticle, idRubrique),
    FOREIGN KEY (idArticle) REFERENCES ARTICLE(idArticle),
    FOREIGN KEY (idRubrique) REFERENCES RUBRIQUE(idRubrique)
);

-- Jeu d'essai : Type de Compte (ADMIN & USER)
INSERT INTO `type_cpte` (`nomTypeCpte`) VALUES ('USER'), ('ADMIN');

-- Jeu d'essai : Etats possibles des articles (EN ATTENTE, VALIDE & REJET)
INSERT INTO `etat_valid` (`nomValid`) VALUES ('EN ATTENTE'), ('VALIDE'), ('REJET');

-- Jeu d'essai : Rubriques
INSERT INTO `rubrique` (`nomRubrique`) VALUES ('SPORT'), ('ÉDUCATION'), ('ÉCONOMIE'), ('POLITIQUE'), ('GASTRONOMIE'), ('FAITS DIVERS'), ('ÉCOLOGIE'), ('SOCIOLOGIE'), ('CULTURE');

-- Jeu d'essai : Utilisateur
-- Utilisateur 1 : Administrateur
-- Utilisateur 2 : Utilisateur lambda avec compte fermé
-- Utilisateur 3 : Utilisateur Malveillant
INSERT INTO `compte` (`adrMailCompte`, `passeHash`, `nomCompte`, `prenomCompte`, `dateInscription`, `dateFermeture`, `nbAvertissement`, `noTelCompte`, `noPortableCompte`, `typeCpte`) VALUES ('giovanni.rumilly@gmail.com', 'e3c9a0f109ee9595af1dc2b5d5c1dc86', 'Rumilly', 'Giovanni', '2024-02-21', NULL, 0, NULL, NULL, 2), ('alice.smith@example.com', '814660ea649a08560f87c00a5f00d8da', 'Smith', 'Alice', '2024-02-23', '2024-03-26', 0, NULL, NULL, 1), ('bob.johnson@example.com', '5655f26ec0c36c0b19a8a0ee219e9a70', 'Johnson', 'Bob', '2024-02-24', NULL, 3, NULL, NULL, 1);

-- Jeu d'essai : Articles
INSERT INTO `article` (`titreArticle`, `descriptionArticle`, `dateArticleCreation`, `auteurArticle`, `idValid`) VALUES ('Vente d\'ordinateur', 'Bonjour à tous, je vends mon ordinateur puisque celui-ci ne fonctionne plus correctement. Si cela intéresse quelqu\'un, je fixe le prix à 450 euros. C\'est un ordinateur plutôt bon.', '2024-04-09', '1', '1'), ('Signature pétition', 'Cause : La déforestation. Bonjour, je vous réclame votre aide pour sauver notre planète. Merci pour votre aide', '2024-04-01', '1', '3');