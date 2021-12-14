using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenerique
{
    public interface Nourriture
    {
        // Méthode renvoyant un bool disant si la nourriture est périmée ou non
        bool EstPerime();
    }
}
