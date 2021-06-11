<!--> Ceci doit être le fichier README.md à la racine de votre dépôt <-->

# Informations générales

## Equipe

- Numéro d'équipe : 4.1
- Nom de la base de données : MusiquePT2_F
- Composition de l'équipe :
  - Samuel Khalifa
  - Anna Briançon
  - Augustin Colas
  - Roméo Tesei
  - Fil Veith

## Projet

Donner ici le nom et une description courte du projet avec un screenshot représentatif de l'application.

Vous pouvez également préciser ici quelques éléments qui pourraient nous aider à compiler/déployer ou tester votre application :
- l'éventuelles bibliothèques externes à installer (donner la procédure)


Dédisclasik est une application permettant de faciliter la gestion d'une discothèque, grâce à une interface graphique intelligente et révolutionnaire, elle est simple d'utilisation et riche en fonctionnalités. 
Elle permet de consulter les disques disponibles ainsi que de les emprunter et de les rendre. 

L'application possède deux interfaces principales :
- une pour l'administrateur, qui lui permettra d'avoir une vision plus claire de l'état de la discothèque (liste des abonnés, albums empruntés, retards de rendus, etc.)
- une pour les abonnés, permettant d'emprunter des albums (qu'il a cherché ou qui lui sont suggérés), de facilement voir ce qu'il a emprunté, de prolonger un emprunt et de rendre.

![<application>](applicat.PNG)




PS:
- des jeux de données à appliquer sur la base avant de lancer l'application ou les tests : Il n'y a rien à faire les tests s'occupe de tout


# User Stories

## US1: En tant que futur client de la discothèque, je souhaite pouvoir être abonné afin de pouvoir emprunter des albums.

- [x] US implémentée (on peut emprunter et rendre un album)

