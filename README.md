# Examen-API
📌 Présentation du projet
Ce projet est une application web monopage (SPA) développée en Blazor WebAssembly (C#) permettant d'afficher des données provenant de l'API publique The Movie Database (TMDB), et d'enregistrer localement des films favoris modifiables et supprimables. L'application inclut également une série de tests unitaires pour assurer la fiabilité des fonctionnalités implémentées.

🚀 Fonctionnalités principales
Affichage des films populaires :

Récupération des données depuis l'API TMDB.

Affichage dynamique des films avec leurs informations principales (titre, résumé, date de sortie, image, note moyenne).

Gestion des favoris :

Ajout de films à une liste locale de favoris.

Modification du statut ou suppression des favoris enregistrés localement.

Stockage local via Blazored.LocalStorage.

Tests unitaires :

Tests automatisés pour vérifier les fonctionnalités clés (ajout, modification, suppression, récupération API).

🛠️ Technologies utilisées
.NET & C#

Blazor WebAssembly

Blazored.LocalStorage

API TMDB

📂 Structure du projet
Voici les fichiers principaux du projet :

text
API_Examen
│
├── Program.cs                # Configuration initiale de l'application Blazor
│
├── Services
│   └── MovieService.cs       # Service pour appeler l'API TMDB et récupérer les films
│
├── Models
│   └── Movie.cs              # Modèle représentant un film et sa réponse API
│
├── Pages
│   ├── Home.razor            # Page d'accueil
│   ├── Favoris.razor         # Page affichant les films favoris locaux
│   └── Film.razor            # Page affichant les films populaires
│
├── wwwroot/css/app.css       # Feuille de style CSS personnalisée pour l'application
└── appsettings.json          # Contient le Bearer Token pour l'API TMDB


✅ Scénarios de tests
Voici les scénarios d'utilisation principaux à tester manuellement ou automatiquement :

Scénario 1 : Affichage des films populaires depuis l'API TMDB
├── Action	                   ── Résultat attendu
└── Ouvrir la page d'accueil   ── Les films populaires sont affichés correctement avec titre, image, résumé et note moyenne.

Scénario 2 : Ajout d'un film aux favoris locaux
├── Action	                                        ── Résultat attendu
└── Cliquer sur "Ajouter aux favoris" sur un film	── Le film apparaît dans la page "Favoris".

Scénario 3 : Modification du statut d'un favori local
├── Action	                                            ── Résultat attendu
└── Modifier le statut d'un favori (ex: Neutre → Vu)	── Le nouveau statut est sauvegardé localement et affiché correctement.

Scénario 4 : Suppression d'un favori local
├── Action	                                            ── Résultat attendu
└── Cliquer sur "Supprimer" dans la liste des favoris	── Le film disparaît immédiatement de la liste.

Scénario 5 : Gestion des erreurs API (Bearer Token invalide)
├── Action	                                      ── Résultat attendu
└── Utiliser un Bearer Token invalide ou expiré	  ── Une erreur explicite est affichée ("Erreur 401 : Vérifie ton Bearer Token dans appsettings.json.")

🧪 Tests Unitaires implémentés
Les tests unitaires suivants sont implémentés dans le projet API_Examen_test :

ModificationTests.cs → Vérifie la modification correcte du statut et la suppression d'un film des favori.

MovieServiceTests.cs → Vérifie la récupération correcte des films depuis l'API TMDB.

FavoritesTests.cs → Vérifie l'ajout/suppression corrects de films dans les favoris locaux.

Ces tests assurent que les fonctionnalités clés restent fiables lors des évolutions futures.

📖 Justifications méthodologiques et conceptuelles
Méthode de résolution choisie :
│
├── Approche modulaire et orientée composants : Blazor impose naturellement une architecture orientée composant, 
│   ce qui facilite la séparation claire des responsabilités (logique métier, gestion des données, interface utilisateur).
│
├── Séparation claire entre les services (MovieService) et les composants Blazor (.razor) afin de respecter les 
│   bonnes pratiques du développement web moderne.
│
└── Stockage local via Blazored.LocalStorage choisi pour simplifier la gestion locale des favoris côté client sans
    devoir implémenter une base de données complète côté serveur.

Choix conceptuels et technologiques :
│
├── Blazor WebAssembly : imposé par le cadre du cours, permettant une prise en main rapide du développement 
│   front-end avec C#, tout en offrant une expérience utilisateur fluide et réactive.
│
├── API TMDB : choisie librement parmi d'autres API possibles, car elle propose une documentation claire, des 
│   données riches et variées sur les films, ainsi qu'une facilité d'intégration idéale pour un projet pédagogique.
│
└── Blazor ed.LocalStorage : bien que l'utilisation d'une base de données côté serveur (SQL Server, SQLite ou autre)
    était possible, le choix du stockage local simplifie grandement l'architecture du projet. Ce choix permet de se 
    concentrer davantage sur l'apprentissage et la compréhension des mécanismes côté client en Blazor sans complexifier 
    inutilement l'infrastructure.

Ces choix méthodologiques et technologiques ont été faits pour répondre efficacement aux exigences pédagogiques du cours tout en assurant une application fonctionnelle, facilement maintenable et testable.