# C#

### **Questions de cours**
#### Expliquer o is DateTime d 
L’expression ```o is DateTime d``` est une expression faisant partie de critères spéciaux disponible depuis C# 7.0 sortie en début 2017, qui permet de faire un test de type puis de déclarer et initialiser une variable avec la valeur tester en une seule expression. 

Exemple d’utilisation de l’expression
```C#
DateTime o = new DateTime(2022, 12, 05);
// Si o est de type DateTime, déclare et initialise d avec la valeur et le type de o
if (o is DateTime d) Console.WriteLine(d); // Affiche 05/12/2022 00:00:00
```

Source: https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/proposals/csharp-7.0/pattern-matching

#### Expliquer les portées public, private, protected
Public, private, protected sont trois des cinq modificateurs d’accès permettant de définir le niveau d’accessibilité des types ou des membres de type. Cela permet de contrôler leur accessibilité par rapport aux autres ```class``` ou ```struct```.

- public: rend accessible le type ou membre de type dans n’importe quelle partie du code
- private: le type ou membre de type est accessible uniquement dans la même ```class``` ou ```struct```
- protected: le type ou membre de type est accessible uniquement dans la même ```class``` / ```struct``` ou à toutes autres class dérivé de celle définie

A savoir que le dérivé d’un class protected peut redéfinir l’accessibilité d’une méthode ou d’un type.

Par défaut, tous les champs d’une class doit être à private et avoir un setter en public pour pouvoir modifier la valeur. Cela permet d’assurer l’intégrité des champs de la class et aussi d’ajouter simplement des traitements particuliers donc de fiabiliser son fonctionnement car en appelant le setter on est assuré de l’événement qui change la valeur.

```C#
public class Hero { 
    private int name;
 
    public void setName(string newName) {
          name = newName;
    }
}
```

L’utilisation de protected sert lorsque qu’une classe en dérive d’une autre et que le champ ne doit pas être accessible partout dans le code mais doit l’être dans la classe dérivé.

```C#
class Person { 
	protected string name;
} 

class Hero: Person 
{ 
	static void Main() 
	{ 
		var hero = new Hero(); 
		hero.name = "Spider Man"; 
		Console.WriteLine($"name = {hero.name}"); 
	}
}
```

Source: https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

#### Montrer un exemple d’usage de classe abstraite et d’interface et expliquer leurs différences

Une classe abstraite ne peut pas être instanciée, peut déclarer et définir des méthodes.  

Exemple d'usage d'une classe abstraite

```C#
abstract class Person
{
    protected string name { get; set; }
}

class Hero : Person
{
	public string name { get; set; }
    public string power { get; set; }

}

class Program
{
	static void Main()
	{
		var hero = new Hero();
		hero.name = "Spider Man";
		hero.power = "Spider";
		Console.WriteLine($"name = {hero.name} and power = {hero.power}");
	}
}
```

Une interface ne peut pas être instancié, ne peut pas initialiser / définir de champs ou de méthodes mais les déclarer, toutes les class dérivées de l’interface doivent implémenter toutes ses méthodes.

Exemple d'usage d'une interface

```C#
interface Person
{
	string toString();
}

class Hero : Person
{
	public string name { get; set; }
    public string power { get; set; }

	public string toString()
    {
		return $"{name} has the power {power}";
    }
}

class Vilain : Person
{
	public string name { get; set; }
	public string rank { get; set; }

	public string toString()
	{
		return $"{name} dangerosity rank is {rank}";
	}
}

class Program
{
	static void Main()
	{
		Hero hero = new Hero();
		hero.name = "Spider Man";
		hero.power = "Spider";
		Console.WriteLine(hero.toString());

		Vilain vilain = new Vilain();
		vilain.name = "Dark Spider Man";
		vilain.rank = "S";
		Console.WriteLine(vilain.toString());
	}
}
```

Les différences entre une classe abstraite et une interface sont que la classe abstraite peut déclarer et définir ses membres (méthodes, champs) alors que l’interface ne peut que les déclarer, la classe abstraite peut contenir des membres non-abstraits et abstraits comparé à l’interface qui a tous ses membres abstraits. 

Sources: 

https://www.geeksforgeeks.org/difference-between-abstract-class-and-interface-in-c-sharp/ 

https://www.c-sharpcorner.com/UploadFile/93126e/difference-between-abstract-class-and-an-interface/#:~:text=An%20abstract%20class%20doesn't,we%20can%20achieve%20multiple%20inheritance.

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
