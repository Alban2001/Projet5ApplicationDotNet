# PROJET 5 : Cr�ez votre premi�re application avec ASP .NET Core

**Date de cr�ation** : 28 avril 2025
**Date de la derni�re modification** : 28 avril 2025
**Auteur** : Alban VOIRIOT
**Informations techniques** :

- **Technologies** : HTML, CSS, C#, .NET MVC CORE, SQL, Bootstrap, SQLServer
- **Version de .NET CORE** : 6.0
- **Version de SDK ** : 8.0.400
- **Version de SQLServer** : 18.7.1
- **Version de Bootstrap** : 5.0.2

## Sommaire

- [Contexte](#contexte)
- [Installation](#installation)
  - [T�l�charger le projet](#t�l�charger-le-projet)
  - [V�rifier la bonne version du SDK](#v�rifier-la-bonne-version-du-sdk)
  - [Configurer la base de donn�es](#configurer-la-base-de-donn�es)
  - [Compiler et lancer l'application](#compiler-et-lancer-lapplication)
  - [Dossier Upload / Compte Administrateur](#dossier-upload-/-compte-administrateur)
- [Guide d'utilisation](#guide-dutilisation)
  - [Comptes](#comptes)

## Contexte

Ce projet a �t� con�u dans le cadre de ma formation de d�veloppeur d'applications Back-end .NET (OpenClassrooms) sur la cr�ation d'un site interne afin que le client qui est propri�taire d'une concession de voitures puisse g�rer l'inventaire de ses voitures � vendre par la suite. Il pourra ajouter, modifier et supprimer une voiture. Seules les voitures disponibles seront publi�es et vues par tous les visiteurs du site. 

## Installation

### T�l�charger le projet

=> Pour t�l�charger le dossier, veuillez effectuer la commande GIT ou directement dans le GIT de Visual Studio : `git clone https://github.com/Alban2001/Projet5ApplicationDotNet.git` dans un dossier vide puis ouvrir la solution du projet.

### V�rifier la bonne version du SDK

=> Ce projet contient la version 8.0.400, pour v�rifier cela, dans la console, tapez la commande : `dotnet --version`

### Restaurer les d�pendances

=> Veuillez effectuer la commande : `dotnet restore` afin de pouvoir avoir tous les packages Nuget et composants install�s pour �viter toute erreur de librairie manquante.

### Configurer la base de donn�es

=> Les entit�s et le sch�ma �tant d�ja construit, vous n'avez plus qu'� effectuer la commande suivante : `Update-Database -Context ApplicationDbContext` afin de pouvoir la cr�er et l'avoir en local
=> Une fois la base cr�e, modifier la cha�ne de connexion dans le fichier `appsettings.json` :

```
    "DefaultConnection": "Server=;Database=NOM_DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true",
```

### Compiler et lancer l'application

=> Cliquez sur le bouton d'ex�cution et choisissez IIS Express comme option. Une fois l'application lanc�e, vous serez un simple visiteur et juste la possibilit� de visualiser les voitures et leurs d�tails.

### Dossier Upload / Compte Administrateur
=> Les photos des voitures et le compte administrateur seront cr�ees automatiquement lors du lancement de l'application.


## Guide d'utilisation

### Comptes

=> Afin de pouvoir prendre la main pour g�rer les voitures, vous devez utiliser le compte administrateur :
- Email : admin@express-voitures.fr
- Mot de passe : Admin126754?!

=> Vous pouvez �galement vous cr�er un compte utilisateur mais celui-ci aura les m�mes droits que le visiteur du site en cliquant sur "S'inscrire"