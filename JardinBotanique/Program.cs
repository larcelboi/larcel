
using JardinBotanique.ContenuJardin;
using JardinBotanique.Exceptions;
using JardinBotanique.Meteo;

static void PreparerPlantesJardinInitiales(Jardin jardin, DateOnly date)
{
    try
    {
        jardin.Planter(new Plante("Rose", TypePlante.Fleur, 2, 1), date);
        jardin.Planter(new Plante("Lavande", TypePlante.Herbe, 1, 2), date);
        jardin.Planter(new Plante("Cactus du désert", TypePlante.Cactus, 1, 5), date);
    }
    catch (RessourcesInsuffisantesException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }
}

static Plante ChoisirPlante()
{
    List<Plante> plantesDisponibles = new List<Plante>(){
        new Plante("Érable", TypePlante.Arbre, besoinEau: 2, frequenceEngrais: 3),
        new Plante("Tulipe", TypePlante.Fleur, besoinEau: 1, frequenceEngrais: 2),
        new Plante("Menthe", TypePlante.Herbe, besoinEau: 1, frequenceEngrais: 1),
        new Plante("Aloe Vera", TypePlante.Cactus, besoinEau: 1, frequenceEngrais: 4),
        new Plante("Lilas", TypePlante.Fleur, besoinEau: 2, frequenceEngrais: 2),
        new Plante("Bouleau", TypePlante.Arbre, besoinEau: 3, frequenceEngrais: 3),
        new Plante("Basilic", TypePlante.Herbe, besoinEau: 1, frequenceEngrais: 1),
        new Plante("Opuntia", TypePlante.Cactus, besoinEau: 1, frequenceEngrais: 5)
    };

    Console.WriteLine("\n--- Plantes disponibles ---");
    for (int i = 0; i < plantesDisponibles.Count; i++)
    {
        Plante p = plantesDisponibles[i];
        Console.WriteLine($"{i + 1}. {p.Nom} ({p.Type}) | Eau/jour: {p.BesoinEauParJour} | Fréquence engrais: {p.FrequenceEngrais} jours.");
    }

    int choix;
    Plante planteChoisie = null;
    do
    {
        Console.Write("Choisissez le numéro de la plante à planter: ");
        if (int.TryParse(Console.ReadLine(), out choix) &&
            choix >= 1 && choix <= plantesDisponibles.Count)
        {
            planteChoisie = plantesDisponibles[choix - 1];
        }
        else
        {
            Console.WriteLine("Choix de plante invalide. Veuillez réessayer.");
        }
    } while (planteChoisie == null);

    return planteChoisie;
}

// Affichage du menu principal
Console.ForegroundColor = ConsoleColor.Green;
string? choix = "";
Console.WriteLine(@"
         wWWWw               wWWWw
   vVVVv (___) wWWWw         (___)  vVVVv
   (___)  ~Y~  (___)  vVVVv   ~Y~   (___)
    ~Y~   \|    ~Y~   (___)    |/    ~Y~
    \|   \ |/   \| /  \~Y~/   \|    \ |/
   \\|// \\|// \\|/// \\|//  \\|// \\\|///
jgs^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
");

// Initialisation du jardin
DateOnly date = new DateOnly(2025, 09, 25);
Jardin jardin = new Jardin();

PreparerPlantesJardinInitiales(jardin, date);


do
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Bienvenue dans le jardin Botanique ! Nous sommes le {date:d}. Choisir une option:");
    Console.WriteLine("1. Voir l'état des plantes du jardin.");
    Console.WriteLine("2. Voir les ressources disponibles du jardin.");
    Console.WriteLine("3. Planter une nouvelle plante.");
    Console.WriteLine("4. Entretenir le jardin.");
    Console.WriteLine("5. Passer un jour de tempête.");
    Console.WriteLine("6. Passer un jour de canicule.");
    Console.WriteLine("7. Nettoyer le jardin.");
    Console.WriteLine("8. Quitter l'application.");
    Console.ResetColor();
    Console.Write("Votre choix: ");
    try
    {
        choix = Console.ReadLine();
        switch (choix)
        {
            case "1":
                jardin.AfficherPlantes();
                break;
            case "2":
                jardin.AfficherRessources();
                break;
            case "3":
                try
                {
                    Plante planteChoisie = ChoisirPlante();
                    jardin.Planter(planteChoisie, date);
                }
                catch (RessourcesInsuffisantesException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                break;
            case "4":
                jardin.EntretenirPlantes(date);
                Console.WriteLine($"Journée terminée. À demain! ");
                date = date.AddDays(1);
                break;
            case "5":
                Console.WriteLine($"La tempête est terminée. Constatez les dégats de votre jardin! Demain est un nouveau jour, on fera le nettoyage après! ");
                break;
            case "6":
                Canicule episodeCanicule = new Canicule();
                episodeCanicule.Impacter(jardin);
                Console.WriteLine($"Encore un autre jour de canicule, les reserves d'eau s'épuisent! Demain, pensez à vérifier les ressources Demain!");
                date = date.AddDays(1);
                break;
            case "7":
                jardin.Nettoyer();
                Console.WriteLine("Plus de plantes mortes! Beau travail!");
                date = date.AddDays(1);
                break;
            default:
                Console.WriteLine("Entrer une option valide (1-7)");
                break;
        }
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
    }

} while (choix != "8");
Console.WriteLine("Au revoir !");