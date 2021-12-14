using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodeExtension
{
    public static class Extension
    {
        // Savoir si un entier est pair
        public static bool EstPair(this int entier)
        {
            return entier %2 == 0;
        }

        // Mettre le premier caractère en majuscule
        public static string PremiereLettreMaj(this string chaine)
        {
            // on prend le premier charactere, le passe en maj, le transforme en string
            // puis on prend toute la chaine, passe en min et la gardons a partir de l'index 1 (donc on enlève l'initiale)
            return char.ToUpper(chaine[0]).ToString()+chaine.ToLower().Substring(1);
        }
    }
}
