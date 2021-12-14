using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenerique
{
    public static class Zoo
    {
        // On va nourir l'annimal(A) passé en param, quelqu'il soit avec la nourriture(N) approprié
        // Déduire les types génériques A et N dirrectement à partir des paramètres passés.
        public static bool NourrirAnimal<A,N>(A animal,N aliment) where N : Nourriture where A : Animal<N>
        {
            return animal.SeNourrir(aliment);
        }
    }
}
