using JardinBotanique.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotanique.ContenuJardin
{
    public class Jardin
    {
        /// <summary>
        /// Les plantes plantées dans le jardin.
        /// </summary>
        public List<Plante> Plantes { get; } = new List<Plante>();

        /// <summary>
        /// Les ressources disponibles pour entretenir le jardin.
        /// </summary>
        public Ressources Ressources { get; set; }

        public Jardin()
        {
            Ressources = new Ressources(eau: 20, engrais: 20);
        }

        /// <summary>
        /// Plante une nouvelle plante dans le jardin à la date spécifiée s'il y a suffisemment d'eau et d'engrais.
        /// </summary>
        /// <param name="plante">La plante à planter.</param>
        /// <exception cref="RessourcesInsuffisantesException"></exception>
        public void Planter(Plante plante, DateOnly date = new DateOnly())
        {
            if (!Ressources.Arroser(plante.BesoinEauParJour))
            {
                throw new RessourcesInsuffisantesException("Pas assez d'eau pour planter la plante choisie.");
            }

            else if (!Ressources.UtiliserEngrais(1))
            {
                throw new RessourcesInsuffisantesException("Pas assez d'engrais pour planter la plante choisie.");
            }
            else
            {
                Plantes.Add(plante);
                Console.WriteLine($"\n{plante.Nom} a été planté!\n");
            }
               
        }

        /// <summary>
        /// Permet d'entretenir toutes les plantes du jardin pour la journée spécifiée.
        /// </summary>
        /// <param name="date">Date à laquelle les plantes ont été entretenues.</param>
        public void EntretenirPlantes(DateOnly date)
        {
            // TODO: voir documentation de la méthode.
            foreach (Plante plante in Plantes)
            {
                plante.Entretenir(Ressources, date);
            }
        }

        /// <summary>
        /// Permet d'enlever toutes les plantes mortes du jardin.
        /// </summary>
        public void Nettoyer()
        {
            int mortes = Plantes.RemoveAll(p => !p.EstVivante);
            Console.WriteLine($"Nettoyage terminé : {mortes} plante(s) morte(s) retirée(s).");
        }

        /// <summary>
        /// Permet d'afficher l'état des plantes du jardin.
        /// </summary>
        public void AfficherPlantes()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n=== Plantes du Jardin ===");

            foreach (Plante plante in Plantes)
            {
                sb.AppendLine(plante.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Permet d'afficher les ressources disponibles du jardin.
        /// </summary>
        public void AfficherRessources()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n=== Ressources du Jardin ===");
            sb.AppendLine($"Eau disponible   : {Ressources.Eau}");
            sb.AppendLine($"Engrais disponible : {Ressources.Engrais}");

            Console.WriteLine(sb.ToString());
        }
    }
}