Cas limite et détails:
- [x] Qu’est-ce qui se passe si on essaie de s’inscrire avec un login déjà existant ?
- [x] Est-ce que le choix du pays est bien un menu déroulant ?
- [x] Est-ce que les champs sont bien limités à 32 caractères ?  PS: Sauf le mdp qui est limité à 256 bit du au hachage sha256
- [x] Peut-on s'inscrire avec un nom vide ?
- [x] Peut-on s'inscrire avec un nom qui ne contient qu'un espace ?
- [x] Est-ce qu'il est bien possible de s'inscrire sans pays (car c'est facultatif) ?
- [x] L'ordre des champs est correct lorsqu'on appuie sur "TAB"
- [x] Est-ce que des messages d'erreur explicitent apparaissent en cas d'erreur ? ("Le champ prénom n'a pas été rempli", "Ce login est déjà utilisé" etc.)

## US2: En tant qu’abonné, je souhaite pouvoir consulter les albums que j'ai empruntés.
- [x] US implémentée

Cas limite et détails:
- [x] Qu’est-ce qui se passe si j’essaie d’emprunter un album déjà emprunté ? (Penser à essayer tous les cas, comme cliquer 2 fois sur le bouton “emprunter”)
- [x] Qu’est-ce qui se passe si j’emprunte, je retourne, et que je ré-emprunte le même album ?
- [x] Est-ce que la date de retour est bien basée sur les délais de la table "Genre" ?
- [x] Est-ce que je distingue bien les albums disponibles des empruntés dans l'affichage ?
- [x] Est-ce que je vois bien toutes les informations sur les albums (casier, rangée, éditeur, pays de l'éditeur, année d'édition...)

## US3: En tant qu’abonné, je souhaite prolonger l'emprunt d'un album pour un mois supplémentaire (cette opération n’est possible qu’une fois par emprunt).
- [x] US implémentée

Cas limite et détails:
- [x] Qu’est-ce qui se passe si on essaie de re-prolonger ? (Penser à essayer un peu tous les cas, comme cliquer 2 fois sur le bouton “prolonger”) Reponse: Le bouton est inactif apres avoir prolonger
- [x] Est-ce que je ne peux prolonger que les non rendus ?

## US11: En tant que client du projet, je souhaite une proposition de maquette d’IHM qui après validation pourra donner lieu à un développement.

- [x] L'interface est fonctionnelle
- [x] L'interface est ergonomique (UX)
- [x] L'interface est esthétique (UI)

## US4: En tant qu’administrateur je souhaite connaître les emprunts qui ont été prolongés.
- [x] US implémentée

Cas limite et détails:
- [x] Vois-je suffisamment d’infos par emprunt (nom de l'emprunteur, dates, album...) ?
- [x] Est-ce qu'ils sont triés par date ?

## US5: En tant qu’administrateur de la discothèque en ligne, je souhaite lister les abonnés ayant des emprunts non rapportés en retard de 10 jours.
- [x] US implémentée

Cas limite et détails:
- [ ] Vois-je suffisamment d’infos par emprunt (nom de l'emprunteur, dates, album...) ?
- [ ] Est-ce qu'ils sont triés par date ?

## US6: En tant qu'administrateur de la discothèque en ligne, j'aimerais pouvoir purger les abonnés n'ayant pas emprunté depuis plus d'un an.
- [x] US implémentée

Cas limite et détails:
- [x] Vérifier qu’on a bien une confirmation qui nous indique quels utilisateurs vont être purgés
- [x] Vérifier que les utilisateurs qui ont des emprunts en cours ne sont de toutes façons pas purgés

## US7: En tant qu’administrateur de la discothèque, je souhaite connaître les 10 albums les plus empruntés dans l'année.
- [x] US implémentée

Cas limite et détails:
- [x] Bien vérifier que c’est ceux de l’année et pas de toute la base de données

## US8: En tant qu’administrateur de la discothèque en ligne, je souhaite connaître les albums qui n’ont pas été empruntés depuis plus d’un an.
- [x] US implémentée

Cas limite et détails:
- [x] Vérifier que les albums qui n’ont jamais été empruntés apparaissent bien
- [ ] On a demandé également de trier par date décroissante d’emprunt (les empruntés le plus récemment doivent apparaître en premier)

## US9: En tant qu’abonné, je souhaite prolonger l'emprunt de tous mes emprunts.
- [x] US implémentée

Cas limite et détails:
- [x] Vérifier que les emprunts rendus ne sont pas prolongés
- [x] Vérifier que les déjà prolongés ne sont pas prolongés

## US10: En tant qu’abonné, je souhaite que le logiciel me suggère des albums à emprunter qui peuvent me plaire.
- [x] US implémentée

Cas limite et détails:
- [x] Est-ce que la suggestion exploite la popularité (exemple: genre similaire aux albums que j'ai empruntés, et trié par nombre de fois que les albums ont été empruntés)
- [x] Affiche les bonnes infos ? (où sont-ils… empruntés ou rangée/casier)

## US-TU1: Tests unitaires

À ce stade, la priorité est d'avoir des tests unitaires fonctionnels pour US1 & US2

- [x] Les tests ou une procédure documentée permet de remettre la base de données dans un état connu (on ne se base pas sur l'état de la base de données au moment de lancer les tests)
- [x] US1
- [x] US2

# US12: En tant qu'administrateur, je veux pouvoir lister tous les abonnés
- [x] US implémentée

Cas limite et détails:
- [x] Est-ce qu'on affiche bien toutes les informations ?
- [x] Quel critère de tri ? Par date de création 

# US13: En tant qu’utilisateur du logiciel, je souhaite que les résultats soient paginés dès que la liste est trop longue pour un meilleur confort d’utilisation.
- [x] US Implémentée

Cas limite et détails:
- [x] Est-ce que la pagination est bien performante ? C'est-à-dire est-ce que les données sont bien récupérées uniquement au besoin et pas toutes dans le C#

# US14: En tant qu'utilisateur, je souhaite pouvoir rechercher un album par son nom
- [x] US Implémentée

Cas limite et détails:
- [x]  Qu’est-ce qui se passe si on tape "mozart requiem"
  - On s’attend à voir “Mozart Verdi: Requiem” (deux mots clés mais séparés dans le titre trouvé)
- [x]  Qu’est-ce qui se passe si on tape "bach flute" ou "bach flûte"
  - On s’attend à voir "Bach: Sonates pour flûte” (accent sur le û)
- [x]  Qu’est-ce qui se passe si on tape "violoncelles bach"
  - On s’attend à voir “Bach: Suites pour violoncelles” (les mots ne sont pas dans l’ordre)

# US15: En tant qu'abonné et administrateur, on souhaite voir les pochettes d'album dans l'IHM lorsqu'ils sont mentionnés
- [x] US Implémentée

# US16: Nous souhaitons améliorer la gestion des mots de passe

- [x] Au moment de l'inscription, je fournis le mot de passe deux fois (pour m'assurer que je ne me suis pas trompé)
- [x] S'assurer qu'ils ne soient pas stockés en clair dans la base de données
- [x] Un administrateur peut changer le mot de passe de n'importe quel utilisateur
- [x] Un utilisateur peut changer son mot de passe, il fournit son mot de passe actuel et le nouveau mot de passe (2 fois)
- [x] Tous les champs qui contiennent des mots de passe ne sont pas visible à l'écran (mais des *** à la place), mais avec possibilité des les révéler (bouton "œil")
- [x] Quand les mots de passes ne correspondent pas, un message d'erreur clair apparaît

# US17: En tant qu'administrateur, je souhaite voir les albums manquants (empruntés) d'un casier (note pour nous : ce peut-être simplement rajouter un filtre au bon endroit)

- [x] US Implémentée

# US18: En tant que mainteneur, je souhaite m'assurer que le code correspond aux normes d'architecture logicielle, de qualité et de documentation en vigueur

- [x] Le code est bien factorisé (réduire les duplications)
- [x] Commentaires des fonctions
- [x] Règles de codage homogène (libre)

## US-TU2: Tests unitaires extra

- [x] US3
- [x] US4
- [x] US5
- [x] US6
- [x] US7
- [x] US8
- [x] US9
- [x] US10
- [x] US12
- [x] US13
- [ ] US14
- [ ] US16
- [ ] US17
