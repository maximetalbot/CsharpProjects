using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenerique
{
    // En fonction du type d'animal, le type de nouriture sera différent
    // T sera de type Nourriture
    public interface Animal<T> where T : Nourriture
    {
        bool SeNourrir(T aliment);
    }
}
