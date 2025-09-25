using JardinBotanique.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotanique.ContenuJardin
{
    public class Plante
    {
        public string Nom { get; }

        public TypePlante Type { get; }
        public bool EstVivante { get; set; } = true;

        /// <summary>
        /// Quantité d'eau dont la plante a besoin à l'arrosage (pas d'unité spécifique).
        /// </summary>
        public int BesoinEauParJour { get; }

        /// <summary>
        /// Nombre de jours pendant lesquels la plante peut survivre sans eau.
        /// </summary>
        public int ToleranceSansEau { get; }

        private int joursSansEau = 0;

        /// <summary>
        /// Fréquence, en nombre de jours, à laquelle la plante peut recevoir de l'engrais pour bien pousser.
        /// </summary>
        public int FrequenceEngrais { get; }

        private DateOnly dateDernierEngrais;

        /// <summary>
        /// Simule la croissance de la plante.
        /// </summary>
        public int Croissance { get; private set; } = 0;

        public Plante(string nom, TypePlante type, int besoinEau, int frequenceEngrais)
        {
            Nom = nom;
            Type = type;
            BesoinEauParJour = besoinEau;
            FrequenceEngrais = frequenceEngrais;


            ToleranceSansEau = type switch
            {
                TypePlante.Cactus => 10,
                TypePlante.Fleur => 2,
                TypePlante.Herbe => 3,
                TypePlante.Arbre => 5,
                _ => 3
            };
        }

        /// <summary>
        /// Entretiens la plante pour la journée spécifiée.
        /// Arrose la plante selon ses besoins en eau et suit le nombre de jours sans eau.
        /// La plante meurt si sa tolérance sans eau est dépassée.
        /// Fait croître la plante si l'arrosage a été effectué.
        /// Applique de l'engrais lorsque nécessaire, selon la fréquence définie,
        /// et fait croître la plante si l'arrosage et l'engrais ont été fournis.
        /// </summary>
        /// <param name="ressources"></param>
        /// <param name="date"></param>
        /// <exception cref="RessourcesInsuffisantesException"></exception>
        public void Entretenir(Ressources ressources, DateOnly date)
        {
            if (!EstVivante) return;

            // TODO: Comopléter selon la documentation de la méthode.

            TimeSpan nbJoursDepuisDernierEngrais = date.ToDateTime(TimeOnly.MinValue) - dateDernierEngrais.ToDateTime(TimeOnly.MinValue);

            if (nbJoursDepuisDernierEngrais.TotalDays >= FrequenceEngrais)
            {
                if (ressources.UtiliserEngrais(1))
                {
                    Croissance += 2;
                    dateDernierEngrais = date;
                }
                else
                {
                    throw new RessourcesInsuffisantesException("Pas assez d'engrais pour planter une nouvelle plante.");
                }
            }
        }

        public override string ToString()
        {
            return $"Nom: {Nom} | " +
                   $"Type: {(Type == TypePlante.Autre ? "Espèce inconnue" : Type)} | " +
                   $"État: {(EstVivante ? "Vivante" : "Morte")} | " +
                   $"Eau/jour: {BesoinEauParJour} | " +
                   $"Résistance: {ToleranceSansEau} jours | " +
                   $"Engrais: aux {FrequenceEngrais} jours";
        }
    }
}
