# PROJET 5 : Créez votre première application avec ASP .NET Core

**Date de création** : 28 avril 2025
**Date de la dernière modification** : 28 avril 2025
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
  - [Télécharger le projet](#télécharger-le-projet)
  - [Vérifier la bonne version du SDK](#vérifier-la-bonne-version-du-sdk)
  - [Configurer la base de données](#configurer-la-base-de-données)
  - [Compiler et lancer l'application](#compiler-et-lancer-lapplication)
  - [Dossier Upload / Compte Administrateur](#dossier-upload-/-compte-administrateur)
- [Guide d'utilisation](#guide-dutilisation)
  - [Comptes](#comptes)

## Contexte

Ce projet a été conçu dans le cadre de ma formation de développeur d'applications Back-end .NET (OpenClassrooms) sur la création d'un site interne afin que le client qui est propriétaire d'une concession de voitures puisse gérer l'inventaire de ses voitures à vendre par la suite. Il pourra ajouter, modifier et supprimer une voiture. Seules les voitures disponibles seront publiées et vues par tous les visiteurs du site. 

## Installation

### Télécharger le projet

=> Pour télécharger le dossier, veuillez effectuer la commande GIT ou directement dans le GIT de Visual Studio : `git clone https://github.com/Alban2001/Projet5ApplicationDotNet.git` dans un dossier vide puis ouvrir la solution du projet.

### Vérifier la bonne version du SDK

=> Ce projet contient la version 8.0.400, pour vérifier cela, dans la console, tapez la commande : `dotnet --version`

### Restaurer les dépendances

=> Veuillez effectuer la commande : `dotnet restore` afin de pouvoir avoir tous les packages Nuget et composants installés pour éviter toute erreur de librairie manquante.

### Configurer la base de données

=> Les entités et le schéma étant déja construit, vous n'avez plus qu'à effectuer la commande suivante : `Update-Database -Context ApplicationDbContext` afin de pouvoir la créer et l'avoir en local
=> Une fois la base crée, modifier la chaîne de connexion dans le fichier `appsettings.json` :

```
    "DefaultConnection": "Server=;Database=NOM_DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true",
```

### Compiler et lancer l'application

=> Cliquez sur le bouton d'exécution et choisissez IIS Express comme option. Une fois l'application lancée, vous serez un simple visiteur et juste la possibilité de visualiser les voitures et leurs détails.

### Dossier Upload / Compte Administrateur
=> Les photos des voitures et le compte administrateur seront créees automatiquement lors du lancement de l'application.


## Guide d'utilisation

### Comptes

=> Afin de pouvoir prendre la main pour gérer les voitures, vous devez utiliser le compte administrateur :
- Email : admin@express-voitures.fr
- Mot de passe : Admin126754?!

=> Vous pouvez également vous créer un compte utilisateur mais celui-ci aura les mêmes droits que le visiteur du site en cliquant sur "S'inscrire"