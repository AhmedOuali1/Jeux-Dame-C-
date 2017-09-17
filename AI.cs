using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu_Dames
{
    class AI
    {
        //-----------------// les attributs //////////---------------------------------------//
        AI noeudprecedent=null;
        int niveau;
        AI[] tabpas=null;
        int x=-1;
        int y=-1;
        int x1 = -1;
        int y1 = -1;
        int valeur;
        int[,] matrice = new int[6, 10];
        

        //-----------------//les constructeurs ///---------------------------//
        public AI(int niveau,int x,int y)
        {
            this.x=x;
            this.y=y;
            this.niveau=niveau;
        }
        public AI(int niveau, int x, int y, int valeur,int[,] matrice)
        {
            this.x = x;
            this.y = y;
            this.niveau = niveau;
            this.valeur = valeur;
            this.matrice = matrice;
            this.tabpas = new AI[nbrfilsB(matrice)+20];
        }
        public AI(int niveau, int x, int y,int x1,int y1, int valeur, int[,] matrice)
        {
            this.x = x;
            this.y = y;
            this.niveau = niveau;
            this.valeur = valeur;
            this.matrice = matrice;
            this.tabpas = new AI[nbrfilsB(matrice) + 20];
            this.x1 = x1;
            this.y1 = y1;
        }
        public AI(int niveau, int valeur,int[,] matrice)
        {
            
            this.niveau = niveau;
            this.valeur = valeur;
            this.matrice = matrice;
            this.tabpas = new AI[nbrfilsB(matrice)+20];
           
        }
        public AI(int niveau,int[,] matrice)
        {
            this.niveau=niveau;
            this.matrice=matrice;
            this.tabpas = new AI[nbrfilsB(matrice)+20];
        }

       
       /// /////////////////////////////////////////////////////////////////////////:::
       
        public int nbrfilsB(int[,] matrice)
        {
            int n=0;
            int j,k;
            int[,] tabexixt = new int[30, 2];
                for (j = 0; j < 4; j++)
                {
                    for (k = 0; k <10; k++)
                    {
                        if ((paspossiblesB1(matrice, j, k) != null)&& (matrice[j,k]==1))
                        {
                            if (!existmatrice(tabexixt, paspossiblesB1(matrice, j, k)[0, 0], paspossiblesB1(matrice, j, k)[0, 1], 30))
                            {
                                tabexixt[n, 0] = paspossiblesB1(matrice, j, k)[0, 0];
                                tabexixt[n, 1] = paspossiblesB1(matrice, j, k)[0, 1];
                                n++;
                            }
                            if(paspossiblesB1(matrice, j, k)[0,1]!=-1)
                            {
                                if (!existmatrice(tabexixt, paspossiblesB1(matrice, j, k)[1, 0], paspossiblesB1(matrice, j, k)[1, 1], 30))
                            {
                                tabexixt[n, 0] = paspossiblesB1(matrice, j, k)[1, 0];
                                tabexixt[n, 1] = paspossiblesB1(matrice, j, k)[1, 1];
                                n++;
                            }

                            }
                        }
                            
                            
                        

                    }
                }
            
            return n;
        }
        //-------------------------------------------------------------
        public int nbrfilsW(int[,] matrice)
        {
            int n = 0;
            int j, k;
            
                for (j = 1; j <= 4; j++)
                {
                    for (k = 0; k <= 9; k++)
                    {
                        if ((paspossiblesW1(matrice, j, k) != null) && (matrice[j, k] == 0))
                            n++;
                    }
                }
            
            return n;
        }

        /////////////////////////////////////////////////////////////////////////////////

        public static int[,] formermatrice(System.Windows.Forms.PictureBox[] bbox,System.Windows.Forms.PictureBox[] wbox)
        {
             int[,] result=new int[5,10];
             for (int i = 0; i < 5; i++)
             {
                 for (int j = 0; j < 10; j++)
                 {
                     result[i, j] = -1;
                 }
             }
            for (int i=0; i < 5; i++)
            {
                for (int j=0; j < 10; j++)                                                  //former une matrice telque les pion noirs sont 
                {                                                                           //marquer par un "1" et les blanc par "0" 
                    for (int k = 1; k <= 15; k++)                                            //sinon la case de la matrice resoit un "-1"
                    {
                        if ((Grille.x(bbox[k]) == i) && (Grille.y(bbox[k]) == j))
                        {
                            result[i, j] = 1;
                            //System.Windows.Forms.MessageBox.Show("x"+i+"y"+j+"="+1);
                            break;
                        }
                        if ((Grille.x(wbox[k]) == i) && (Grille.y(wbox[k]) == j))
                        {
                            result[i, j] = 0;
                            //System.Windows.Forms.MessageBox.Show("x" + i + "y" + j + "=" + 0);
                            break;
                        }

                       
                    }
                }
            }
            return result; 
        }
        //-----------------------//----------------------------------------------------------
        public AI AI1max(int[,] matrice,int niveau)
        {
            int j;
            int nbrfils=0;
            int[,] tab=new int[2,2]; 
            AI ai=new AI(niveau,matrice);  //la racine 
            int val;
            int[,] matriceinter = new int[5, 10]; //matrice intermediaire
            matriceinter = egalitematrice(matrice);
            int a = nbrfilsB(matrice);
            int[,] tabexist=new int[a+20,2];
            // System.Windows.Forms.MessageBox.Show("" + a);
            for (int i=0; i < 4; i++)
            {
                for(j=0;j<=9;j++)
                {
                    tab=paspossiblesB1(matrice,i,j);

                    if((tab!=null)&&(matrice[i,j]==1))
                    {
                        if (!existmatrice(tabexist, tab[0, 0], tab[0, 1], a))
                        {
                            matriceinter[i, j] = -1;
                            matriceinter[tab[0, 0], tab[0, 1]] = 1;
                            val = valeursB(j, tab[0, 1]); //obtenir une valeur

                            ai.tabpas[nbrfils] = new AI(niveau + 1, i, j, tab[0, 0], tab[0, 1], val, matriceinter);
                            matriceinter=egalitematrice(matrice);
                            tabexist[nbrfils, 0] = tab[0, 0];
                            tabexist[nbrfils, 1] = tab[0, 1];
                            nbrfils++;
                        }

                        if (tab[1, 0] != -1)
                        {
                            if (!existmatrice(tabexist, tab[1, 0], tab[1, 1], a))
                            {
                                matriceinter[i, j] = -1;
                                matriceinter[tab[1, 0], tab[1, 1]] = 1;
                                val = valeursB(j, tab[1, 1]);
                                ai.tabpas[nbrfils] = new AI(niveau + 1, i, tab[1, 0], tab[1, 1], j, val, matriceinter);
                                matriceinter = egalitematrice(matrice);
                                tabexist[nbrfils, 0] = tab[1, 0];
                                tabexist[nbrfils, 1] = tab[1, 1];
                                nbrfils++;

                            }
                        }
                     }
                }
            }
            return ai;
        }
        public void AI1min(AI noeud)
        {
            int[,] tab = new int[2, 2];
            int[,] matriceinter = new int[5, 10];
            int nbrfils = 0;
            int j = 0;
            int val;
            matriceinter=egalitematrice(noeud.matrice);
            for (int i = 1; i <=4; i++)
            {
                for (j = 0; j <= 9; j++)
                {
                    tab = paspossiblesW1(noeud.matrice, i, j);
                    if ((tab != null) && (noeud.matrice[i, j] == 0))
                    {
                        if (tab[0, 1] < 10)
                        {
                            matriceinter[i, j] = -1;
                            matriceinter[tab[0, 0], tab[0, 1]] = 0;
                            val = valeursW(j, tab[0, 1]);
                            noeud.tabpas[nbrfils] = new AI(niveau + 1, i, tab[0, 0], tab[0, 1], j, val, matriceinter);
                            matriceinter = egalitematrice(noeud.matrice);
                            nbrfils++;
                        }
                        if (tab[1, 0] != -1)
                        {
                            matriceinter[i, j] = -1;
                            matriceinter[tab[1, 0], tab[1, 1]] = 0;
                            val = valeursW(j, tab[1, 1]);
                            noeud.tabpas[nbrfils] = new AI(niveau + 1, i, j,tab[1, 0],tab[1, 1], val, matriceinter);
                            matriceinter = egalitematrice(noeud.matrice);
                            nbrfils++;
                        }
                    }
                }
            }

        }
        public AI buildAI(System.Windows.Forms.PictureBox[] bbox,System.Windows.Forms.PictureBox[] wbox)
        {
            int[,] matrice = new int[5, 10];
            matrice = formermatrice(bbox, wbox);
            //for(int i=0;i<9;i++)
            //{
            //System.Windows.Forms.MessageBox.Show(""+matrice[0,i]+matrice[0,i]);
            //}
            if (matrice[1, 1] == 1) 
            Form1.test();
             AI ai=AI1max(matrice, 0);
            for (int i = 0; i < nbrfilsB(matrice); i++)
            {
                if(ai.tabpas[i]!=null)
                AI1min(ai.tabpas[i]);
            }
            return ai;
        }

        public int choix(AI ai)
        {
            int j;
            String s="";
            int max;
            int[,] tableau = new int[nbrfilsB(ai.matrice),2];
            for (int i = 0; i < nbrfilsB(ai.matrice); i++)
            {
                if (ai.tabpas[i] != null)
                {
                    s = "";
                    tableau[i, 0] = ai.tabpas[i].valeur;
                    s = s + ai.tabpas[i].x + "" + ai.tabpas[i].y + ai.tabpas[i].x1 + ai.tabpas[i].y1;
                    tableau[i, 1] = int.Parse(s);
                    max = -50;
                    for (j = 0; j < nbrfilsW(ai.tabpas[i].matrice); j++)
                    {
                        
                        if (ai.tabpas[i].tabpas[j].valeur + ai.tabpas[i].valeur > max)
                            tableau[i, 0] = ai.tabpas[i].tabpas[j].valeur + ai.tabpas[i].valeur;
                    }
                }
            }
            int pos = 0;//tableau[0,1];
            max = tableau[0, 0];
            for (int i = 1; i < nbrfilsB(ai.matrice); i++)
            {
                if (tableau[i, 0] > max)
                {
                    pos = i;
                    max = tableau[i, 0];
                }


            }
            return tableau[pos,1];


        }

        //---------//------------------------------------------------------------------------
        public static int[,] paspossiblesB1(int[,] matrice, int x, int y)
        {
            int[,] tab = new int[2, 2];
            tab[0, 0] = -1;
            tab[0, 1] = -1;
            tab[1, 0] = -1;
            tab[1, 1] = -1;
            
            //MessageBox.Show("" +x);
            //MessageBox.Show("" + y);



            switch (y)
            {
                case 0:
                    if (((matrice[x + 1, y + 1] == 1) || ((matrice[x + 1, y + 1] == 0))) && ((matrice[x + 1, y + 2] == 1) || (matrice[x + 1, y + 2] == 0)))  //les cas ou il n'y aa pas de deplacement
                    {
                        // MessageBox.Show("this");
                        return null;
                    }
                    if (matrice[x + 1, y + 1] == 1)
                    {
                        // MessageBox.Show("this");
                        return null;
                    }
                    if ((matrice[x + 1, y + 1] == 0) && (matrice[x + 1, y + 2] != 1) && (matrice[x + 1, y + 2] != 0))     //le cas ou il y a saut  
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y + 2;
                        return tab;
                    }
                    if ((matrice[x + 1, y + 1] != 1) && (matrice[x + 1, y + 1] != 0)) //cas ou il y a saut
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y + 1;
                        return tab;
                    }


                    break;
                case 1:

                    if ((matrice[x, y + 1] ==1) && ((matrice[x, y - 1] ==1) || (matrice[x, y + 1] ==0))) //pas de deplacement cas 1
                    {
                        // MessageBox.Show("this");
                        return null;
                    }
                    if (((matrice[x, y - 1]==1 ) || (matrice[x, y -1] ==0 )) && (matrice[x, y +1]==0 ) && ((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +2]==0 )))   //pas de deplacement cas 1
                    {
                        //MessageBox.Show("this");
                        return null;
                    }
                    if ((matrice[x, y +1]==0 ) && (matrice[x+1, y +2] !=0 ) && (matrice[x+1, y +2] !=1 ))  //saut 
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y + 2;
                        //  MessageBox.Show("" + x);
                        return tab;
                    }
                    if ((matrice[x, y + 1] != 0) && (matrice[x, y + 1] != 1) && ((matrice[x, y - 1] != 1) && (matrice[x, y - 1] != 0))) //mvt 1
                    {

                        tab[0, 0] = x;
                        tab[0, 1] = y + 1;
                        tab[1, 0] = x;
                        tab[1, 1] = y - 1;
                        // MessageBox.Show("" + x);
                        return tab;
                    }
                    if ((matrice[x, y -1] !=0 ) && (matrice[x, y -1] !=1 ))   // mvt cas 2
                    {
                        tab[0, 0] = x;
                        tab[0, 1] = y - 1;
                        // MessageBox.Show("" + x);
                        return tab;

                    }
                    if ((matrice[x, y +1] !=0 ) && (matrice[x, y +1] !=1 ))
                    {
                        tab[0, 0] = x;
                        tab[0, 1] = y + 1;
                        // MessageBox.Show("" + x);
                        return tab;

                    }

                    break;
                case 8:
                    //pas de mvt 
                    if ((matrice[x+1, y -1]==1 ) && (matrice[x+1, y +1]==1 ))
                    {
                        return null;
                    }
                    if (((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +1]==0 )) && ((matrice[x+1, y -1]==0 ) || (matrice[x+1, y -1]==1 )) && ((matrice[x+1, y -2]==1 ) || (matrice[x+1, y -2]==0 )))
                    {
                        return null;
                    }
                    //saut 
                    if ((matrice[x+1, y -1]==0 ) && (matrice[x+1, y -2] !=0 ) && (matrice[x+1, y -2] !=1 ))
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y + 2;
                        return tab;

                    }
                    //mvt
                    if (((matrice[x+1, y +1] !=0 ) && (matrice[x+1, y +1] !=1 )) && ((matrice[x+1, y -1] !=0 ) && (matrice[x+1, y -1] !=1 )))
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y + 1;
                        tab[1, 0] = x + 1;
                        tab[1, 1] = y - 1;
                        return tab;

                    }
                    if ((matrice[x+1, y +1] !=0 ) && (matrice[x+1, y +1] !=1 ))
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y + 1;
                        return tab;
                    }
                    if ((matrice[x+1, y -1] !=0 ) && (matrice[x+1, y -1] !=1 ))
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y - 1;
                        return tab;
                    }



                    break;


                case 9:
                    // pas de mvt 
                    if (matrice[x, y - 1]==1 )
                    {
                        // MessageBox.Show("this");
                        return null;
                    }
                    if ((matrice[x, y -1] ==0 ) && ((matrice[x+1, y -2]==0 ) || (matrice[x+1, y -2]==1 )))
                    {
                        return null;
                    }
                    // saut 
                    if ((x < 4) && (matrice[x, y -1] ==0 ) && (matrice[x+1, y -2] !=0 ) && (matrice[x+1, y -2] !=1 ))
                    {
                        tab[0, 0] = x + 1;
                        tab[0, 1] = y - 2;
                        return tab;
                    }
                    // mvt
                    if ((matrice[x, y -1] !=1 ) && (matrice[x, y -1] !=0 ))
                    {
                        tab[0, 0] = x;
                        tab[0, 1] = y - 1;
                        return tab;
                    }

                    break;


                default:
                    // cas de y pair
                    if ((y == 2) || (y == 4) || (y == 6))
                    {
                        // pas de deplacement
                        if ((matrice[x+1, y -1]==1 ) && (matrice[x+1, y +1]==1 )) // pas de deplacement 1 cas 
                            return null;
                        // if ((x == 3) && ((matrice[x+1, y -1]==1 ) || (matrice[x+1, y -1]==0 )) && ((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +1]==0 ))) // pas de deplacement 2 cas
                        //     return null;  // cas impaire
                        if ((matrice[x+1, y -1]==1 ) && (matrice[x+1, y +1]==0 ) && ((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +2]==0 ))) // pas de deplacement 3 cas
                        {
                            //MessageBox.Show("  ");
                            return null;
                        }
                        if ((matrice[x+1, y -1]==0 ) && (matrice[x+1, y +1]==1 ) && ((matrice[x+1, y -2]==1 ) || (matrice[x+1, y -2]==0 )))   // pas de deplacement 4 cas
                        {
                            // MessageBox.Show("  ");
                            return null;
                        }
                        if ((matrice[x+1, y -1]==0 ) && (matrice[x+1, y +1]==0 ) && ((matrice[x+1, y -2]==1 ) || (matrice[x+1, y -2]==0 )) && ((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +2]==0 )))  //pas de deplacement cas 4
                        {
                            //MessageBox.Show("  ");
                            return null;
                        }
                        // sauts
                        if ((matrice[x+1, y -1]==0 ) && (matrice[x+1, y -2] !=1 ) && (matrice[x+1, y -2] !=0 ))  // premiere cas du saut 
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y - 2;
                            //MessageBox.Show("this");
                            return tab;
                        }
                        if ((matrice[x+1, y +1]==0 ) && (matrice[x+1, y +2] !=1 ) && (matrice[x+1, y +2] !=0 )) // deuxieme cas du saut
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y + 2;
                            //MessageBox.Show("this");
                            return tab;
                        }
                        // mvt
                        if (((matrice[x+1, y -1] !=1 ) && (matrice[x+1, y -1] !=0 )) && ((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +1]==0 ))) // mvt cas 1
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y - 1;
                            //MessageBox.Show("this");
                            return tab;
                        }
                        if (((matrice[x+1, y +1] !=1 ) && (matrice[x+1, y +1] !=0 )) && ((matrice[x+1, y -1]==1 ) || (matrice[x+1, y -1]==0 ))) // mvt cas 1
                        {
                            tab[0, 0] = x + 1;
                            tab[0, 1] = y + 1;
                            //MessageBox.Show("this");
                            return tab;
                        }
                        if (((matrice[x+1, y +1] !=1 ) && (matrice[x+1, y +1] !=0 )) && ((matrice[x+1, y -1] !=1 ) && (matrice[x+1, y -1] !=0 )))
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
                        if ((matrice[x, y - 1]==1 ) && (matrice[x, y +1] ==1 )) // pas de deplacement 1 cas
                            return null;
                        if ((x == 4) && ((matrice[x, y - 1]==1 ) || (matrice[x, y -1] ==0 )) && ((matrice[x, y +1] ==1 ) || (matrice[x, y +1]==0 ))) // pas de deplacement 2 cas
                            return null;
                        if (x < 4)
                        {
                            if ((matrice[x, y - 1]==1 ) && (matrice[x, y +1]==0 ) && ((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +2]==0 ))) // pas de deplacement 3 cas
                            {
                                return null;
                            }
                            if ((matrice[x, y -1] ==0 ) && (matrice[x, y +1] ==1 ) && ((matrice[x+1, y -2]==1 ) || (matrice[x+1, y -2]==0 )))   // pas de deplacement 4 cas
                            {
                                return null;
                            }
                            if ((matrice[x, y -1] ==0 ) && (matrice[x, y +1]==0 ) && ((matrice[x+1, y -2]==1 ) || (matrice[x+1, y -2]==0 )) && ((matrice[x+1, y +1]==1 ) || (matrice[x+1, y +2]==0 )))  //pas de deplacement cas 4
                            {
                                return null;
                            }


                        }
                        //saut
                        if (x < 4)
                        {
                            if ((matrice[x, y -1] ==0 ) && (matrice[x+1, y -2] !=1 ) && (matrice[x+1, y -2] !=0 ))  // premiere cas du saut 
                            {
                                tab[0, 0] = x + 1;
                                tab[0, 1] = y - 2;
                                return tab;
                            }
                            if ((matrice[x, y +1]==0 ) && (matrice[x+1, y +2] !=1 ) && (matrice[x+1, y +2] !=0 )) // deuxieme cas du saut
                            {
                                tab[0, 0] = x + 1;
                                tab[0, 1] = y + 2;
                                return tab;
                            }
                        }
                        // mvt 
                        if (((matrice[x, y +1] !=1 ) && (matrice[x, y +1] !=0 )) && ((matrice[x, y -1] !=1 ) && (matrice[x, y -1] !=0 )))
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y + 1;
                            tab[1, 0] = x;
                            tab[1, 1] = y - 1;
                            // MessageBox.Show("debug");
                            return tab;
                        }
                        if (((matrice[x, y -1] !=1 ) && (matrice[x, y -1] !=0 )) && ((matrice[x, y +1] ==1 ) || (matrice[x, y +1]==0 ))) // mvt cas 1
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y - 1;
                            return tab;
                        }
                        if (((matrice[x, y +1] !=1 ) && (matrice[x, y +1] !=0 )) && ((matrice[x, y - 1]==1 ) || (matrice[x, y -1] ==0 ))) // mvt cas 1
                        {
                            tab[0, 0] = x;
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
        //---------------------//----------------------------------------------------------
        public static int[,] paspossiblesW1(int[,] matrice, int x, int y)
        {
            int[,] tab = new int[2, 2];
            tab[0, 0] = -1;
            tab[0, 1] = -1;
            tab[1, 0] = -1;
            tab[1, 1] = -1;
           
            //MessageBox.Show("" +x);
            //MessageBox.Show("" + y);

            
            



            switch (y)
            {
                case 0:
                    if (matrice[x, y +1] ==0 )
                    {
                        //MessageBox.Show("this");
                        return null;
                    }
                    if (((matrice[x, y +1] ==0 ) || ((matrice[x, y +1] ==1 ))) && ((matrice[x, y +2] ==0 ) || (matrice[x, y +2] ==1 )))  //les cas ou il n'y aa pas de deplacement
                    {
                        //MessageBox.Show("this");
                        return null;
                    }

                    if ((matrice[x, y +1] ==1 ) && (matrice[x, y +2] !=0 ) && (matrice[x, y +2] !=1 ))     //le cas ou il y a saut  
                    {
                        tab[0, 0] = x - 1;
                        tab[0, 1] = y + 2;
                        return tab;
                    }
                    if ((matrice[x, y +1] !=1 ) && (matrice[x, y +1] !=0 ))
                    {
                        tab[0, 0] = x;
                        tab[0, 1] = y + 1;
                        return tab;
                    }


                    break;
                case 1:

                    if ((matrice[x-1, y +1] ==0 ) && ((matrice[x-1, y -1] ==0 ) || (matrice[x-1, y -1] ==1 ))) //pas de deplacement cas 1
                    {
                        // MessageBox.Show("this");
                        return null;
                    }
                    if (((matrice[x-1, y -1] ==0 ) || (matrice[x-1, y -1] ==1 )) && ((matrice[x-1, y +1] ==0 ) || (matrice[x-1, y +1] ==1 )) && ((matrice[x-1, y +2] ==0 ) || (matrice[x-1, y +2] ==1 )))   //pas de deplacement cas 1
                    {
                        //MessageBox.Show("this");
                        return null;
                    }
                    if ((matrice[x-1, y +1] ==1 ) && (matrice[x-1, y +2] !=1 ) && (matrice[x-1, y +2] !=0 ))  //saut 
                    {
                        tab[0, 0] = x - 1;
                        tab[0, 1] = y + 2;
                        //MessageBox.Show("" + x);
                        return tab;
                    }
                    if ((matrice[x-1, y +1] !=1 ) && (matrice[x-1, y +1] !=0 ) && (matrice[x-1, y -1] !=1 ) && (matrice[x-1, y -1] !=0 )) //mvt 1
                    {

                        tab[0, 0] = x - 1;
                        tab[0, 1] = y + 1;
                        tab[1, 0] = x - 1;
                        tab[1, 1] = y - 1;
                        //MessageBox.Show("" + tab[0, 0] + " " + tab[0, 1] + " " + tab[1, 0] + " " + tab[1, 1]);
                        return tab;
                    }
                    if ((matrice[x-1, y -1] !=1 ) && (matrice[x-1, y -1] !=0 ))   // mvt cas 2
                    {
                        tab[0, 0] = x - 1;
                        tab[0, 1] = y - 1;
                        //MessageBox.Show("" + x);
                        return tab;
                    }
                    if ((matrice[x-1, y +1] !=1 ) && (matrice[x-1, y +1] !=0 ))
                    {
                        tab[0, 0] = x - 1;
                        tab[0, 1] = y + 1;
                        // MessageBox.Show("" + x);
                        return tab;
                    }

                    break;
                case 8:
                    //pas de mvt 
                    if ((matrice[x, y -1] ==0 ) && (matrice[x, y +1] ==0 ))
                    {
                        return null;
                    }
                    if (((matrice[x, y +1] ==0 ) || (matrice[x, y +1] ==1 )) && ((matrice[x, y -1] ==1 ) || (matrice[x-1, y -1] ==0 )) && ((matrice[x-1, y -2] ==0 ) || (matrice[x-1, y -2] ==1 )))
                    {
                        return null;
                    }
                    //saut 
                    if ((x > 0) && (matrice[x, y -1] ==1 ) && (matrice[x-1, y -2] !=1 ) && (matrice[x-1, y -2] !=0 ))
                    {
                        tab[0, 0] = x - 1;
                        tab[0, 1] = y + 2;
                        return tab;

                    }
                    //mvt
                    if (((matrice[x, y +1] !=1 ) && (matrice[x, y +1] !=0 )) && ((matrice[x, y -1] !=1 ) && (matrice[x, y -1] !=0 )))
                    {
                        tab[0, 0] = x;
                        tab[0, 1] = y + 1;
                        tab[1, 0] = x;
                        tab[1, 1] = y - 1;
                        return tab;

                    }
                    if ((matrice[x, y +1] !=1 ) && (matrice[x, y +1] !=0 ))
                    {
                        tab[0, 0] = x;
                        tab[0, 1] = y + 1;
                        return tab;
                    }
                    if ((matrice[x, y -1] !=1 ) && (matrice[x, y -1] !=0 ))
                    {
                        tab[0, 0] = x;
                        tab[0, 1] = y - 1;
                        return tab;
                    }



                    break;


                case 9:
                    // pas de mvt 
                    if (matrice[x-1, y -1] ==0 )
                    {
                        // MessageBox.Show("this");
                        return null;
                    }
                    if ((matrice[x-1, y -1] ==1 ) && ((matrice[x-1, y -2] ==1 ) || (matrice[x-1, y -2] ==0 )))
                    {
                        return null;
                    }
                    // saut 
                    if ((matrice[x-1, y -1] ==1 ) && (matrice[x-1, y -2] !=1 ) && (matrice[x-1, y -2] !=0 ))
                    {
                        tab[0, 0] = x - 1;
                        tab[0, 1] = y - 2;
                        return tab;
                    }
                    // mvt
                    if ((matrice[x-1, y -1] !=0 ) && (matrice[x-1, y -1] !=1 ))
                    {
                        tab[0, 0] = x - 1;
                        tab[0, 1] = y - 1;
                        return tab;
                    }

                    break;


                default:
                    // cas de y pair
                    if ((y == 3) || (y == 5) || (y == 7))
                    {
                        // pas de deplacement
                        if ((matrice[x-1, y -1] ==0 ) && (matrice[x-1, y +1] ==0 )) // pas de deplacement 1 cas
                            return null;
                        // if ((x == 3) && ((recherchepionXYB(x + 1, y - 1, bbox) != null) || (recherchepionXYW(x + 1, y - 1, wbox) != null)) && ((recherchepionXYB(x + 1, y + 1, bbox) != null) || (recherchepionXYW(x + 1, y + 1, wbox) != null))) // pas de deplacement 2 cas
                        //     return null;  // cas impaire
                        if ((matrice[x-1, y -1] ==0 ) && (matrice[x-1, y +1] ==1 ) && ((matrice[x-1, y +2] ==0 ) || (matrice[x-1, y +2] ==1 ))) // pas de deplacement 3 cas
                        {
                            return null;
                        }
                        if ((matrice[x-1, y -1] ==1 ) && (matrice[x-1, y +1] ==0 ) && ((matrice[x-1, y -2] ==0 ) || (matrice[x-1, y -2] ==1 )))   // pas de deplacement 4 cas
                        {
                            return null;
                        }
                        if ((matrice[x-1, y -1] ==1 ) && (matrice[x-1, y +1] ==1 ) && ((matrice[x-1, y -2] ==0 ) || (matrice[x-1, y -2] ==1 )) && ((matrice[x-1, y +2] ==0 ) || (matrice[x-1, y +2] ==1 )))  //pas de deplacement cas 4
                        {
                            return null;
                        }
                        // sauts
                        if ((matrice[x-1, y -1] ==1 ) && (matrice[x-1, y -2] !=0 ) && (matrice[x-1, y -2] !=1 ))  // premiere cas du saut 
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y - 2;
                            return tab;
                        }
                        if ((matrice[x-1, y +1] ==1 ) && (matrice[x-1, y +2] !=0 ) && (matrice[x-1, y +2] !=1 )) // deuxieme cas du saut
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y + 2;
                            return tab;
                        }
                        // mvt
                        if (((matrice[x-1, y -1] !=0 ) && (matrice[x-1, y -1] !=1 )) && ((matrice[x-1, y +1] ==0 ) || (matrice[x-1, y +1] ==1 ))) // mvt cas 1
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y - 1;
                            return tab;
                        }
                        if (((matrice[x-1, y +1] !=0 ) && (matrice[x-1, y +1] !=1 )) && ((matrice[x-1, y -1] ==0 ) || (matrice[x-1, y -1] ==1 ))) // mvt cas 1
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y + 1;
                            return tab;
                        }
                        if (((matrice[x-1, y +1] !=0 ) && (matrice[x-1, y +1] !=1 )) && ((matrice[x-1, y -1] !=0 ) && (matrice[x-1, y -1] !=1 )))
                        {
                            tab[0, 0] = x - 1;
                            tab[0, 1] = y + 1;
                            tab[1, 0] = x - 1;
                            tab[1, 1] = y - 1;
                            return tab;
                        }

                    }
                    // y impair

                    if ((y == 2) || (y == 4) || (y == 6))
                    {
                        // pas de deplacement
                        if ((matrice[x, y -1] ==0 ) && (matrice[x, y +1] ==0 )) // pas de deplacement 1 cas
                            return null;
                        if ((x == 0) && ((matrice[x, y -1] ==0 ) || (matrice[x, y -1] ==1 )) && ((matrice[x, y +1] ==0 ) || (matrice[x, y +1] ==1 ))) // pas de deplacement 2 cas
                            return null;
                        if (x > 0)
                        {
                            if ((matrice[x, y -1] ==0 ) && (matrice[x, y +1] ==1 ) && ((matrice[x-1, y +2] ==0 ) || (matrice[x-1, y +2] ==1 ))) // pas de deplacement 3 cas
                            {
                                return null;
                            }
                            if ((matrice[x, y -1] ==1 ) && (matrice[x, y +1] ==0 ) && ((matrice[x-1, y -2] ==0 ) || (matrice[x-1, y -2] ==1 )))   // pas de deplacement 4 cas
                            {
                                return null;
                            }
                            if ((matrice[x, y -1] ==1 ) && (matrice[x, y +1] ==1 ) && ((matrice[x-1, y -2] ==0 ) || (matrice[x-1, y -2] ==1 )) && ((matrice[x-1, y +2] ==0 ) || (matrice[x-1, y +2] ==1 )))  //pas de deplacement cas 4
                            {
                                return null;
                            }


                        }
                        //saut
                        if (x > 0)
                        {
                            if ((matrice[x, y -1] ==1 ) && (matrice[x-1, y -2] !=0 ) && (matrice[x-1, y -2] !=1 ))  // premiere cas du saut 
                            {
                                tab[0, 0] = x - 1;
                                tab[0, 1] = y - 2;
                                return tab;
                            }
                            if ((matrice[x, y +1] ==1 ) && (matrice[x-1, y +2] !=0 ) && (matrice[x-1, y +2] !=1 )) // deuxieme cas du saut
                            {
                                tab[0, 0] = x - 1;
                                tab[0, 1] = y + 2;
                                return tab;
                            }
                        }
                        // mvt 
                        if (((matrice[x, y -1] !=0 ) && (matrice[x, y -1] !=1 )) && ((matrice[x, y +1] ==0 ) || (matrice[x, y +1] ==1 ))) // mvt cas 1
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y - 1;
                            return tab;
                        }
                        if (((matrice[x, y +1] !=0 ) && (matrice[x, y +1] !=1 )) && ((matrice[x, y -1] ==0 ) || (matrice[x, y -1] ==1 ))) // mvt cas 1
                        {
                            tab[0, 0] = x;
                            tab[0, 1] = y + 1;
                            return tab;
                        }
                        if (((matrice[x, y +1] !=0 ) && (matrice[x, y +1] !=1 )) && ((matrice[x, y -1] !=0 ) && (matrice[x, y -1] !=1 )))
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
        public int valeursB(int yinit, int yaprés)
        {
            switch(yaprés)
            {
                case 4:
                    return 20;
                break;
                default:
                if ((yaprés - yinit) == 2)
                    return 5;
                 break;
            }
            return 0;
        }
        public int valeursW(int yinit,int yaprés)
        {
            switch (yaprés)
            {
                case 4:
                    return -20;
                    break;
                default:
                    if ((yaprés - yinit) == 2)
                        return -3;
                    break;
            }
            return 0;
        }
        public Boolean existmatrice(int[,] matrice, int x, int y,int nbrfilsB)
        {
            for (int i = 0; i < nbrfilsB; i++)
            {
                if ((matrice[i, 0] == x) && (matrice[i, 1] == y))
                    return true;
            }
            return false;
        }
        int[,] egalitematrice(int[,] matrice)
        {
            int[,] result = new int[5, 10];
            int i,j;
            for(i=0;i<5;i++)
            {
                for(j=0;j<10;j++)
                {
                    result[i,j]=matrice[i,j];
                }
            }
            return result;
        }


    }
}
