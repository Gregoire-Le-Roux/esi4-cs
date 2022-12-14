# Web API - Projet School

## Contexte

Ce projet est une web API écrit en C# et le principe est que nous pouvons avoir plusieurs écoles et chacune peut avoir plusieurs professeurs.
Il y a des étudiants inscrits à une seule même école et ils sont assignés dans une classe dans cette école.

Ci-dessous un diagramme récapitulatif des tables et de leurs relations.
![image](https://user-images.githubusercontent.com/84314581/206400831-d5798532-a62f-4dbf-8f55-55e29b93b323.png)

## Mise en place du projet

Base de donnée utilisée : SQLServer avec Microsoft SQL Server Management Studio.

Pour configurer l'API, on a besoin du "Server Name" qui s'affiche lorsque l'on lance Microsoft SQL Server Management Studio, comme ci-dessous :

![image](https://user-images.githubusercontent.com/84314581/145428108-6d7ceafe-0214-4ac4-85c3-318db2d86af9.png)

On copie ce ```Server Name``` et dans les dossiers de l'API, on va dans le fichier ```appsettings.json``` et il faut remplacer ```LAPTOP-MOSP0D7T\\MSSQLRPI``` par le Server Name copié précédemment.

![image](https://user-images.githubusercontent.com/84314581/206393935-0bdbe05d-27e4-41ce-8759-eb6dd2f34122.png)

Enfin, en se trouvant dans le dossier ```school-api```, on configure la base de données avec la commande ```dotnet ef database update```.  (Fonctionne grâce à une  migration déjà créée avec la commande ```dotnet ef migrations add nom_migration```)

Et voilà, tout est configuré. Lancé votre base de données puis l'api et un swagger s'ouvrira et vous pourrez tester toutes les différentes requêtes possibles.
