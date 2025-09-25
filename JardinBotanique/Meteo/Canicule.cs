using JardinBotanique.ContenuJardin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotanique.Meteo
{
    public class Canicule : Intemperie
    {
        public Canicule() : base("Canicule")
        {

        }

        /// <summary>
        /// Permet de simuler l'impact d'une canicule sur le jardin (déduire la ressource d'eau disponible).
        /// </summary>
        /// <param name="jardin"></param>
        public override void Impacter(Jardin jardin)
        {
            foreach (Plante plante in jardin.Plantes)
            {
                jardin.Ressources.Eau -= 5;
            }
        }
    }
}
