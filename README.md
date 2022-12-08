# C#

### **Projet Console**

Le projet console est un Wordle, un jeu où l'on doit deviner un mot en 6 essais maximum et à chaque essai, nous avons en vert les lettres qui sont à la bonne position, en jaune les lettres qui sont dans le mot mais pas dans la bonne position et en blanc les lettres qui ne sont pas dans le mot.

Il y a 3 modes de jeu dans ce projet :
  - Mode classique où nous devons deviner un mot puis la partie est terminé après l'avoir deviné ou après 6 essais.
  - Mode 5 parties, il faut réussir à deviner 5 mots d'affilés.
  - Mode jouer jusqu'à perdre, tant que l'utilisateur trouve le mot en moins 6 essais, il continue d'avoir des mots à la chaîne jusqu'à ne pas réussir.

Possibilité de voir ses scores sur les différents modes de jeu et de les exporter dans un fichier txt. (avec des petites surprises pour les plus forts)

Pour build le projet pour la production, faire la commannde : ```dotnet publish -c Release -r win10-x64```. Ensuite l'éxecutable se trouve dans le dossier ``` Wordle\Wordle\bin\Release\net6.0\win10-x64 ``` et il y a le fichier ```Wordle.exe```.

### **Projet API**

Le projet API se trouve dans le dossier ```school-api``` et tout le contexte / documentation du projet se trouve dans ce dossier.
