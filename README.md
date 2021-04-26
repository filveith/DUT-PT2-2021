[![pipeline status](https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/badges/master/pipeline.svg)](https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/pipelines)

# Comment dupliquer ce dépôt

<!-- Vous pouvez `forker` ce projet (la fourchette en haut à droite sur la page principale du dépôt) dans votre espace pour travailler tranquillement sur une copie privée, ou `commiter` dans ce dépôt si vous avez les droits de `Developer`.
Mais lors du `fork` l’organisation (`issues`, `milestones`, `labels`) est réinitialisée. -->

L'un des membres de l'équipe (`maintainer`) doit réaliser cette étape.

Pour faire une copie intégrale du dépôt, il faut passer par la fonction `export/import` de `Gitlab` :  https://docs.gitlab.com/ee/user/project/settings/import_export.html .
La démarche est alors la suivante :
- depuis `Gitlab` : créer un nouveau projet (le `+` dans le bandeau principal), sélectionner `import project` puis  `from Gitlab export`,
- donner un nom au nouveau projet (par exemple `m2106_bd_pt_agile_import`) et choisir le fichier d'export (TODO:),
- lancer `import project`,
- vous avez votre copie personnelle du dépôt.

# Mise en place de l'environnement technique

Vous devez installer le même environnement technique que pour le module `M2016 BD`
(voir https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_etd/-/blob/master/README.md).
En particulier on vous demande soit d'utiliser `VDI` avec les ressources du département, soit d'installer `SQL Server`, `SSMS` et `Visual Studio`. On vous recommande alors les versions suivantes :
- `SQL Server 2019` : https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads .
- `SSMS 18` : https://docs.microsoft.com/fr-fr/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15 .
- `Visual Studio 2019` : https://visualstudio.microsoft.com/fr/downloads/ .

***Note 1*** : Concertez-vous dans votre équipe afin de disposer de la même version de `Visual Studio`, du framework `.NET` et du module `Entity Framework`.

***Note 2*** : Pour `Visual Studio`, il est possible après 30 jours d'utilisation, que le logiciel vous demande de mettre à jour votre licence. Il suffit normalement, dans le menu `aide / enregistrer le produit`, de donner votre compte `Microsoft` (à créer si nécessaire).

Vous allez travailler sur une version modifiée de la base `MusiqueSQL` utilisée dans le module `M2106 BD`. TODO: BD info-joyeux. La procédure pour récupérer cette base est rappelée ici : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/databases/README.md. Dans le cadre de ce projet, on considère le schéma relationnel suivant :

![schema](schema.jpg)

dérivé du schéma conceptuel suivant :

![mcd](mcd.jpg)

# Organisation en équipes

Vous disposez d'un serveur `Discord` pour le module "M2204/M2106 - Méthodes Agiles et Bases de Données". Une fois que vous serez nommés sous le format "GxEy - Prénom Nom" (avec `x` votre groupe et `y` votre numéro d'équipe dans le groupe) vous serez affectés dans les canaux texte/audio correspondant à votre équipe.
Vous devez également vous inscrire dans vos équipes sur le cours Moodle de méthodes agiles, cela vous permettra en particulier d'obtenir les consignes pour les rétrospectives et de réaliser un certain nombre de remises.

Un glossaire `SCRUM` est disponible ici : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/supports/SCRUM.pdf

# Utilisation de Gitlab pour gérer son projet

Voici les étapes à suivre pour gérer efficacement votre projet.

## Constituer son équipe

Le `maintainer` doit constituer son équipe :
-	inviter les autres membres de l’équipe en tant que `developer`,
-	inviter vos enseignants `B. Mery`, `G. Passault`, `P. Ramet` et `E. Sopena` en tant que `reporter`.

## Configurer Visual Studio

