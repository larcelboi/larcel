using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotanique.ContenuJardin
{
    public class Ressources
    {
        /// <summary>
        /// Quantité d'eau disponible
        /// </summary>
        public int Eau { get; set; }

        /// <summary>
        /// Quantité d'anglais disponible
        /// </summary>
        public int Engrais { get; set; }

        public Ressources(int eau, int engrais)
        {
            Eau = eau;
            Engrais = engrais;
        }

        /// <summary>
        /// Méthode qui permet d'arroser une plante et de déduire 
        /// la quantité d'eau des ressources disponibles du jardin.
        /// </summary>
        /// <param name="quantite">Quantité d'eau à utiliser</param>
        /// <returns></returns>
        public bool Arroser(int quantite)
        {
            if (Eau >= quantite)
            {
                Eau -= quantite;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Méthode qui permet d'ajouter des engrais à une plate et de déduire 
        /// la quantité d'engrais des ressources disponibles du jardin.
        /// </summary>
        /// <param name="quantite">Quantité d'engrais à utiliser</param>
        /// <returns></returns>
        public bool UtiliserEngrais(int quantite)
        {
            if (Engrais >= quantite)
            {
                Engrais -= quantite;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Eau: {Eau}, Engrais: {Engrais}";
        }
    }
}
