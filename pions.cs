using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu_Dames
{
    class pions
    {
        /// <summary>
        /// //Les Attributs
        /// </summary>
        static int id=0;
        int posx;
        int posy;
        char couleur;

        // Le constructeur1
        public pions(char couleur, int posx, int posy )
        {
            this.couleur = couleur;
            this.posx = posx;
            this.posy = posy;
            id++;
          
        }
    }
}
