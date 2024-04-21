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
    titreArticle VARCHAR(150),
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
    dateAvisCreation DATE NOT NULL,
    commentaire VARCHAR(400) NOT NULL,
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
INSERT INTO rubrique (nomRubrique) VALUES 
('SPORT'),
('SANTÉ'), 
('TECHNOLOGIE'), 
('VOYAGE'), 
('MODE'), 
('MUSIQUE'),
('ÉDUCATION'), 
('ÉCONOMIE'), 
('POLITIQUE'), 
('GASTRONOMIE'), 
('FAITS DIVERS'), 
('ÉCOLOGIE'), 
('SOCIOLOGIE'), 
('CULTURE');

-- Jeu d'essai : Utilisateurs
INSERT INTO compte (adrMailCompte, passeHash, nomCompte, prenomCompte, dateInscription, dateFermeture, nbAvertissement, noTelCompte, noPortableCompte, typeCpte) VALUES 
('giovanni.rumilly@gmail.com', 'e3c9a0f109ee9595af1dc2b5d5c1dc86', 'RUMILLY', 'Giovanni', '2024-02-21', NULL, 0, NULL, NULL, 2), 
('alice.smith@example.com', '814660ea649a08560f87c00a5f00d8da', 'SMITH', 'Alice', '2024-02-23', '2024-03-26', 0, NULL, NULL, 1), 
('bob.johnson@example.com', '5655f26ec0c36c0b19a8a0ee219e9a70', 'JOHNSON', 'Bob', '2024-02-24', NULL, 3, NULL, NULL, 1),
('john.doe@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'DOE', 'John', '2024-04-12', NULL, 0, NULL, NULL, 1),
('jane.doe@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'DOE', 'Jane', '2024-04-12', NULL, 0, NULL, NULL, 1),
('jack.smith@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'SMITH', 'Jack', '2024-04-12', NULL, 0, NULL, NULL, 1),
('jill.smith@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'SMITH', 'Jill', '2024-04-12', NULL, 0, NULL, NULL, 1),
('michael.brown@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'BROWN', 'Michael', '2024-04-12', NULL, 0, NULL, NULL, 1),
('james.wilson@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'WILSON', 'James', '2024-04-12', NULL, 0, NULL, NULL, 1),
('emma.johnson@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'JOHNSON', 'Emma', '2024-04-12', NULL, 0, NULL, NULL, 1),
('olivia.brown@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'BROWN', 'Olivia', '2024-04-12', NULL, 0, NULL, NULL, 1),
('liam.taylor@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'TAYLOR', 'Liam', '2024-04-12', NULL, 0, NULL, NULL, 1),
('noah.martinez@example.com', '5f4dcc3b5aa765d61d8327deb882cf99', 'MARTINEZ', 'Noah', '2024-04-12', NULL, 0, NULL, NULL, 1);

-- Jeu d'essai : Articles
INSERT INTO article (titreArticle, descriptionArticle, dateArticleCreation, auteurArticle, idValid) VALUES 
('Conseils pour une alimentation saine', 'Découvrez quelques conseils simples pour adopter une alimentation équilibrée et saine au quotidien.', '2024-04-11', '1', '1'), 
('Les bienfaits du sport sur la santé mentale', 'Explorez les différents moyens par lesquels le sport peut améliorer votre bien-être mental et émotionnel.', '2024-04-10', '1', '1'),
('Les dernières innovations technologiques', 'Découvrez les dernières avancées technologiques qui façonnent notre monde moderne.', '2024-04-09', '2', '2'),
('Les plus belles destinations de voyage', 'Explorez les destinations de voyage les plus captivantes et commencez à planifier votre prochaine aventure.', '2024-04-08', '2', '1'),
('Les tendances de la mode pour la saison estivale', 'Découvrez les dernières tendances de la mode pour cet été et restez à la pointe de la mode.', '2024-04-07', '3', '2'),
('Les effets économiques du changement climatique', 'Explorez les implications économiques du changement climatique et découvrez comment les entreprises s\'adaptent.', '2024-04-06', '3', '1'),
('Analyse politique des élections à venir', 'Analysez les enjeux politiques des prochaines élections et leurs implications pour l\'avenir du pays.', '2024-04-05', '4', '3'),
('Les secrets de la cuisine française', 'Découvrez les secrets de la cuisine française et apprenez à préparer des plats traditionnels délicieux.', '2024-04-04', '4', '2'),
('Faits divers : les événements marquants de la semaine', 'Retrouvez les faits divers les plus marquants de la semaine et restez informé sur l\'actualité.', '2024-04-03', '5', '1'),
('L\'importance de la préservation de la biodiversité', 'Explorez l\'importance de la préservation de la biodiversité pour la santé de la planète.', '2024-04-02', '5', '2');

-- Jeu d'essai : Avis
INSERT INTO AVIS (commentaire, dateAvisCreation, idArticle, idAdherent) VALUES 
('Article très intéressant ! Les conseils sont pratiques et faciles à mettre en œuvre. Merci pour le partage !', '2024-04-12', 1, 2),
('Je suis passionné par la nutrition et cet article m\'a beaucoup appris. Continuez à publier des contenus de qualité !', '2024-04-12', 1, 3),
('Je suis totalement d\'accord avec les bienfaits du sport sur la santé mentale. Personnellement, cela m\'a beaucoup aidé.', '2024-04-12', 2, 4),
('Super article ! Les destinations de voyage présentées sont vraiment magnifiques. J\'ai déjà envie de partir en vacances !', '2024-04-12', 4, 5),
('Je suis impressionné par les dernières innovations technologiques. C\'est incroyable de voir à quel point la technologie évolue rapidement.', '2024-04-12', 3, 6),
('Merci pour ces informations détaillées sur les tendances de la mode estivale. Cela va certainement m\'aider à choisir mes tenues pour cet été !', '2024-04-12', 5, 7),
('Cet article sur les défis économiques actuels est très pertinent. Il met en lumière des enjeux importants.', '2024-04-12', 6, 8),
('Analyse politique très complète. J\'ai beaucoup appris sur les enjeux des prochaines élections en lisant cet article.', '2024-04-12', 7, 9),
('Je suis fan de cuisine française et cet article m\'a donné envie de cuisiner. Les recettes ont l\'air délicieuses !', '2024-04-12', 8, 10),
('Très bon résumé des faits divers de la semaine. C\'est utile d\'avoir toutes ces informations au même endroit.', '2024-04-12', 9, 2);