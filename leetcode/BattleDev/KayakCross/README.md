Kayak Cross
Sur le bassin de kayak cross, l'eau tourbillonne et les athlètes se préparent à affronter la force des courants. Alors que les kayakistes se concentrent, une question te turlupine : quelles positions de départ pourraient mener à la victoire, s'ils se laissaient uniquement porter par le courant ?

Le bassin est modélisé sous forme d'une grille de N lignes et M colonnes, avec des directions de courant sur chaque case v, >, ^, <. Avec v pour bas, > pour droite, ^ pour haut et < pour gauche.

À chaque seconde, chaque athlète se retrouve porté par le courant sur la case indiquée par la direction de sa case actuelle. Les collisions entre kayakistes ne sont pas prises en compte.

Les athlètes partent de la première ligne, et atteignent l’arrivée en dépassant la ligne numéro N.

Il est possible que certaines positions de départ ne permettent pas d'atteindre la ligne d'arrivée mais il y a toujours au moins une position qui l'atteint.

Le courant ne fera pas sortir du bassin sauf pour passer l'arrivée ligne N.

Données
Entrée
Ligne 1 : deux entiers N et M séparés par un espace, le nombre de lignes (6 <= N <= 50) et de colonnes (4 <= M <= 50) du bassin.

Les N lignes suivantes : M directions (v, >, ^ ou <) : la direction du courant pour chaque case de la ligne considérée.

Sortie
La(les) position(s) de départ(s) permettant d'arriver en première position (par numéro de position croissant et séparés par des espaces si plusieurs positions permettent d'arriver en même temps en première place).

Exemple 1
Pour l'entrée :

8 4
vvvv
v<vv
v>v^
>^v<
v>v<
>v<^
>vv<
>>v<
La position gagnante est :

3
Explications :

La position n°1 arrive au bout de 14 secondes, la n°2 au bout de 15, la n°3 au bout de 10. La n°4 n'arrive jamais et reste bloquée.

Image d'explication des parcours pour chaque position de départ
Exemple 2
Pour l'entrée :

8 8
>vvvvvv<
>>vv<v>v
^<v>v>vv
>^<<vvvv
>^v<<<vv
v>v^<v<v
vv<<v<<<
vvvv<v>v
Les positions gagnantes sont :

4 6
Explications :

Les positions n°4 et 6 atteignent la ligne d'arrivée au bout de 12 secondes, les positions n°5 et 7 au bout de 13. La position de départ n°8 arrive après 14 secondes. Et les positions n°1, 2 et 3 n'atteignent jamais la ligne d'arrivée. </v<<<</v<v</vv</vvvv</vv