using JardinBotanique.ContenuJardin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotanique.Meteo
{
    public class Tempete : Intemperie
    {
        public Tempete() : base("Tempête") { }

        /// <summary>
        /// Permet de simuler l'impact d'une tempête sur les plantes d'un jardin (déduire la ressource d'eau disponible).
        /// </summary>
        /// <param name="jardin"></param>
        public override void Impacter(Jardin jardin)
        {
            Random rnd = new Random();

            int nombreAImpacter = jardin.Plantes.Count / 2;

            // Mélange aléatoire des plantes et prend les premières "nombreAImpacter"
            List<Plante> plantesMelangees = jardin.Plantes.OrderBy(p => rnd.Next()).Take(nombreAImpacter).ToList();

            foreach (Plante plante in plantesMelangees)
            {
                plante.EstVivante = false;
            }
            
        }
    }
}
