Tableau des Médailles
Les Jeux peuvent finalement commencer mais une question est sur toutes les lèvres : Quel pays est actuellement en tête au classement ?

Tu connais le nombre de médailles de chaque pays et ton but est de déterminer lequel est en première place.

Le classement se fait en fonction des médailles d'or puis d'argent puis de bronze.

Il n'y aura jamais d'égalité pour la première place.

Données
Entrée
Ligne 1 : un entier N, le nombre de pays (1 <= N <= 100).

Les N lignes suivantes : séparés par des espaces : C le nom du pays, G le nombre de médailles d'or, S le nombre de médailles d'argent, B le nombre de médailles de bronze.

Le nom du pays ne comprend pas d'espace et sa taille est comprise entre 1 et 30 caractères. Les nombres de médailles sont des entiers compris entre 0 et 1000.

Sortie
Le nom du pays premier au classement des médailles.

Exemple 1
Pour l'entrée :

5
Italie 12 13 15
Japon 20 12 13
Republique-de-Coree 13 9 10
Allemagne 12 13 8
France 16 26 22
Le nom du pays premier au classement est :

Japon
Explications :

Le pays avec le plus de médailles d'or est le Japon.

Exemple 2
Pour l'entrée :

7
Singapour 2 1 0
Iran 8 10 7
Ouzbekistan 10 9 7
Tunisie 5 3 3
Suisse 8 8 5
Canada 10 9 10
Ethiopie 2 1 0
Le nom du pays premier au classement est :

Canada
Explications :

Le Canada et l'Ouzbekistan ont le plus de médailles d'or et autant de médailles d'argent mais le Canada possède plus de médailles de bronze et est donc devant au classement.