const int MIN_PRIX = 1, MAX_PRIX = 1000;
int meilleurScore = 0;
int menu = 0;

// Menu qui permet à l'utilisateur de sélectionner ce qu'il veut faire entre les options disponibles
while(menu != 2)
{
    Console.WriteLine("Bienvenue au jeu du Juste Prix !\n" +
        "Un nombre est généré aléatoirement entre 1 et 1000 et vous devez le trouver avec le moins d'essais possible.");
    Console.WriteLine("1.Jouer");
    Console.WriteLine("2.Quitter"); 
    Console.WriteLine($"\nMeilleur score : {meilleurScore}");
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
void Jouer ()
{
    Random random = new Random(); // Le random de C# est basé sur l'horloge du système
    int leJustePrix = random.Next(MIN_PRIX, MAX_PRIX);
    int compteurEssai = 0;
    int prix = -1;
    while(prix != leJustePrix)
    {
        Console.Clear();
        Console.WriteLine("Proposez un prix :");
        string input = Console.ReadLine();
        if (int.TryParse(input, out prix))
        {
            compteurEssai++;
            if (prix == leJustePrix)
            {
                Console.WriteLine($"Vous avez trouvé le juste prix en {compteurEssai} essais!");
                if (meilleurScore == 0 || compteurEssai < meilleurScore) meilleurScore = compteurEssai;
            }
            else if (prix > leJustePrix)
            {
                Console.WriteLine("C'est moins");
            }
            else if (prix < leJustePrix)
            {
                Console.WriteLine("C'est plus");
            }
            Console.WriteLine("\nEntrez pour continuer...");
            // Permet d'attendre n'importe quelle saisie de l'utilisateur pour laisser le temps de lire le résultat de l'essai
            Console.ReadLine(); 
        }
    }
}