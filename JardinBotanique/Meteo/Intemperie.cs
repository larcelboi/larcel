using JardinBotanique.ContenuJardin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotanique.Meteo
{
    public abstract class Intemperie
    {
        public string Nom { get; }
        public Intemperie(string nom)
        {
            Nom = nom;
        }

        public abstract void Impacter(Jardin jardin);
    }
}
