using JardinBotanique.ContenuJardin;
using JardinBotanique.Exceptions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JardinBotaniqueTests.ContenuJardinTests
{
    public class PlanteTests
    {
        [Fact]
        public void Entretenir_PlanteDejaMorte_NeFaitRien()
        {
            Ressources ressources = new Ressources(eau: 10, engrais: 5);
            DateOnly date = new DateOnly(2025, 9, 25);

            Plante plante = new Plante("Rose", TypePlante.Fleur, besoinEau: 2, frequenceEngrais: 2);
            plante.EstVivante = false;

            plante.Entretenir(ressources, date);

            Assert.False(plante.EstVivante);
            Assert.Equal(0, plante.Croissance);
        }

        [Fact]
        public void Entretenir_DepasseToleranceSansEau_PlanteMeurt()
        {

            Ressources ressources = new Ressources(eau: 0, engrais: 5);
            DateOnly date = new DateOnly(2025, 9, 25);

            Plante plante = new Plante("Rose", TypePlante.Fleur, besoinEau: 1, frequenceEngrais: 2);

            plante.Entretenir(ressources, date);
            plante.Entretenir(ressources, date.AddDays(1));

            Assert.False(plante.EstVivante);
        }

        [Fact]
        public void Entretenir_AvecEngraisDisponible_AugmenteCroissanceDe3()
        {
            Ressources ressources = new Ressources(eau: 10, engrais: 5);
            DateOnly date = new DateOnly(2025, 9, 25);

            Plante plante = new Plante("Lavande", TypePlante.Fleur, besoinEau: 2, frequenceEngrais: 1);

            plante.Entretenir(ressources, date);

            Assert.Equal(3, plante.Croissance);
        }
    }
}
