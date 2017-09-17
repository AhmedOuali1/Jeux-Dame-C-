using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Jeu_Dames
{
    public class Grille :Form1
    {
        public static int x(System.Windows.Forms.PictureBox picbox)
        {
            if(picbox!=null)
            return ((picbox.Location.X+24) - 85) / 95;
            return 0;

        }
        public static int y(System.Windows.Forms.PictureBox picbox)
        {
            if(picbox!=null)
            return ((picbox.Location.Y+24) - 48) / 48;
            return 0;

        }
        public static System.Windows.Forms.PictureBox recherchepionXYB(int X, int Y, System.Windows.Forms.PictureBox[] bbox)
        {
            for (int i = 1; i <= 15; i++)
            {
                if ((X == Grille.x(bbox[i])) && (Y == Grille.y(bbox[i])))
                {
                    
                    return bbox[i];
                }
            }
            return null;
        }

        public static System.Windows.Forms.PictureBox recherchepionXYW(int X, int Y, System.Windows.Forms.PictureBox[] wbox)
        {
            for (int i = 1; i <= 15; i++)
            {
                if ((X == Grille.x(wbox[i])) && (Y == Grille.y(wbox[i])))
                    return wbox[i];
            }
            return null;
        }

        public static int[,] paspossiblesB(System.Windows.Forms.PictureBox picbox,System.Windows.Forms.PictureBox[] bbox,System.Windows.Forms.PictureBox[] wbox)
        {
            int[,] tab = new int[2, 2];
            tab[0,0]=-1;
            tab[0,1]=-1;
            tab[1,0]=-1;
            tab[1,1]=-1;
            int x = Grille.x(picbox);
            int y = Grille.y(picbox);
            //MessageBox.Show("" +x);
            //MessageBox.Show("" + y);

            Boolean b1, b2, b3, b4, b5;
            b1 = ((recherchepionXYB(x, y + 1, bbox) != null) || (recherchepionXYW(x, y + 1, wbox) != null));
            b2 = ((recherchepionXYB(x + 1, y + 2, bbox) != null) || (recherchepionXYW(x + 1, y + 2, wbox) != null));
            b3 = ((recherchepionXYB(x, y - 1, bbox) != null) || (recherchepionXYW(x, y - 1, wbox) != null));
            b4 = ((recherchepionXYB(x, y - 1, bbox) == null) && (recherchepionXYW(x, y - 1, wbox) == null));
            b5 = ((recherchepionXYB(x, y + 1, bbox) == null) && (recherchepionXYW(x, y + 1, wbox) == null));

           
           
                switch (y)
                {
                    case 0:
                        if (((recherchepionXYB(x + 1, y + 1, bbox) != null) ||((recherchepionXYW(x + 1, y + 1, wbox) != null)))&&((recherchepionXYB(x + 1, y + 2, bbox) != null)||(recherchepionXYW(x + 1, y + 2, wbox) != null)))  //les cas ou il n'y aa pas de deplacement
                        {
                           // MessageBox.Show("this");
                            return null;}
                        if(recherchepionXYB(x + 1, y + 1, bbox) != null)
                             {
                           // MessageBox.Show("this");
                            return null;}
                        if ((recherchepionXYW(x + 1, y + 1, wbox) != null) && (recherchepionXYB(x + 1, y + 2, bbox) == null) && (recherchepionXYW(x + 1, y + 2, wbox) == null))     //le cas ou il y a saut  
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y + 2;
                            return tab;
                        }
                        if ((recherchepionXYB(x + 1, y + 1, bbox) == null) && (recherchepionXYW(x + 1, y + 1, wbox) == null)) //cas ou il y a saut
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y + 1;
                            return tab;
                        }


                        break;
                    case 1:

                        if ((recherchepionXYB(x, y + 1, bbox) != null) && ((recherchepionXYB(x, y - 1, bbox) != null)||(recherchepionXYW(x, y + 1, wbox) != null))) //pas de deplacement cas 1
                        {
                           // MessageBox.Show("this");
                            return null;
                        }
                        if (((recherchepionXYB(x, y - 1, bbox) != null) || (recherchepionXYW(x, y - 1, wbox) != null)) && (recherchepionXYW(x, y + 1, wbox) != null) && ((recherchepionXYB(x+1, y + 2, bbox) != null) || (recherchepionXYW(x+1, y + 2, wbox) != null)))   //pas de deplacement cas 1
                        {
                            //MessageBox.Show("this");
                            return null;
                        }
                        if ((recherchepionXYW(x, y + 1, wbox) != null) && (recherchepionXYW(x + 1, y + 2, wbox) == null) && (recherchepionXYB(x + 1, y + 2, bbox) == null))  //saut 
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y + 2;
                           //  MessageBox.Show("" + x);
                            return tab;
                        }
                        if ((recherchepionXYW(x, y + 1, wbox) == null) && (recherchepionXYB(x, y + 1, bbox) == null) && b4) //mvt 1
                        {

                            tab[0, 0] = x;
                            tab[0, 1] = y + 1;
                            tab[1, 0] = x;
                            tab[1, 1] = y - 1;
                           // MessageBox.Show("" + x);
                            return tab;
                        }
                        if ((recherchepionXYW(x, y - 1, wbox) == null) && (recherchepionXYB(x, y - 1, bbox) == null))   // mvt cas 2
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y - 1;
                           // MessageBox.Show("" + x);
                            return tab;
                            
                        }
                        if ((recherchepionXYW(x, y + 1, wbox) == null) && (recherchepionXYB(x, y + 1, bbox) == null))
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y + 1;
                           // MessageBox.Show("" + x);
                            return tab;

                        }

                        break;
                    case 8:
                        //pas de mvt 
                        if ((recherchepionXYB(x + 1, y - 1, bbox) != null) && (recherchepionXYB(x + 1, y + 1, bbox) != null))
                        {
                            return null;
                        }
                        if (((recherchepionXYB(x + 1, y + 1, bbox) != null)||(recherchepionXYW(x + 1, y + 1, wbox) != null))&&((recherchepionXYW(x + 1, y - 1, wbox) != null)||(recherchepionXYB(x + 1, y - 1, bbox) != null))&&((recherchepionXYB(x + 1, y - 2, bbox) != null)||(recherchepionXYW(x + 1, y - 2, wbox) != null)))
                        {
                            return null;
                        }
                        //saut 
                        if ((recherchepionXYW(x + 1, y - 1, wbox) != null) && (recherchepionXYW(x + 1, y - 2, wbox) == null) && (recherchepionXYB(x + 1, y - 2, bbox) == null))
                        {
                            tab[0, 0] = x+1;
                            tab[0, 1] = y + 2;
                            return tab;
 
                        }
                        //mvt
                        if (((recherchepionXYW(x + 1, y + 1, wbox) == null) && (recherchepionXYB(x + 1, y + 1, bbox) == null)) && ((recherchepionXYW(x + 1, y - 1, wbox) == null) && (recherchepionXYB(x + 1, y - 1, bbox) == null)))
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y + 1;
                            tab[1, 0] = x + 1;
                            tab[1, 1] = y - 1;
                            return tab;                            

                        }
                        if ((recherchepionXYW(x + 1, y + 1, wbox) == null) && (recherchepionXYB(x + 1, y + 1, bbox) == null))
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y + 1;
                            return tab;
                        }
                        if ((recherchepionXYW(x + 1, y - 1, wbox) == null) && (recherchepionXYB(x + 1, y - 1, bbox) == null))
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y - 1;
                            return tab;
                        }



                        break;


                    case 9:
                        // pas de mvt 
                        if (recherchepionXYB(x , y - 1, bbox) != null)
                        {
                            // MessageBox.Show("this");
                            return null;
                        }
                        if ((recherchepionXYW(x, y - 1, wbox) != null) && ((recherchepionXYW(x + 1, y - 2, wbox) != null) || (recherchepionXYB(x + 1, y - 2, bbox)!=null)))
                        {
                            return null;
                        }
                        // saut 
                        if((x<4)&&(recherchepionXYW(x, y - 1, wbox) != null)&&(recherchepionXYW(x + 1, y - 2, wbox) == null)&&(recherchepionXYB(x + 1, y - 2, bbox) == null))
                        {
                            tab[0, 0] = x+1;
                            tab[0, 1] = y - 2;
                            return tab;
                        }
                        // mvt
                        if ((recherchepionXYB(x, y - 1, bbox) == null) && (recherchepionXYW(x, y - 1, wbox) == null))
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y-1;
                            return tab;
                        }

                        break;


                    default:
                        // cas de y pair
                        if ((y == 2) || (y == 4) || (y == 6))
                        {
                            // pas de deplacement
                            if ((recherchepionXYB(x + 1, y - 1, bbox) != null) && (recherchepionXYB(x + 1, y + 1, bbox) != null)) // pas de deplacement 1 cas 
                                return null;
                           // if ((x == 3) && ((recherchepionXYB(x + 1, y - 1, bbox) != null) || (recherchepionXYW(x + 1, y - 1, wbox) != null)) && ((recherchepionXYB(x + 1, y + 1, bbox) != null) || (recherchepionXYW(x + 1, y + 1, wbox) != null))) // pas de deplacement 2 cas
                           //     return null;  // cas impaire
                            if ((recherchepionXYB(x + 1, y - 1, bbox) != null) && (recherchepionXYW(x + 1, y + 1, wbox) != null) && ((recherchepionXYB(x + 1, y + 2, bbox) != null) || (recherchepionXYW(x + 1, y + 2, wbox) != null))) // pas de deplacement 3 cas
                            {
                                //MessageBox.Show("  ");
                                return null;
                            }
                            if ((recherchepionXYW(x + 1, y - 1, wbox) != null) && (recherchepionXYB(x + 1, y + 1, bbox) != null) && ((recherchepionXYB(x + 1, y - 2, bbox) != null) || (recherchepionXYW(x + 1, y - 2, wbox) != null)))   // pas de deplacement 4 cas
                            {
                               // MessageBox.Show("  ");
                                return null;
                            }
                            if ((recherchepionXYW(x + 1, y - 1, wbox) != null) && (recherchepionXYW(x + 1, y + 1, wbox) != null) && ((recherchepionXYB(x + 1, y - 2, bbox) != null) || (recherchepionXYW(x + 1, y - 2, wbox) != null)) && ((recherchepionXYB(x + 1, y + 2, bbox) != null) || (recherchepionXYW(x + 1, y + 2, wbox) != null)))  //pas de deplacement cas 4
                            {
                                //MessageBox.Show("  ");
                                return null;
                            }
                            // sauts
                            if ((recherchepionXYW(x + 1, y - 1, wbox) != null) && (recherchepionXYB(x + 1, y - 2, bbox) == null) && (recherchepionXYW(x + 1, y - 2, wbox) == null))  // premiere cas du saut 
                            {
                                tab[0, 0] = x+1;
                                tab[0, 1] = y - 2;
                                //MessageBox.Show("this");
                                return tab;
                            }
                            if ((recherchepionXYW(x + 1, y + 1, wbox) != null) && (recherchepionXYB(x + 1, y + 2, bbox) == null) && (recherchepionXYW(x + 1, y + 2, wbox) == null)) // deuxieme cas du saut
                            {
                                tab[0, 0] = x + 1;
                                tab[0, 1] = y + 2;
                                //MessageBox.Show("this");
                                return tab;
                            }
                            // mvt
                            if (((recherchepionXYB(x + 1, y - 1, bbox) == null) && (recherchepionXYW(x + 1, y - 1, wbox) == null)) && ((recherchepionXYB(x + 1, y + 1, bbox) != null) || (recherchepionXYW(x + 1, y + 1, wbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x + 1;
                                tab[0, 1] = y - 1;
                                //MessageBox.Show("this");
                                return tab;
                            }
                            if (((recherchepionXYB(x + 1, y + 1, bbox) == null) && (recherchepionXYW(x + 1, y + 1, wbox) == null)) && ((recherchepionXYB(x + 1, y - 1, bbox) != null) || (recherchepionXYW(x + 1, y - 1, wbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x + 1;
                                tab[0, 1] = y + 1;
                                //MessageBox.Show("this");
                                return tab;
                            }
                            if(((recherchepionXYB(x + 1, y + 1, bbox) == null) && (recherchepionXYW(x + 1, y + 1, wbox) == null))&&((recherchepionXYB(x + 1, y - 1, bbox) == null) && (recherchepionXYW(x + 1, y - 1, wbox) == null)))
                            {
                                tab[0, 0] = x + 1;
                                tab[0, 1] = y + 1;
                                tab[1, 0] = x + 1;
                                tab[1, 1] = y - 1;
                               // MessageBox.Show("this"); 
                                return tab;
                            } 
                              
                        }
                        // y impair 
                        if ((y == 3) || (y == 5) || (y == 7))
                            {
                            // pas de deplacement
                            if ((recherchepionXYB(x , y - 1, bbox) != null) && (recherchepionXYB(x , y + 1, bbox) != null)) // pas de deplacement 1 cas
                                return null;
                            if ((x == 4) && ((recherchepionXYB(x , y - 1, bbox) != null) || (recherchepionXYW(x , y - 1, wbox) != null)) && ((recherchepionXYB(x , y + 1, bbox) != null) || (recherchepionXYW(x , y + 1, wbox) != null))) // pas de deplacement 2 cas
                                return null; 
                            if (x<4)
                            {
                                if ((recherchepionXYB(x , y - 1, bbox) != null) && (recherchepionXYW(x , y + 1, wbox) != null) && ((recherchepionXYB(x + 1, y + 2, bbox) != null) || (recherchepionXYW(x + 1, y + 2, wbox) != null))) // pas de deplacement 3 cas
                                {
                                return null;
                                }
                                if ((recherchepionXYW(x , y - 1, wbox) != null) && (recherchepionXYB(x, y + 1, bbox) != null) && ((recherchepionXYB(x + 1, y - 2, bbox) != null) || (recherchepionXYW(x + 1, y - 2, wbox) != null)))   // pas de deplacement 4 cas
                                {
                                return null;
                                }
                                if ((recherchepionXYW(x , y - 1, wbox) != null) && (recherchepionXYW(x , y + 1, wbox) != null) && ((recherchepionXYB(x + 1, y - 2, bbox) != null) || (recherchepionXYW(x + 1, y - 2, wbox) != null)) && ((recherchepionXYB(x + 1, y + 2, bbox) != null) || (recherchepionXYW(x + 1, y + 2, wbox) != null)))  //pas de deplacement cas 4
                                {
                                return null;
                                }
                            

                            }
                            //saut
                            if (x <4)
                            {
                                if ((recherchepionXYW(x , y - 1, wbox) != null) && (recherchepionXYB(x + 1, y - 2, bbox) == null) && (recherchepionXYW(x + 1, y - 2, wbox) == null))  // premiere cas du saut 
                                {
                                    tab[0, 0] = x + 1;
                                    tab[0, 1] = y - 2;
                                    return tab;
                                }
                                if ((recherchepionXYW(x , y + 1, wbox) != null) && (recherchepionXYB(x + 1, y + 2, bbox) == null) && (recherchepionXYW(x + 1, y + 2, wbox) == null)) // deuxieme cas du saut
                                {
                                    tab[0, 0] = x + 1;
                                    tab[0, 1] = y + 2;
                                    return tab;
                                }
                            }
                            // mvt 
                            if (((recherchepionXYB(x, y + 1, bbox) == null) && (recherchepionXYW(x, y + 1, wbox) == null)) && ((recherchepionXYB(x, y - 1, bbox) == null) && (recherchepionXYW(x, y - 1, wbox) == null)))
                            {
                                tab[0, 0] = x;
                                tab[0, 1] = y + 1;
                                tab[1, 0] = x;
                                tab[1, 1] = y - 1;
                               // MessageBox.Show("debug");
                                return tab;
                            } 
                            if (((recherchepionXYB(x, y - 1, bbox) == null) && (recherchepionXYW(x, y - 1, wbox) == null)) && ((recherchepionXYB(x, y + 1, bbox) != null) || (recherchepionXYW(x , y + 1, wbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x ;
                                tab[0, 1] = y - 1;
                                return tab;
                            }
                            if (((recherchepionXYB(x, y + 1, bbox) == null) && (recherchepionXYW(x , y + 1, wbox) == null)) && ((recherchepionXYB(x, y - 1, bbox) != null) || (recherchepionXYW(x , y - 1, wbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x ;
                                tab[0, 1] = y + 1;
                                //MessageBox.Show("debug");
                                return tab;
                                
                            }
                           

                       }
                        
                        break;

                }

            
            //MessageBox.Show("this");
            return null;

        }
        public static int[,] paspossiblesW(System.Windows.Forms.PictureBox picbox, System.Windows.Forms.PictureBox[] bbox, System.Windows.Forms.PictureBox[] wbox)
        {
            int[,] tab = new int[2, 2];
            tab[0, 0] = -1;
            tab[0, 1] = -1;
            tab[1, 0] = -1;
            tab[1, 1] = -1;
            int x = Grille.x(picbox);
            int y = Grille.y(picbox);
            //MessageBox.Show("" +x);
            //MessageBox.Show("" + y);

            Boolean b1, b2, b3, b4, b5;
            b1 = ((recherchepionXYW(x, y + 1, bbox) != null) || (recherchepionXYB(x, y + 1, bbox) != null));
            b2 = ((recherchepionXYW(x - 1, y + 2, wbox) != null) || (recherchepionXYB(x - 1, y + 2, bbox) != null));
            b3 = ((recherchepionXYW(x, y - 1, wbox) != null) || (recherchepionXYB(x, y - 1, bbox) != null));
            b4 = ((recherchepionXYW(x, y - 1, wbox) == null) && (recherchepionXYB(x, y - 1, bbox) == null));
            b5 = ((recherchepionXYW(x, y + 1, wbox) == null) && (recherchepionXYB(x, y + 1, bbox) == null));


            
                switch (y)
                {
                    case 0:
                        if (recherchepionXYW(x , y + 1, wbox) != null)
                        {
                             //MessageBox.Show("this");
                            return null;
                        }
                        if (((recherchepionXYW(x , y + 1, wbox) != null) || ((recherchepionXYB(x , y + 1, bbox) != null))) && ((recherchepionXYW(x , y + 2, wbox) != null) || (recherchepionXYB(x, y + 2, bbox) != null)))  //les cas ou il n'y aa pas de deplacement
                        {
                             //MessageBox.Show("this");
                            return null;
                        }
                        
                        if ((recherchepionXYB(x , y + 1, bbox) != null) && (recherchepionXYW(x, y + 2, wbox) == null) && (recherchepionXYB(x , y + 2,  bbox) == null))     //le cas ou il y a saut  
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y + 2;
                            return tab;
                        }
                        if ((recherchepionXYB(x, y + 1, bbox) == null) && (recherchepionXYW(x, y + 1, wbox) == null))
                        {
                            tab[0, 0] = x ;
                            tab[0, 1] = y +1;
                            return tab;
                        }
                        

                        break;
                    case 1:

                        if ((recherchepionXYW(x-1, y + 1, wbox) != null) && ((recherchepionXYW(x-1, y - 1, wbox) != null)||(recherchepionXYB(x-1, y - 1, bbox) != null))) //pas de deplacement cas 1
                        {
                            // MessageBox.Show("this");
                            return null;
                        }
                        if (((recherchepionXYW(x-1, y - 1, wbox) != null) || (recherchepionXYB(x-1, y - 1, bbox) != null)) && ((recherchepionXYW(x-1, y + 1, wbox) != null) || (recherchepionXYB(x-1, y + 1, bbox) != null)) && ((recherchepionXYW(x-1, y +2, wbox) != null) || (recherchepionXYB(x-1, y +2, bbox) != null)))   //pas de deplacement cas 1
                        {
                            //MessageBox.Show("this");
                            return null;
                        }
                        if ((recherchepionXYB(x - 1, y + 1, bbox) != null) && (recherchepionXYB(x - 1, y + 2, bbox) == null)&&(recherchepionXYW(x - 1, y + 2, wbox) == null))  //saut 
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y + 2;
                             //MessageBox.Show("" + x);
                            return tab;
                        }
                        if ((recherchepionXYB(x - 1, y + 1, bbox) == null) && (recherchepionXYW(x - 1, y + 1, wbox) == null) && (recherchepionXYB(x - 1, y - 1, bbox) == null) && (recherchepionXYW(x - 1, y - 1, wbox) == null)) //mvt 1
                        {

                            tab[0, 0] = x-1;
                            tab[0, 1] = y + 1;
                            tab[1, 0] = x-1;
                            tab[1, 1] = y - 1;
                            //MessageBox.Show("" + tab[0, 0] + " " + tab[0, 1] + " " + tab[1, 0] + " " + tab[1, 1]);
                            return tab;
                        }
                        if ((recherchepionXYB(x - 1, y - 1, bbox) == null) && (recherchepionXYW(x - 1, y - 1, wbox) == null))   // mvt cas 2
                        {
                            tab[0, 0] = x-1;
                            tab[0, 1] = y - 1;
                            //MessageBox.Show("" + x);
                            return tab;
                        }
                        if ((recherchepionXYB(x - 1, y + 1, bbox) == null) && (recherchepionXYW(x - 1, y + 1, wbox) == null))
                        {
                            tab[0, 0] = x-1;
                            tab[0, 1] = y + 1;
                           // MessageBox.Show("" + x);
                            return tab;
                        }

                        break;
                    case 8:
                        //pas de mvt 
                        if ((recherchepionXYW(x , y - 1, wbox) != null) && (recherchepionXYW(x , y + 1, wbox) != null))
                        {
                            return null;
                        }
                        if (((recherchepionXYW(x , y + 1, wbox) != null) || (recherchepionXYB(x , y + 1, bbox) != null)) && ((recherchepionXYB(x , y - 1, bbox) != null) || (recherchepionXYW(x - 1, y - 1, wbox) != null)) && ((recherchepionXYW(x - 1, y - 2, wbox) != null) || (recherchepionXYB(x - 1, y - 2, bbox) != null)))
                        {
                            return null;
                        }
                        //saut 
                        if ((x>0)&&(recherchepionXYB(x , y + 1, bbox) != null) && (recherchepionXYB(x - 1, y + 2, bbox) == null) && (recherchepionXYW(x - 1, y + 2, wbox) == null))
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y + 2;
                            return tab;

                        }
                        //mvt
                        if (((recherchepionXYB(x , y + 1, bbox) == null) && (recherchepionXYW(x , y + 1, wbox) == null)) && ((recherchepionXYB(x , y - 1, bbox) == null) && (recherchepionXYW(x , y - 1, wbox) == null)))
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y + 1;
                            tab[1, 0] = x;
                            tab[1, 1] = y -1;
                            return tab;

                        }
                        if ((recherchepionXYB(x , y + 1, bbox) == null) && (recherchepionXYW(x , y + 1, wbox) == null))
                        {
                            tab[0, 0] = x ;
                            tab[0, 1] = y + 1;
                            return tab;
                        }
                        if ((recherchepionXYB(x , y - 1, bbox) == null) && (recherchepionXYW(x , y - 1, wbox) == null))
                        {
                            tab[0, 0] = x ;
                            tab[0, 1] = y - 1;
                            return tab;
                        }



                        break;


                    case 9:
                        // pas de mvt 
                        if (recherchepionXYW(x-1, y - 1, wbox) != null)
                        {
                            // MessageBox.Show("this");
                            return null;
                        }
                        if ((recherchepionXYB(x-1, y - 1, bbox) != null) && ((recherchepionXYB(x - 1, y - 2, bbox) != null) || (recherchepionXYW(x - 1, y - 2, wbox) != null)))
                        {
                            return null;
                        }
                        // saut 
                        if ((recherchepionXYB(x-1, y - 1, bbox) != null) && (recherchepionXYB(x - 1, y - 2, bbox) == null) && (recherchepionXYW(x - 1, y - 2, wbox) == null))
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y - 2;
                            return tab;
                        }
                        // mvt
                        if ((recherchepionXYW(x-1, y - 1, wbox) == null) && (recherchepionXYB(x-1, y - 1, bbox) == null))
                        {
                            tab[0, 0] = x-1;
                            tab[0, 1] = y - 1;
                            return tab;
                        }

                        break;


                    default:
                        // cas de y pair
                        if ((y == 3) || (y == 5) || (y == 7))
                        {
                            // pas de deplacement
                            if ((recherchepionXYW(x - 1, y - 1, wbox) != null) && (recherchepionXYW(x - 1, y + 1, wbox) != null)) // pas de deplacement 1 cas
                                return null;
                            // if ((x == 3) && ((recherchepionXYB(x + 1, y - 1, bbox) != null) || (recherchepionXYW(x + 1, y - 1, wbox) != null)) && ((recherchepionXYB(x + 1, y + 1, bbox) != null) || (recherchepionXYW(x + 1, y + 1, wbox) != null))) // pas de deplacement 2 cas
                            //     return null;  // cas impaire
                            if ((recherchepionXYW(x - 1, y - 1, wbox) != null) && (recherchepionXYB(x - 1, y + 1, bbox) != null) && ((recherchepionXYW(x - 1, y + 2, wbox) != null) || (recherchepionXYB(x - 1, y + 2, bbox) != null))) // pas de deplacement 3 cas
                            {
                                return null;
                            }
                            if ((recherchepionXYB(x - 1, y - 1, bbox) != null) && (recherchepionXYW(x - 1, y + 1, wbox) != null) && ((recherchepionXYW(x - 1, y - 2, wbox) != null) || (recherchepionXYB(x - 1, y - 2, bbox) != null)))   // pas de deplacement 4 cas
                            {
                                return null;
                            }
                            if ((recherchepionXYB(x - 1, y - 1, bbox) != null) && (recherchepionXYB(x - 1, y + 1, bbox) != null) && ((recherchepionXYW(x - 1, y - 2, wbox) != null) || (recherchepionXYB(x - 1, y - 2, bbox) != null)) && ((recherchepionXYW(x - 1, y + 2, wbox) != null) || (recherchepionXYB(x - 1, y + 2, bbox) != null)))  //pas de deplacement cas 4
                            {
                                return null;
                            }
                            // sauts
                            if ((recherchepionXYB(x - 1, y - 1, bbox) != null) && (recherchepionXYW(x - 1, y - 2, wbox) == null) && (recherchepionXYB(x - 1, y - 2, bbox) == null))  // premiere cas du saut 
                            {
                                tab[0, 0] = x - 1;
                                tab[0, 1] = y - 2;
                                return tab;
                            }
                            if ((recherchepionXYB(x - 1, y + 1, bbox) != null) && (recherchepionXYW(x - 1, y + 2, wbox) == null) && (recherchepionXYB(x - 1, y + 2, bbox) == null)) // deuxieme cas du saut
                            {
                                tab[0, 0] = x - 1;
                                tab[0, 1] = y + 2;
                                return tab;
                            }
                            // mvt
                            if (((recherchepionXYW(x - 1, y - 1, wbox) == null) && (recherchepionXYB(x - 1, y - 1, bbox) == null)) && ((recherchepionXYW(x - 1, y + 1, wbox) != null) || (recherchepionXYB(x - 1, y + 1, bbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x - 1;
                                tab[0, 1] = y - 1;
                                return tab;
                            }
                            if (((recherchepionXYW(x - 1, y + 1, wbox) == null) && (recherchepionXYB(x - 1, y + 1, bbox) == null)) && ((recherchepionXYW(x - 1, y - 1, wbox) != null) || (recherchepionXYB(x - 1, y - 1, bbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x - 1;
                                tab[0, 1] = y + 1;
                                return tab;
                            }
                            if (((recherchepionXYW(x - 1, y + 1, wbox) == null) && (recherchepionXYB(x - 1, y + 1, bbox) == null)) && ((recherchepionXYW(x - 1, y - 1, wbox) == null) && (recherchepionXYB(x - 1, y - 1, bbox) == null)))
                            {
                                tab[0, 0] = x - 1;
                                tab[0, 1] = y + 1;
                                tab[1, 0] = x - 1;
                                tab[1, 1] = y - 1;
                                return tab;
                            }

                        }
                        // y impair
                        
                        if  ((y == 2) || (y == 4) || (y == 6))
                        {
                            // pas de deplacement
                            if ((recherchepionXYW(x, y - 1, wbox) != null) && (recherchepionXYW(x, y + 1, wbox) != null)) // pas de deplacement 1 cas
                                return null;
                            if ((x == 0) && ((recherchepionXYW(x, y - 1, wbox) != null) || (recherchepionXYB(x, y - 1, bbox) != null)) && ((recherchepionXYW(x, y + 1, wbox) != null) || (recherchepionXYB(x, y + 1, bbox) != null))) // pas de deplacement 2 cas
                                return null;
                            if (x > 0)
                            {
                                if ((recherchepionXYW(x, y - 1, wbox) != null) && (recherchepionXYB(x, y + 1, bbox) != null) && ((recherchepionXYW(x - 1, y + 2, wbox) != null) || (recherchepionXYB(x - 1, y + 2, bbox) != null))) // pas de deplacement 3 cas
                                {
                                    return null;
                                }
                                if ((recherchepionXYB(x, y - 1, bbox) != null) && (recherchepionXYW(x, y + 1, wbox) != null) && ((recherchepionXYW(x - 1, y - 2, wbox) != null) || (recherchepionXYB(x - 1, y - 2, bbox) != null)))   // pas de deplacement 4 cas
                                {
                                    return null;
                                }
                                if ((recherchepionXYB(x, y - 1, bbox) != null) && (recherchepionXYB(x, y + 1, bbox) != null) && ((recherchepionXYW(x - 1, y - 2, wbox) != null) || (recherchepionXYB(x - 1, y - 2, bbox) != null)) && ((recherchepionXYW(x - 1, y + 2, wbox) != null) || (recherchepionXYB(x - 1, y + 2, bbox) != null)))  //pas de deplacement cas 4
                                {
                                    return null;
                                }


                            }
                            //saut
                            if (x > 0)
                            {
                                if ((recherchepionXYB(x, y - 1, bbox) != null) && (recherchepionXYW(x - 1, y - 2, wbox) == null) && (recherchepionXYB(x - 1, y - 2, bbox) == null))  // premiere cas du saut 
                                {
                                    tab[0, 0] = x - 1;
                                    tab[0, 1] = y - 2;
                                    return tab;
                                }
                                if ((recherchepionXYB(x, y + 1, bbox) != null) && (recherchepionXYW(x - 1, y + 2, wbox) == null) && (recherchepionXYB(x - 1, y + 2, bbox) == null)) // deuxieme cas du saut
                                {
                                    tab[0, 0] = x - 1;
                                    tab[0, 1] = y + 2;
                                    return tab;
                                }
                            }
                            // mvt 
                            if (((recherchepionXYW(x, y - 1, wbox) == null) && (recherchepionXYB(x, y - 1, bbox) == null)) && ((recherchepionXYW(x, y + 1, wbox) != null) || (recherchepionXYB(x, y + 1, bbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x;
                                tab[0, 1] = y - 1;
                                return tab;
                            }
                            if (((recherchepionXYW(x, y + 1, wbox) == null) && (recherchepionXYB(x, y + 1, bbox) == null)) && ((recherchepionXYW(x, y - 1, wbox) != null) || (recherchepionXYB(x, y - 1, bbox) != null))) // mvt cas 1
                            {
                                tab[0, 0] = x;
                                tab[0, 1] = y + 1;
                                return tab;
                            }
                            if (((recherchepionXYW(x, y + 1, wbox) == null) && (recherchepionXYB(x, y + 1, bbox) == null)) && ((recherchepionXYW(x, y - 1, wbox) == null) && (recherchepionXYB(x, y - 1, bbox) == null)))
                            {
                                tab[0, 0] = x;
                                tab[0, 1] = y + 1;
                                tab[1, 0] = x;
                                tab[1, 1] = y - 1;
                                return tab;
                            }

                        }

                        break;

                }
            
               // MessageBox.Show("this");
            return null;

        }
        public static Boolean exist(int[,] tab,int x,int y)
            {
                for(int i=0; i<2;i++)
                {
                    if(((tab[0,0]==x)&&(tab[0,1]==y))||((tab[1,0]==x)&&(tab[1,1]==y)))
                        return true;
                }
            return false;
            }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox15)).BeginInit();
            this.SuspendLayout();
            // 
            // Grille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(732, 553);
            this.Name = "Grille";
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionWBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pionBBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempBBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rempWBox15)).EndInit();
            this.ResumeLayout(false);

        }

        private void acceuil_Paint(object sender, PaintEventArgs e)
        {

        }
      
        
    }



   
    }