1. Installer l’extension `GitLab` (https://marketplace.visualstudio.com/items?itemName=MysticBoy.GitLabExtensionforVisualStudio),
puis exécuter `GitLab_Extension_for_Visual_Studio_v1.0.189.vsix`,
2. Sous `Visual Studio`, menu `Affichage / Team Explorer`,
3. Se connecter,
4. Créer dépôt (fenêtre `Team Explorer`), en ajoutant le `.gitignore` « visual studio »,
5. Bouton `Home` (fenêtre `Team Explorer`), vous êtes prêt à travailler !

![gitlab](gitlab.png)

## Définir et affecter une `issue` (ou `user-story`)

Lorsque vous vous apprêtez à prendre une nouvelle tâche (une `issue`), rendez-vous dans la section `issues` et assignez-vous une `issue` de la liste `ToDo`. Les `issues` sont en fait des tâches à faire, elles peuvent être attribuées à une ou plusieurs personnes. Par défaut, vous avez les listes : `Open`, `ToDo`, `Doing`, `Closed`.

Vous pouvez aussi regrouper les `issues` par jalons (ou `milestones`), qui peuvent représenter par exemple des sprints dans une méthodologie agile. Le jalon est terminé lorsque toutes ses `issues` sont `Closed`.

***Note 1*** : Sous la présentation Gitlab `Board`, on peut déplacer facilement les différentes issues en fonction de leur état d’avancement.
***Note 2*** : Vous trouverez sur Moodle quelques conseils à suivre lorsque vous vous apprêtez à prendre une nouvelle `issue` dans le board, appuyez-vous sur ces consignes.

## Créer une `merge request` pour débuter votre contribution

Une fois assigné, glissez l’`issue` vers la liste `Doing`. Ouvrez ensuite l’`issue` puis cliquez sur `Create Merge Request`. Cette action va créer automatiquement une `merge-request` avec le statut `WIP` (Work In Progress). La branche de travail associée à cette dernière est également créée.
Dans votre environnement de développement, pensez à faire un `git pull` pour être sûr d’être à jour. La nouvelle branche que vous venez de créer a été synchronisée. Basculez sur cette branche avec un `git switch` (ou `git checkout` si votre `git` n'est pas suffisamment récent).

***Depuis `Visual Studio`*** :
-	onglet `Team Explorer / synchroniser / validations entrantes / tirer` pour mettre à jour votre copie locale,
-	puis aller sur `Branches / Remotes`, un double-clic sur la nouvelle branche pour qu’elle soit créée en local et pour pouvoir basculer dessus.

***Note*** : Vous avez toujours accès au dépôt https://gitlab-ce.iut.u-bordeaux.fr/Pierre/DEMO-GIT-PT2 pour un rappel des commandes `git` vues au début du semestre 2.

## Passez en mode relecture (ou `review`)

Une fois l’`issue` traitée, allez voir dans `GitLab` votre `merge-request`. Il se peut que vous ayez des conflits à régler. Vous pouvez tenter de les résoudre automatiquement sur l'interface web de `GitLab`, ou via votre environnement de développement. Une fois résolu, faites un `git commit` pour valider votre `merge`.

On vous recommande de `rebaser` votre branche de travail par rapport à la branche stable (`master` ou `develop`). Des conflits vont probablement apparaître si des contributions ont été intégrées entre temps sur la branche stable. Résolvez-les puis faites un `git rebase -continue` pour valider votre `merge`.

Vérifiez sur `GitLab` que votre problème de `Merge Conflit` a bien disparu.
Puis, cliquez sur `Resolve Wip Status` afin de montrer que le travail est terminé pour cette `merge-request`.

## Attendre les relectures de vos co-équipiers

Prenez en compte les retours proposés par vos relecteurs. Pensez à fermer les discussions pour chaque commentaire lorsque vous avez résolu le problème.
Si tout s’est bien passé, votre relecteur se chargera de faire le `Merge` final de votre branche. L'`issue`sera automatiquement fermée (`Closed`).

***Note*** : Vous pouvez mentionner une `issue` dans le message associé à vos `commit` pour y faire référence. Un message `fix issue #xxx` (avec `xxx` le numéro de l'`issue`) fermera automatiquement cette `issue`. Vous pouvez également faire référence à une autre `merge-request` avec un message contenant `#yyy` (avec `yyy` le numéro de la `merge-request`).

## En tant que relecteur

Une fois un premier `commit` effectué, il est possible de discuter directement sur la contribution (`merge-request`). Il faut alors ouvrir l'onglet `Changes`. Normalement, en tant que `Developer` vous n'avez pas les droits pour `Merger` cette `issue` dans la branche `master` du dépôt principal. Lorsque vous avez fini votre relecture et que vous n'avez plus de remarques, vous pouvez `lever le pouce` pour indiquer que de votre point de vue, cette `issue` peut-être fusionnée.

## Conditions nécessaires pour fusionner une `merge-request`

Comme dit précédemment, vous devez régler les conflits (`Merge Conflit`) et retirer le statut `WIP` de votre `merge-request`.

Dans `Settings/General/Merge Requests/Merge checks`, il est conseillé de définir les règles suivantes :

- [x] `Pipelines must succeed`
- [x] `All discussions must be resolved`

Vous pouvez également imposer que votre contribution soit `rebasée` avant d'être fusionnée en sélectionnant dans `Settings/General/Merge Requests/Merge method` l'une des deux méthodes suivantes :

- [x] `Merge commit with semi-linear history`
- [ ] `Fast-forward merge`

Vous trouverez également deux fichiers cachés à la racine de ce dépôt :

- `.gitignore` : pour définir les règles afin d'ignorer les fichiers temporaires Visual Studio,
- `.gitlab-ci.yml` : pour mettre en place un pipeline d'intégration continue minimal (c.f. https://gitlab-ce.iut.u-bordeaux.fr/PT4/demo-cicd-mstest).

## Estimation du temps d'une `issue`

***Ceci est facultatif*** : ceux qui le souhaitent peuvent essayer, vous en tirerez une expérience intéressante !

Il est possible de saisir des estimations du temps passé sur une `issue` en écrivant dans le champs commentaire :
- /estimate \<temps\> : pour ajouter une estimation
- /spend \<temps\> : pour indiquer le temps passé

Le temps se décline en :
- mo : mois
- w : semaines
- d : jours
- h : heures
- m : minutes

La barre de progression du jalon pourra en tenir compte.

# Comment conserver un fichier de configuration privé

Afin de travailler en équipe, on vous demande de versionner votre code sur le `Gitlab` de l'IUT. Depuis l'interface `Visual Studio`, dans le menu gérant les extensions, vous trouverez un `plugin` pour `Gitlab` (https://marketplace.visualstudio.com/items?itemName=MysticBoy.GitLabExtensionforVisualStudio). On vous recommande de l'utiliser. Vous pourrez ainsi visualiser vos branches (crées manuellement ou par `merge-request`) de manière graphique sans passer par une ligne de commande.

Il reste cependant un problème : votre `url` de connexion à la base de données doit rester privée (elle est nécessairement différente pour chaque co-équipier et ne doit pas être versionnée). La solution consiste à "stocker" cette `url` dans un fichier de configuration. Voici alors la ligne de code pour ouvrir une connexion :
```cs
using System.Configuration;
...
dbCon = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
```
en supposant que le fichier de configuration de l'application (`App.config` à la racine du projet) contienne, par exemple :
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    ...
    <connectionStrings>
      <add name="MyConnectionString" connectionString="Provider=SQLOLEDB;Data Source=DESKTOP-FATLC4L;Initial Catalog=Championnat;Integrated Security=SSPI" />
    </connectionStrings>
</configuration>
```

***Note*** : C'est également dans ce fichier de configuration que vous allez retrouver votre version du framework `.NET` (on vous recommande d'utiliser la même version).

Pour finir, il est nécessaire d'ignorer ce fichier (`App.config`) lors des futurs `commits`.
- Soit vous avez ignoré ce fichier depuis le début en l'ajoutant dans le fichier `.gitignore` du projet.
- Soit vous pouvez l'ignorer a posteriori (par exemple si vous avez suivi la procédure ci-dessus pour "importer" le projet initial) à l'aide de la commande :
```bash
git update-index --skip-worktree path/to/file
```

# Ressources du cours

Les supports de cours sont disponibles :
- sur `Moodle` pour la parte `Agile` : https://moodle1.u-bordeaux.fr/course/view.php?id=5598
- sur `Moodle` pour la partie `BD` : https://moodle1.u-bordeaux.fr/course/view.php?id=1465
- et sur le dépôt `Gitlab` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd

## Les bases de données

Dans le sous répertoire `databases` vous trouverez :

- la base `Championnat` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/databases/championnat/Championnat_0_Creation.sql
- la base `Modules` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/databases/modules/Modules_0_Creation.sql
- la base `MusiquePT2` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/databases/README.md

## Les supports

Dans le sous répertoire `supports` vous trouverez :

- les rappels `SQL` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/supports/M2106-1-SQL.pdf
- le support `Transact-SQL` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/supports/M2106-2-TSQL.pdf
- le support `C#` avec `OLEDB` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/supports/M2106-3-OLEDB.pdf
- le support `C#` avec `EF` : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/supports/M2106-4-EF.pdf

## Les exemples de code

Dans le sous répertoire `exemples` vous trouverez :

- 2 applications `WindowsForms` avec `OleDb` :
  - avec la base `MusiqueSQL` - 2 `ListBox` pour afficher les musiciens et leurs oeuvres : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/exemples/OLEDB_Musiciens_WindowsForms_App/README.md
  - avec la base `Championnat` - Mise à jour des joueurs : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/exemples/OLEDB_Championnat_Update_App/README.md

- 2 applications `WindowsForms` avec `Entity Framework` :
  - avec la base `MusiqueSQL` - 2 `ListBox` pour afficher les musiciens et leurs oeuvres : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/exemples/EF_Musiciens_WindowsForms_App/README.md
  - avec la base  `Championnat` - Mise à jour des joueurs : https://gitlab-ce.iut.u-bordeaux.fr/Pierre/m2106_bd_pt_agile/-/blob/master/exemples/EF_Championnat_Update_App/README.md
