string[] listeMot = new string[] { "Test", "Programmation", "Gregoire", "Panda", "Mounir" }; 
int menu = 0;

// Menu qui permet à l'utilisateur de sélectionner ce qu'il veut faire entre les options disponibles
while (menu != 2)
{
    Console.WriteLine("Bienvenue au jeu du Wordle !\n" +
        "Vous allez devoir deviner un mot en 6 essais maximum et après chaque tentative vous avez : ");
    Console.WriteLine("- en vert les lettres placés à la bonne position");
    Console.WriteLine("- en jaune les lettres dans le mot mais pas à la bonne position");
    Console.WriteLine("- en blanc les lettres qui ne sont pas dans le mot\n");
    Console.WriteLine("1.Jouer");
    Console.WriteLine("2.Quitter");
    string input = Console.ReadLine();
    if (int.TryParse(input, out menu))
    {
        switch (menu)
        {
            case 1:
                Jouer();
                break;
            case 2:
                break;
            default:
                break;
        }
    }
    Console.Clear();
}

// La fonction Jouer permet de demander à l'utilisateur un prix et cela jusqu'à qu'il trouve le juste prix
void Jouer()
{
    Random aleatoire = new Random(); // Le random de C# est basé sur l'horloge du système
    int nbAleatoire = aleatoire.Next(0, listeMot.Length);
    //string motADeviner = listeMot[nbAleatoire];
    string motADeviner = "test".ToUpper();
    string motDeBase = "";
    for(int i = 0; i < motADeviner.Length; i++)
    {
        motDeBase = motDeBase + "_";
    }
    string[] motsProposes = Enumerable.Repeat(motDeBase, 6).ToArray();
    int compteurEssai = 0;
    bool motTrouve = false;
    while (motTrouve == false && compteurEssai <= 5)
    {
        AfficherMots();
        Console.WriteLine("\nProposez un mot :");
        string motPropose = Console.ReadLine();
        if (motPropose.Length == motADeviner.Length)
        {
            motsProposes[compteurEssai] = motPropose;
            if (motPropose.ToLower() == motADeviner.ToLower())
            {
                motTrouve = true;
            }
            compteurEssai++;
        }
    }
    AfficherMots();
    Console.WriteLine($"\nVous avez trouvé le mot en {compteurEssai} essais!");
    Console.WriteLine("\nEntrez pour continuer...");
    // Permet d'attendre n'importe quelle saisie de l'utilisateur pour laisser le temps de lire le résultat de l'essai
    Console.ReadLine();

    void AfficherMots()
    {
        Console.Clear();
        Console.WriteLine($"Mot en {motADeviner.Length} lettres");
        for (int i = 0; i < motsProposes.Length; i++)
        {
            string motAffiche = motsProposes[i].ToUpper();
            for(int iMot = 0; iMot < motAffiche.Length; iMot++)
            {
                char lettre = motAffiche[iMot];
                bool lettreTrouve = false;
                int iMotADeviner = 0;
                while (lettreTrouve == false && iMotADeviner < motADeviner.Length)
                {
                    if (lettre == motADeviner[iMotADeviner] && iMot == iMotADeviner)
                    {
                        lettreTrouve=true;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (lettre == motADeviner[iMotADeviner]) Console.ForegroundColor = ConsoleColor.Yellow;
                    iMotADeviner++;
                }                
                Console.Write(lettre + " " + (iMot == motAffiche.Length - 1 ? "\n" : ""));
                Console.ResetColor();
            }
        }
    }
}