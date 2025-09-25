using JardinBotanique.ContenuJardin;
using JardinBotanique.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotaniqueTests.ContenuJardinTests
{
    public class JardinTests
    {

        [Fact]
        public void Planter_ManqueDEau_DeclencheException()
        {
            Jardin jardin = new Jardin();
            jardin.Ressources = new Ressources(eau: 0, engrais: 5);
            Plante cactus = new Plante("Cactus", TypePlante.Cactus, besoinEau: 1, frequenceEngrais: 1);

            RessourcesInsuffisantesException exception = Assert.Throws<RessourcesInsuffisantesException>(() =>
                jardin.Planter(cactus, new DateOnly(2025, 1, 1)));

            Assert.Equal("Pas assez d'eau pour planter la plante choisie.", exception.Message);
            Assert.Empty(jardin.Plantes);
        }

        [Fact]
        public void Planter_ManqueEngrais_DeclencheException()
        {
            Jardin jardin = new Jardin();
            jardin.Ressources = new Ressources(eau: 10, engrais: 0);
            Plante tulipe = new Plante("Tulipe", TypePlante.Fleur, besoinEau: 2, frequenceEngrais: 1);

            RessourcesInsuffisantesException exception = Assert.Throws<RessourcesInsuffisantesException>(() =>
                jardin.Planter(tulipe, new DateOnly(2025, 1, 1)));

            Assert.Equal("Pas assez d'engrais pour planter la plante choisie.", exception.Message);
            Assert.Empty(jardin.Plantes);
        }

        [Fact]
        public void Planter_AvecRessourcesSuffisantes_AjoutePlanteDansLeJardin()
        {
            Jardin jardin = new Jardin();
            jardin.Ressources = new Ressources(eau: 10, engrais: 5);
            Plante rosier = new Plante("Rose", TypePlante.Fleur, besoinEau: 2, frequenceEngrais: 1);

            // TODO: Suppprimer la ligne suivante et compléter le test unitaire.
            Assert.Fail();
        }

        [Fact]
        public void Planter_AvecRessourcesSuffisantes_DiminueQuantiteEauEtEngrais()
        {
            Jardin jardin = new Jardin();
            jardin.Ressources = new Ressources(eau: 10, engrais: 5);
            Plante herbe = new Plante("Menthe", TypePlante.Herbe, besoinEau: 3, frequenceEngrais: 1);

            // TODO: Suppprimer la ligne suivante et compléter le test unitaire.
            Assert.Fail();
        }

        [Fact]
        public void EntretenirPlantes_UnePlanteEauSuffisante_PlanteToujoursVivante()
        {
            Jardin jardin = new Jardin();
            jardin.Ressources = new Ressources(eau: 5, engrais: 2);
            Plante basilic = new Plante("Basilic", TypePlante.Herbe, besoinEau: 2, frequenceEngrais: 2);

            jardin.Plantes.Add(basilic);

            jardin.EntretenirPlantes(new DateOnly(2025, 1, 1));

            Assert.True(basilic.EstVivante);
        }

        [Fact]
        public void EntretenirPlantes_UnePlanteSansEau_PlantePeutMourir()
        {
            Jardin jardin = new Jardin();
            jardin.Ressources = new Ressources(eau: 0, engrais: 2);
            Plante rose = new Plante("Rose", TypePlante.Fleur, besoinEau: 2, frequenceEngrais: 1);
            jardin.Plantes.Add(rose);

            jardin.EntretenirPlantes(new DateOnly(2025, 1, 1));
            jardin.EntretenirPlantes(new DateOnly(2025, 1, 2));

            Assert.False(rose.EstVivante);
        }

        [Fact]
        public void EntretenirPlantes_EpuiseLesRessourcesDuJardin()
        {
            Jardin jardin = new Jardin();
            jardin.Ressources = new Ressources(eau: 5, engrais: 2);

            Plante plante1 = new Plante("Menthe", TypePlante.Herbe, besoinEau: 3, frequenceEngrais: 1);
            Plante plante2 = new Plante("Lavande", TypePlante.Fleur, besoinEau: 2, frequenceEngrais: 1);

            jardin.Plantes.Add(plante1);
            jardin.Plantes.Add(plante2);

            jardin.EntretenirPlantes(new DateOnly(2025, 1, 1));

            Assert.Equal(0, jardin.Ressources.Eau);
            Assert.Equal(0, jardin.Ressources.Engrais);
        }
    }
}
