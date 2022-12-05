/* Enum
JourSemaine aujourdhui = JourSemaine.Lundi;

Console.WriteLine(aujourdhui);
enum JourSemaine
{
    Lundi,
    Mardi,
    Mercredi,
    Jeudi,
    Vendredi,
    Samedi,
    Dimanche
}
*/

/*
int[] monTableau; // Déclaration

monTableau = new int[50]; // Initialisation

int[] monTableauSansLimit = new int[] { 1, 45, 42334 };

int[,] tmd = new int[2, 2]; // tableau rectangulaire où il y a autant de lignes pour chaque colonnes
int[,,] tmmd = new int[5, 3, 2];

// Tableau en escalier
int[][] temd = new int[2][];

temd[0] = new int[] { 2, 5 };
temd[1] = new int[] { 2, 5, 12, 21 };

Console.WriteLine(temd);
*/

/*
int[] Tab = new int[10];

Tab[0] = 1;

for(int i = 0; i < Tab.Length; i++)
{
    Tab[i] = Tab[i] * 2;
}

Tab.ToList().ForEach(i => Console.WriteLine(i.ToString()));
*/

/*
// ArrayList

using System.Collections; 

ArrayList maCollection = new ArrayList();

maCollection.Add(new object());

maCollection.Insert(0, "TEST");

maCollection.Add("TEST 2");

foreach (object o in maCollection) // tous en lecture seule
{
    if(o.GetType() == typeof(string))
    {
        Console.WriteLine(o);
    }
}
/*

// Classe

// Les attributes et les modificateurs de classe (niveau d'accès) sont placés avant le mot cle class
// Héritage et implémentation après le mot cle class
class MaClasse // Par défaut public
{
    // Les membres : méthodes, propriétés sont placés entre les accolades
    public int MyProperty { get; set; } // Par défaut private si pas de modificateur d'accès
}

// public 
// Autorise l'accès à tous les types et à tout le projet

// private
// Autorise l'accès uniquement pour les autres membres(méthodes, propriétés) du type

// internal
// Autorise l'accès uniquement au sein de l'"assembly" (~espace de nom)

// protected
// Autorise l'accès pour les autres membres du type et pour tous les types héritant de celui-ci même en dehors de l'"assembly"

// protected internal