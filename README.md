# Projet ASP.Net
Le git de mon projet ASP.Net sur la Coupe du Monde de football féminin 2019.

## Avant-propos
Toutes les parties du sujet ont été traitées. Ci-dessous, quelques précisions sur les différentes pages et fonctionnalités de l'application. (Ce récapitulatif ne fait pas absolument pas état de toutes les classes utilisées mais uniquement de quelques petits éléments de certaines.)

## Modèles
Trois modèles ont été crées afin de répondre au sujet :
- `Player` : correspond à une joueuse. Regroupe tous les attributs demandés : `FirstName`, `LastName` et `DateOfBirth`. Un champ pour la photo a été ajouté.
- `Team` : correspond à une équipe. Regroupe les attributs suivant : `Name`, `Flag`, `Address`, `Latitude` et `Longitude`.
- `Contract` : permet de faire l'historique des joueuses. Comporte quatre champs : `Signatory` de type `Player` (joueuse ayant signé le contrat), `Employer` de type `Team` (club ayant accueilli la joueuse), `YearFrom` (année de début du contrat) et `YearTo` (année de fin du contrat, `null` si le contrat n'est pas encore terminé).

## Formulaires
Voici les liens utiles pour accéder aux listes et formulaires d'édition des modèles cités précédemment :
- `Player` :
    - Liste : `/Player`
    - Edition : `/Player/Edit` pour ajouter une nouvelle joueuse ou `/Player/Edit/{id}` pour modifier les données de la joueuse dont l'id est égal à `{id}`.
- `Team` :
    - Liste : `/Team`
    - Edition : `/Team/Edit` pour ajouter un nouveau club ou `/Team/Edit/{id}` pour modifier les données du club dont l'id est égal à `{id}`.
- `Contract` :
    - Liste : `/Contract`
    - Edition : `/Contract/Edit` pour créer un nouveau contrat ou `/Contract/Edit/{id}` pour modifier les données du contrat dont l'id est égal à `{id}`.

## API
L'API demandée a été faite. D'autres API sont également disponibles :
    - `/api/[controller]/status` : fournit la date actuelle et le nom du contrôleur.
    - `/api/[controller]/{id}` : fournit les informations de l'élément d'id `{id}` du contrôleur associé.
    - `/api/[controller]` : fournit les informations de tous les éléments du contrôleur associé.

L'API désirée est obenue grâce au contrôleur `APIController` qui va effectuer les opérations de jointure nécessaires. L'adresse est la suivante : `/api/TeamsContractsDetails`. Cette API liste tous les clubs, avec leurs infos, ainsi que la liste des contrats associés au club (trié selon l'ancienneté du début de contrat) avec les infos de la joueuse ayant signé le contrat.

## Cartographie
