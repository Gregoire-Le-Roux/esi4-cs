string[] listeMot = new string[] { "Test", "Programmation", "Gregoire", "Panda", "Mounir" };
int meilleurScoreUnePartie = 0;
int meilleurScoreCinqParties = 0;
int meilleurScoreInfini = 0;
int menu = 0;

// Menu qui permet à l'utilisateur de sélectionner ce qu'il veut faire entre les options disponibles
while (menu != -1)
{
    Console.WriteLine("Bienvenue au jeu du Wordle !\n" +
        "Vous allez devoir deviner un mot en 6 essais maximum et après chaque tentative vous avez : ");
    Console.WriteLine("- en vert les lettres placés à la bonne position");
    Console.WriteLine("- en jaune les lettres dans le mot mais pas à la bonne position");
    Console.WriteLine("- en blanc les lettres qui ne sont pas dans le mot\n");
    Console.WriteLine("1.Jouer 1 mot");
    Console.WriteLine("2.Jouer 5 mots");
    Console.WriteLine("3.Jouer jusqu'à perdre");
    Console.WriteLine("4.Voir les scores");
    Console.WriteLine("5.Quitter");
    string input = Console.ReadLine();
    if (int.TryParse(input, out menu))
    {
        switch (menu)
        {
            case 1:
                JouerPlusieursMots(1);
                break;
            case 2:
                JouerPlusieursMots(5);
                break;
            case 3:
                JouerJusquaPerdre();
                break;
            case 4:
                VoirLesScores();
                break;
            case 5:
                menu = -1;
                break;
            default:
                break;
        }
    }
    Console.Clear();
}

// La fonction Jouer permet de demander à l'utilisateur un prix et cela jusqu'à qu'il trouve le juste prix
int Jouer()
{
    Random aleatoire = new Random(); // Le random de C# est basé sur l'horloge du système
    int nbAleatoire = aleatoire.Next(0, listeMot.Length);
    string motADeviner = listeMot[nbAleatoire].ToUpper();
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
        AfficherMots(motADeviner, motsProposes);
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
    AfficherMots(motADeviner, motsProposes);
    if (motTrouve) Console.WriteLine($"\nVous avez trouvé le mot en {compteurEssai} essais !");
    else Console.Write($"\nVous n'avez pas réussi à trouver le mot, la réponse était \"{motADeviner}\"");
    Console.WriteLine("\nEntrez pour continuer...");
    // Permet d'attendre n'importe quelle saisie de l'utilisateur pour laisser le temps de lire le résultat de l'essai
    Console.ReadLine();

    return motTrouve == true ? compteurEssai : -1;

    void AfficherMots(string motADeviner, string[] motsProposes)
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

void JouerPlusieursMots(int nbParties)
{
    int nbEssai = 0;
    int nbTrouve = 0;
    for(int i = 0; i < nbParties; i++)
    {
        nbEssai = Jouer();
        if(nbEssai != -1) nbTrouve++;
    }
    if(nbParties == 1 && (nbEssai != -1 && (nbEssai < meilleurScoreUnePartie || meilleurScoreUnePartie == 0))) meilleurScoreUnePartie = nbEssai;
    if (nbParties == 5 && nbTrouve > meilleurScoreCinqParties) meilleurScoreCinqParties = nbTrouve;
}

void JouerJusquaPerdre()
{
    int nbTrouve = 0;
    int nbEssai;
    do {
        nbEssai = Jouer();
        if (nbEssai != -1) nbTrouve++;
    } while (nbEssai != -1);
    if(nbTrouve > meilleurScoreInfini) meilleurScoreInfini = nbTrouve;
}

void VoirLesScores()
{
    Console.Clear();

    string phraseMeilleurUnePartie = meilleurScoreUnePartie == 1 ? " Vous avez le meilleur score possible pour cette catégorie, vous avez eu beaucoup de chance pour avoir trouvé en un coup !" : meilleurScoreUnePartie == 2 ? " Bravo, seulement était-ce un coup de chance ou du talent ?" : "";
    string phraseMeilleurCinqParties = meilleurScoreCinqParties == 5 ? " Vous êtes définitivement fort à ce jeu !" : meilleurScoreCinqParties == 4 ? " Vous avez presque fait un score parfait, plus qu'une" : "";
    string phraseMeilleurInfini = meilleurScoreInfini >= 50 ? " Roi du C#." : meilleurScoreInfini < 50 && meilleurScoreInfini >= 25 ? " Prince du Code." : meilleurScoreInfini < 25 && meilleurScoreInfini >= 10 ? " Avez-vous une limite ?" : "";

    Console.WriteLine("Meilleurs scores");
    Console.WriteLine("1 mot: " + meilleurScoreUnePartie + " essais." + phraseMeilleurUnePartie);
    Console.WriteLine($"5 mots: {meilleurScoreCinqParties} mots trouvés." + phraseMeilleurCinqParties);
    Console.WriteLine($"Jusqu'à perdre: {meilleurScoreInfini} mots trouvés." + phraseMeilleurInfini); 
    
    Console.WriteLine("\nEntrez pour continuer...");
    // Permet d'attendre n'importe quelle saisie de l'utilisateur pour laisser le temps de lire le résultat de l'essai
    Console.ReadLine();
}