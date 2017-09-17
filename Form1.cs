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
    public partial class Form1 : Form

    {
        //System.Media.SoundPlayer player =new System.Media.SoundPlayer();

        public int posx; // x de pion selectionné.
        public int posy; // y de pion selectionné.
        public int nbrempB=0;  //nombre de pions noirs dehors.
        public int nbrempW = 0; // nombre de pions blancs dehors.
        int[,] tab = new int[2, 2];
        public Boolean mutexpr=false; //exlusion mutuelle (qui prend le role).
        public Boolean mutexpr1 = true;
        public Boolean IAB = false;

        public System.Windows.Forms.PictureBox[] remptabB = new System.Windows.Forms.PictureBox[16];
        public System.Windows.Forms.PictureBox[] remptabW = new System.Windows.Forms.PictureBox[16];
        public Form1()
        {

            InitializeComponent();
            int[,] grilles = new int[10, 5];
           // player.SoundLocation = "1588281554797_64418.wav";
          //  player.Play();
            

           
        }

        
        public System.Windows.Forms.PictureBox[,] grille = new System.Windows.Forms.PictureBox[10, 5];
        

        public System.Windows.Forms.PictureBox[] bbox = new System.Windows.Forms.PictureBox[16];
        public System.Windows.Forms.PictureBox[] wbox = new System.Windows.Forms.PictureBox[16];
       
       

        private void Form1_Load(object sender, EventArgs e)
        {
            grille[0, 0] = pictureBox00;
            grille[0, 1] = pictureBox01;
            grille[0, 2] = pictureBox02;
            grille[0, 3] = pictureBox03;
            grille[0, 4] = pictureBox04;
            grille[1, 0] = pictureBox10;
            grille[1, 1] = pictureBox11;
            grille[1, 2] = pictureBox12;
            grille[1, 3] = pictureBox13;
            grille[1, 4] = pictureBox14;
            grille[2, 0] = pictureBox20;
            grille[2, 1] = pictureBox21;
            grille[2, 2] = pictureBox22;
            grille[2, 3] = pictureBox23;
            grille[2, 4] = pictureBox24;
            grille[3, 0] = pictureBox30;
            grille[3, 1] = pictureBox31;
            grille[3, 2] = pictureBox32;
            grille[3, 3] = pictureBox33;
            grille[3, 4] = pictureBox34;
            grille[4, 0] = pictureBox40;
            grille[4, 1] = pictureBox41;
            grille[4, 2] = pictureBox42;
            grille[4, 3] = pictureBox43;
            grille[4, 4] = pictureBox44;
            grille[5, 0] = pictureBox50;
            grille[5, 1] = pictureBox51;
            grille[5, 2] = pictureBox52;
            grille[5, 3] = pictureBox53;
            grille[5, 4] = pictureBox54;
            grille[6, 0] = pictureBox60;
            grille[6, 1] = pictureBox61;
            grille[6, 2] = pictureBox62;
            grille[6, 3] = pictureBox63;
            grille[6, 4] = pictureBox64;
            grille[7, 0] = pictureBox70;
            grille[7, 1] = pictureBox71;
            grille[7, 2] = pictureBox72;
            grille[7, 3] = pictureBox73;
            grille[7, 4] = pictureBox74;
            grille[8, 0] = pictureBox80;
            grille[8, 1] = pictureBox81;
            grille[8, 2] = pictureBox82;
            grille[8, 3] = pictureBox83;
            grille[8, 4] = pictureBox84;
            grille[9, 0] = pictureBox90;
            grille[9, 1] = pictureBox91;
            grille[9, 2] = pictureBox92;
            grille[9, 3] = pictureBox93;
            grille[9, 4] = pictureBox94;
            remptabB[1] = rempBBox1;
            remptabB[2] = rempBBox2;
            remptabB[3] = rempBBox3;
            remptabB[4] = rempBBox4;
            remptabB[5] = rempBBox5;
            remptabB[6] = rempBBox6;
            remptabB[7] = rempBBox7;
            remptabB[8] = rempBBox8;
            remptabB[9] = rempBBox9;
            remptabB[10] = rempBBox10;
            remptabB[11] = rempBBox11;
            remptabB[12] = rempBBox12;
            remptabB[13] = rempBBox13;
            remptabB[14] = rempBBox14;
            remptabB[15] = rempBBox15;
            remptabW[1] = rempWBox1;
            remptabW[2] = rempWBox2;
            remptabW[3] = rempWBox3;
            remptabW[4] = rempWBox4;
            remptabW[5] = rempWBox5;
            remptabW[6] = rempWBox6;
            remptabW[7] = rempWBox7;
            remptabW[8] = rempWBox8;
            remptabW[9] = rempWBox9;
            remptabW[10] = rempWBox10;
            remptabW[11] = rempWBox11;
            remptabW[12] = rempWBox12;
            remptabW[13] = rempWBox13;
            remptabW[14] = rempWBox14;
            remptabW[15] = rempWBox15;
            /*grilles[0, 0] = 0;
            grilles[0, 1] = 0;
            grilles[0, 2] = 0;
            grilles[0, 3] = 0;
            grilles[0, 4] = 0;
            grilles[1, 0] = 0;
            grilles[1, 1] = 0;
            grilles[1, 2] = 0;
            grilles[1, 3] = 0;
            grilles[1, 4] = 0;
            grilles[2, 0] = 0;
            grilles[2, 1] = 0;
            grilles[2, 2] = 0;
            grilles[2, 3] = 0;
            grilles[2, 4] = 0;
            grilles[3, 0] = 0;
            grilles[3, 1] = 0;
            grilles[3, 2] = 0;
            grilles[3, 3] = 0;
            grilles[3, 4] = 0;
            grilles[4, 0] = 0;
            grilles[4, 1] = 0;
            grilles[4, 2] = 0;
            grilles[4, 3] = 0;
            grilles[4, 4] = 0;
            grilles[5, 0] = 0;
            grilles[5, 1] = 0;
            grilles[5, 2] = 0;
            grilles[5, 3] = 0;
            grilles[5, 4] = 0;
            grilles[6, 0] = 0;
            grilles[6, 1] = 0;
            grilles[6, 2] = 0;
            grilles[6, 3] = 0;
            grilles[6, 4] = 0;
            grilles[7, 0] = 0;
            grilles[7, 1] = 0;
            grilles[7, 2] = 0;
            grilles[7, 3] = 0;
            grilles[7, 4] = 0;
            grilles[8, 0] = 0;
            grilles[8, 1] = 0;
            grilles[8, 2] = 0;
            grilles[8, 3] = 0;
            grilles[8, 4] = 0;
            grilles[9, 0] = 0;
            grilles[9, 1] = 0;*/
            //grilles[9, 2] = 0;
            //grilles[9, 3] = 0;
            //grilles[9, 4] = 0;
            bbox[1] = pionBBox1;
            //grilles[0, 0] = 1;
            bbox[2] = pionBBox2;
            //grilles[1, 0] = 1;
            bbox[3] = pionBBox3;
            //grilles[2, 0] = 1;
            bbox[4] = pionBBox4;
            //grilles[3, 0] = 1;
            bbox[5] = pionBBox5;
            //grilles[4, 0] = 1;
            bbox[6] = pionBBox6;
            //grilles[0, 1] = 1;
            bbox[7] = pionBBox7;
            //grilles[1, 1] = 1;
            bbox[8] = pionBBox8;
            //grilles[2, 1] = 1;
            bbox[9] = pionBBox9;
            //grilles[3, 1] = 1;
            bbox[10] = pionBBox10;
            //grilles[4, 1] = 1;
            bbox[11] = pionBBox11;
            //grilles[0, 2] = 1;
            bbox[12] = pionBBox12;
            //grilles[1, 2] = 1;
            bbox[13] = pionBBox13;
            //grilles[2, 2] = 1;
            bbox[14] = pionBBox14;
            //grilles[3, 2] = 1;
            bbox[15] = pionBBox15;
            //grilles[4, 2] = 1;
            wbox[1] = pionWBox1;
            //grilles[0, 7] = 2;
            wbox[2] = pionWBox2;
            //grilles[1, 7] = 2;
            wbox[3] = pionWBox3;
            //grilles[2, 7] = 2;
            wbox[4] = pionWBox4;
            //grilles[3, 7] = 2;
            wbox[5] = pionWBox5;
            //grilles[4, 7] = 2;
            wbox[6] = pionWBox6;
            //grilles[0, 8] = 2;
            wbox[7] = pionWBox7;
            //grilles[1, 8] = 2;
            wbox[8] = pionWBox8;
            //grilles[2, 8] = 2;
            wbox[9] = pionWBox9;
            //grilles[3, 8] = 2;
            wbox[10] = pionWBox10;
            //grilles[4, 8] = 2;
            wbox[11] = pionWBox11;
            //grilles[0, 9] = 2;
            wbox[12] = pionWBox12;
            //grilles[1, 9] = 2;
            wbox[13] = pionWBox13;
            //grilles[2, 9] = 2;
            wbox[14] = pionWBox14;
            //grilles[3, 9] = 2;
            wbox[15] = pionWBox15;
            //grilles[4, 9] = 2;
            
        }

        private void pictureBox00_Click(object sender, EventArgs e)
        {
            traitement(pictureBox00);
        }

        private void pictureBox01_Click(object sender, EventArgs e)
        {
            traitement(pictureBox01);
        }

        private void pictureBox02_Click(object sender, EventArgs e)
        {
            traitement(pictureBox02);
            
        }

        private void pictureBox03_Click(object sender, EventArgs e)
        {
            traitement(pictureBox03);     
        }

        private void pictureBox04_Click(object sender, EventArgs e)
        {
            traitement(pictureBox04);    
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            traitement(pictureBox10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            traitement(pictureBox11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            traitement(pictureBox12);    
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            traitement(pictureBox13);
            
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            traitement(pictureBox14); 
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            traitement(pictureBox20);       
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            traitement(pictureBox21); 
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            traitement(pictureBox22);   
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            traitement(pictureBox23);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            traitement(pictureBox24);
           
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            traitement(pictureBox30);
            
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            traitement(pictureBox31);
           
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            traitement(pictureBox32);
            
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            traitement(pictureBox33);
            if (IAB == true)
            {
                movementIA(IA());
                mutexpr=false;
            }


            
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            traitement(pictureBox34);
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            traitement(pictureBox40);     
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            traitement(pictureBox41);     
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            traitement(pictureBox42);
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            traitement(pictureBox43);    
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            traitement(pictureBox44);
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            traitement(pictureBox50);     
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            traitement(pictureBox51);   
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            traitement(pictureBox52);
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            traitement(pictureBox53);          
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            traitement(pictureBox54);  
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            traitement(pictureBox60);       
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            traitement(pictureBox61); 
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            traitement(pictureBox62);  
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            traitement(pictureBox63);       
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            traitement(pictureBox34);     
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            traitement(pictureBox70);        
        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {
            traitement(pictureBox71);     
        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {
            traitement(pictureBox72); 
        }

        private void pictureBox73_Click(object sender, EventArgs e)
        {
            traitement(pictureBox73);
        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {
            traitement(pictureBox74); 
        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {
            traitement(pictureBox80);         
        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {
            traitement(pictureBox81);    
        }

        private void pictureBox82_Click(object sender, EventArgs e)
        {
            traitement(pictureBox82); 
        }

        private void pictureBox83_Click(object sender, EventArgs e)
        {
            traitement(pictureBox83);
        }

        private void pictureBox84_Click(object sender, EventArgs e)
        {
            traitement(pictureBox84);
        }

        private void pictureBox90_Click(object sender, EventArgs e)
        {
            traitement(pictureBox90);
        }

        private void pictureBox91_Click(object sender, EventArgs e)
        {
            traitement(pictureBox91);
        }

        private void pictureBox92_Click(object sender, EventArgs e)
        {
            traitement(pictureBox92);
        }

        private void pictureBox93_Click(object sender, EventArgs e)
        {
            traitement(pictureBox93);    
        }

        private void pictureBox94_Click(object sender, EventArgs e)
        {
            traitement(pictureBox94); 
        }

        private void pionBBox1_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox1);
                posy = Grille.y(pionBBox1);
                tab = Grille.paspossiblesB(pionBBox1, bbox, wbox);
            }

        }

        private void pionBBox2_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox2);
                posy = Grille.y(pionBBox2);
                tab = Grille.paspossiblesB(pionBBox2, bbox, wbox);
            }
        }

        private void pionBBox3_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox3);
                posy = Grille.y(pionBBox3);
                tab = Grille.paspossiblesB(pionBBox3, bbox, wbox);
            }
        }

        private void pionBBox4_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox4);
                posy = Grille.y(pionBBox4);
                tab = Grille.paspossiblesB(pionBBox4, bbox, wbox);
            }
        }

        private void pionBBox5_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox5);
                posy = Grille.y(pionBBox5);
                tab = Grille.paspossiblesB(pionBBox5, bbox, wbox);
            }
        }

        private void pionBBox6_Click(object sender, EventArgs e)
        {
           
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox6);
                posy = Grille.y(pionBBox6);
                tab = Grille.paspossiblesB(pionBBox6, bbox, wbox);
            }
        }

        private void pionBBox7_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox7);
                posy = Grille.y(pionBBox7);
                tab = Grille.paspossiblesB(pionBBox7, bbox, wbox);
            }
        }

        private void pionBBox8_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox8);
                posy = Grille.y(pionBBox8);
                tab = Grille.paspossiblesB(pionBBox8, bbox, wbox);



            }
        }

        private void pionBBox9_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox9);
                posy = Grille.y(pionBBox9);
                tab = Grille.paspossiblesB(pionBBox9, bbox, wbox);
            }
        }

        private void pionBBox10_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox10);
                posy = Grille.y(pionBBox10);
                tab = Grille.paspossiblesB(pionBBox10, bbox, wbox);
            }
        }

        private void pionBBox11_Click(object sender, EventArgs e)
        {
            
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox11);
                posy = Grille.y(pionBBox11);
                tab = Grille.paspossiblesB(pionBBox11, bbox, wbox);
            }
        }

        private void pionBBox12_Click(object sender, EventArgs e)
        {
           
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox12);
                posy = Grille.y(pionBBox12);
                tab = Grille.paspossiblesB(pionBBox12, bbox, wbox);
            }
        }

        private void pionBBox13_Click(object sender, EventArgs e)
        {
            
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox13);
                posy = Grille.y(pionBBox13);
                tab = Grille.paspossiblesB(pionBBox13, bbox, wbox);
            }
        }
        public static void test()
        {
           // MessageBox.Show("this");
        }

        private void pionBBox14_Click(object sender, EventArgs e)
        {
           
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox14);
                posy = Grille.y(pionBBox14);
                tab = Grille.paspossiblesB(pionBBox14, bbox, wbox);
            }
        }

        private void pionBBox15_Click(object sender, EventArgs e)
        {
            if (mutexpr == true) //B
            {
                posx = Grille.x(pionBBox15);
                posy = Grille.y(pionBBox15);
                tab = Grille.paspossiblesB(pionBBox15, bbox, wbox);
            }
        }

        private void pionWBox1_Click(object sender, EventArgs e)
        {

            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox1);
                posy = Grille.y(pionWBox1);
                tab = Grille.paspossiblesW(pionWBox1, bbox, wbox);
            }
        }

        private void pionWBox2_Click(object sender, EventArgs e)
        {

            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox2);
                posy = Grille.y(pionWBox2);
                tab = Grille.paspossiblesW(pionWBox2, bbox, wbox);
            }
        }

        private void pionWBox3_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox3);
                posy = Grille.y(pionWBox3);
                tab = Grille.paspossiblesW(pionWBox3, bbox, wbox);
            }
        }

        private void pionWBox4_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox4);
                posy = Grille.y(pionWBox4);
                tab = Grille.paspossiblesW(pionWBox4, bbox, wbox);
            }
        }

        private void pionWBox5_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox5);
                posy = Grille.y(pionWBox5);
                tab = Grille.paspossiblesW(pionWBox5, bbox, wbox);
            }
        }

        private void pionWBox6_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox6);
                posy = Grille.y(pionWBox6);
                tab = Grille.paspossiblesW(pionWBox6, bbox, wbox);
            }
        }

        private void pionWBox7_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox7);
                posy = Grille.y(pionWBox7);
                tab = Grille.paspossiblesW(pionWBox7, bbox, wbox);
            }
        }

        private void pionWBox8_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox8);
                posy = Grille.y(pionWBox8);
                tab = Grille.paspossiblesW(pionWBox8, bbox, wbox);
            }
        }

        private void pionWBox9_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox9);
                posy = Grille.y(pionWBox9);
                tab = Grille.paspossiblesW(pionWBox9, bbox, wbox);
            }
        }

        private void pionWBox10_Click(object sender, EventArgs e)
        {
            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox10);
                posy = Grille.y(pionWBox10);
                tab = Grille.paspossiblesW(pionWBox10, bbox, wbox);
            }
        }

        private void pionWBox11_Click(object sender, EventArgs e)
        {

            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox11);
                posy = Grille.y(pionWBox11);
                tab = Grille.paspossiblesW(pionWBox11, bbox, wbox);
            }
        }

        private void pionWBox12_Click(object sender, EventArgs e)
        {

            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox12);
                posy = Grille.y(pionWBox12);
                tab = Grille.paspossiblesW(pionWBox12, bbox, wbox);
            }
        }

        private void pionWBox13_Click(object sender, EventArgs e)
        {

            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox13);
                posy = Grille.y(pionWBox13);
                tab = Grille.paspossiblesW(pionWBox13, bbox, wbox);
            }
        }

        private void pionWBox14_Click(object sender, EventArgs e)
        {

            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox14);
                posy = Grille.y(pionWBox14);
                tab = Grille.paspossiblesW(pionWBox14, bbox, wbox);
            }
        }

        private void pionWBox15_Click(object sender, EventArgs e)
        {

            if (mutexpr == false) //W
            {
                posx = Grille.x(pionWBox15);
                posy = Grille.y(pionWBox15);
                tab = Grille.paspossiblesW(pionWBox15, bbox, wbox);
                
            }
        }






        public void init()
        {

            bbox[1] = pionBBox1;
            //grilles[0, 0] = 1;
            bbox[2] = pionBBox2;
            //grilles[1, 0] = 1;
            bbox[3] = pionBBox3;
            //grilles[2, 0] = 1;
            bbox[4] = pionBBox4;
            //grilles[3, 0] = 1;
            bbox[5] = pionBBox5;
            //grilles[4, 0] = 1;
            bbox[6] = pionBBox6;
            //grilles[0, 1] = 1;
            bbox[7] = pionBBox7;
            //grilles[1, 1] = 1;
            bbox[8] = pionBBox8;
            //grilles[2, 1] = 1;
            bbox[9] = pionBBox9;
            //grilles[3, 1] = 1;
            bbox[10] = pionBBox10;
            //grilles[4, 1] = 1;
            bbox[11] = pionBBox11;
            //grilles[0, 2] = 1;
            bbox[12] = pionBBox12;
            //grilles[1, 2] = 1;
            bbox[13] = pionBBox13;
            //grilles[2, 2] = 1;
            bbox[14] = pionBBox14;
            //grilles[3, 2] = 1;
            bbox[15] = pionBBox15;
            //grilles[4, 2] = 1;
            wbox[1] = pionWBox1;
            //grilles[0, 7] = 2;
            wbox[2] = pionWBox2;
            //grilles[1, 7] = 2;
            wbox[3] = pionWBox3;
            //grilles[2, 7] = 2;
            wbox[4] = pionWBox4;
            //grilles[3, 7] = 2;
            wbox[5] = pionWBox5;
            //grilles[4, 7] = 2;
            wbox[6] = pionWBox6;
            //grilles[0, 8] = 2;
            wbox[7] = pionWBox7;
            //grilles[1, 8] = 2;
            wbox[8] = pionWBox8;
            //grilles[2, 8] = 2;
            wbox[9] = pionWBox9;
            //grilles[3, 8] = 2;
            wbox[10] = pionWBox10;
            //grilles[4, 8] = 2;
            wbox[11] = pionWBox11;
            //grilles[0, 9] = 2;
            wbox[12] = pionWBox12;
            //grilles[1, 9] = 2;
            wbox[13] = pionWBox13;
            //grilles[2, 9] = 2;
            wbox[14] = pionWBox14;
            //grilles[3, 9] = 2;
            wbox[15] = pionWBox15;
            //grilles[4, 9] = 2;
            //MessageBox.Show("this");
            


        }
        public void traitement(System.Windows.Forms.PictureBox obj)
        {
            int x = Grille.x(obj);
            int y = Grille.y(obj);
            MessageBox.Show("x :" + posx);
            MessageBox.Show("y :" + posy);
            MessageBox.Show("x suivant:" + x);
            MessageBox.Show("y suivant:" + y);
            if (mutexpr == true)  //B
            {
                  if (tab != null)
                    {
                        if (Grille.exist(tab, x, y))
                        {

                            if (Math.Abs(posy - y) == 2)
                            {
                                nbrempW++;                                                         //afficher le pion remplacant 
                                remptabW[nbrempW].Visible = true;                                  //
                                if ((posy % 2) == 0)
                                    // Grille.recherchepionXYW(posx + 1, (posy + y) / 2, wbox).Visible = false;  //cacher le pion perdu 
                                    Grille.recherchepionXYW(posx + 1, (posy + y) / 2, wbox).Location = pictureBox1.Location;

                                if ((posy % 2) != 0)                                                          //
                                    // Grille.recherchepionXYW(posx, (posy + y) / 2, wbox).Visible = false;
                                    Grille.recherchepionXYW(posx, (posy + y) / 2, wbox).Location = pictureBox1.Location; //


                            }
                            Grille.recherchepionXYB(posx, posy, bbox).Location = obj.Location;
                            mutexpr = false;
                            init();
                        }
                    }
                
                if (IAB == true)
                {
                    movementIA(IA());
                    mutexpr = false;
                }

            }
            //if (mutexpr == false)   //w
            else
            {
                MessageBox.Show("x :" + posx);
                MessageBox.Show("y :" + posy);
                MessageBox.Show("x suivant:" + x);
                MessageBox.Show("y suivant:" + y);
                if (tab != null)
                {
                    if (Grille.exist(tab, x, y))
                    {

                        if (Math.Abs(posy - y) == 2)
                        {
                            nbrempB++;                                                                 //
                            remptabB[nbrempB].Visible = true;                                          //affichage d'un pion remplacant
                            if ((posy % 2) == 0)
                                //Grille.recherchepionXYB(posx, (posy + y) / 2, bbox).Visible = false;
                            Grille.recherchepionXYB(posx, (posy + y) / 2, bbox).Location = pictureBox1.Location;
                            if ((posy % 2) != 0)                                                          //cacher le pion perdu (noir)
                                //Grille.recherchepionXYB(posx - 1, (posy + y) / 2, bbox).Visible = false;
                            Grille.recherchepionXYB(posx - 1, (posy + y) / 2, bbox).Location = pictureBox1.Location;

                        }
                         Grille.recherchepionXYW(posx, posy, wbox).Location = obj.Location;
                        mutexpr = true;
                        init();
                        if (IAB == true)
                        {
                            int a = IA();
                            if (Math.Abs((a % 10) - ((a / 100) % 10)) == 2)
                           
                            {
                                nbrempW++;                                                         //afficher le pion remplacant 
                                remptabW[nbrempW].Visible = true;                                  //
                                if (((a % 10) % 2) == 0)
                                    // Grille.recherchepionXYW(posx + 1, (posy + y) / 2, wbox).Visible = false;  //cacher le pion perdu 
                                    Grille.recherchepionXYW(((a / 10) % 10) , ((a % 10) + ((a / 100) % 10)) / 2, wbox).Location = pictureBox1.Location;

                                if (((a % 10) % 2) != 0)                                                          //
                                    // Grille.recherchepionXYW(posx, (posy + y) / 2, wbox).Visible = false;
                                    Grille.recherchepionXYW(((a / 10) % 10), ((a % 10) + ((a / 100) % 10))  / 2, wbox).Location = pictureBox1.Location; //


                            //((a / 1000), ((cordonné / 100) % 10), bbox).Location = grille[(cordonné % 10), ((a / 10) % 10)]
                            }
                            movementIA(a);
                            init();


                            mutexpr = false;
                        }
                    }
                }
            }
        }
        public Boolean iffinishB()
        {
            
            for (int i = 1; i <= 15; i++)
            {
                if ((Grille.x(bbox[i]) == 4)&&(Grille.y(bbox[i])%2==0))
                {
                    return true;
                }
            }

            return false;
        }
        public Boolean iffinishW()
        {

            for (int i = 1; i <= 15; i++)
            {
                if ((Grille.x(wbox[i]) == 0) && (Grille.y(wbox[i]) % 2 != 0))
                {
                    return true;
                }
            }

            return false;
        }

        private void Synchrone_Tick(object sender, EventArgs e)
        {
            if (iffinishW())
            {
                
                Form1_Load(sender, e);
                Synchrone.Enabled = false;
                MessageBox.Show(" Joueur(1) a gagné");
                button6.Visible = false;
                acceuil.Visible = true;
                

                
            }
            if (iffinishB())
            {
                
                Form1_Load(sender, e);
                Synchrone.Enabled = false;
                MessageBox.Show("Joueur(2) a gagné");
                button6.Visible = false;
                acceuil.Visible = true;
                                            
           }

        }
        public int IA()
        {
            AI intelegence = new AI(3,1,3);
            AI intelegence1 = new AI(3, 1, 3);
            intelegence1= intelegence.buildAI(bbox, wbox);
int res= intelegence.choix(intelegence1);
            return res;

        }

        public void initall()
        {
            IAB = false;


            pionBBox1.Location = new System.Drawing.Point(87, 97);

            // 
            // pionWBox1
            // 

            pionWBox1.Location = new System.Drawing.Point(518, 51);

            // 
            // pionWBox2
            // 

            pionWBox2.Location = new System.Drawing.Point(517, 145);

            // 
            // pionWBox3
            // 
            pionWBox3.Location = new System.Drawing.Point(519, 238);
            // 
            // pionWBox4
            // 
            pionWBox4.Location = new System.Drawing.Point(517, 334);

            // 
            // pionWBox7
            // 
            pionWBox7.Location = new System.Drawing.Point(470, 192);
            // 
            // pionWBox6
            // 
            pionWBox6.Location = new System.Drawing.Point(469, 97);
            // 
            // pionWBox5
            // 
            pionWBox5.Location = new System.Drawing.Point(519, 427);
            // 
            // pionWBox11
            // 
            pionWBox11.Location = new System.Drawing.Point(421, 50);
            // 
            // pionWBox10
            // 
            pionWBox10.Location = new System.Drawing.Point(470, 475);
            // 
            // pionWBox9
            // 
            pionWBox9.Location = new System.Drawing.Point(469, 380);
            // 
            // pionWBox8
            // 
            pionWBox8.Location = new System.Drawing.Point(469, 284);
            // 
            // pionWBox12
            // 
            pionWBox12.Location = new System.Drawing.Point(420, 143);
            // 
            // pionWBox13
            // 
            pionWBox13.Location = new System.Drawing.Point(419, 238);
            // 
            // pionWBox14
            // 
            pionWBox14.Location = new System.Drawing.Point(421, 334);
            // 
            // pionWBox15
            // 
            pionWBox15.Location = new System.Drawing.Point(421, 427);
            // 
            // pionBBox2
            // 
            pionBBox2.Location = new System.Drawing.Point(87, 191);
            // 
            // pionBBox3
            // 
            pionBBox3.Location = new System.Drawing.Point(86, 285);
            // 
            // pionBBox4
            // 
            pionBBox4.Location = new System.Drawing.Point(89, 380);
            // 
            // pionBBox5
            // 
            pionBBox5.Location = new System.Drawing.Point(88, 474);
            // 
            // pionBBox6
            // 
            pionBBox6.Location = new System.Drawing.Point(134, 50);
            // 
            // pionBBox7
            // 
            pionBBox7.Location = new System.Drawing.Point(135, 144);
            // 
            // pionBBox8
            // 
            pionBBox8.Location = new System.Drawing.Point(137, 238);
            // 
            // pionBBox11
            // 
            pionBBox11.Location = new System.Drawing.Point(183, 96);
            // 
            // pionBBox10
            // 
            pionBBox10.Location = new System.Drawing.Point(134, 426);
            // 
            // pionBBox9
            // 
            pionBBox9.Location = new System.Drawing.Point(134, 334);
            // 
            // pionBBox14
            // 
            pionBBox14.Location = new System.Drawing.Point(184, 381);
            // 
            // pionBBox13
            // 
            pionBBox13.Location = new System.Drawing.Point(183, 285);
            // 
            // pionBBox12
            // 
            pionBBox12.Location = new System.Drawing.Point(183, 190);
            // 
            // pionBBox15
            // 
            pionBBox15.Location = new System.Drawing.Point(183, 474);
            // 
            // rempBBox1
            // 
            rempBBox1.Location = new System.Drawing.Point(594, 29);
            rempBBox1.Visible = false;
            // 
            // rempBBox2
            // 
            rempBBox2.Location = new System.Drawing.Point(594, 62);

            rempBBox2.Visible = false;
            // 
            // rempBBox3
            // 
            rempBBox3.Location = new System.Drawing.Point(594, 95);
            rempBBox3.Visible = false;
            // 
            // rempBBox4
            // 
            rempBBox4.Location = new System.Drawing.Point(594, 129);
            rempBBox4.Visible = false;
            // 
            // rempBBox5
            // 
            rempBBox5.Location = new System.Drawing.Point(594, 162);
            rempBBox5.Visible = false;
            // 
            // rempBBox6
            // 
            rempBBox6.Location = new System.Drawing.Point(594, 195);
            rempBBox6.Visible = false;
            // 
            // rempBBox7
            // 
            rempBBox7.Location = new System.Drawing.Point(594, 229);
            rempBBox7.Visible = false;
            // 
            // rempBBox8
            // 
            rempBBox8.Location = new System.Drawing.Point(594, 262);
            rempBBox8.Visible = false;
            // 
            // rempBBox9
            // 
            rempBBox9.Location = new System.Drawing.Point(594, 294);
            rempBBox9.Visible = false;
            // 
            // rempBBox10
            // 
            rempBBox10.Location = new System.Drawing.Point(594, 327);
            rempBBox10.Visible = false;
            // 
            // rempBBox11
            // 
            rempBBox11.Location = new System.Drawing.Point(594, 360);
            rempBBox11.Visible = false;
            // 
            // rempBBox12
            // 
            rempBBox12.Location = new System.Drawing.Point(594, 394);
            rempBBox12.Visible = false;
            // 
            // rempBBox13
            // 
            rempBBox13.Location = new System.Drawing.Point(594, 426);
            rempBBox13.Visible = false;
            // 
            // rempBBox14
            // 
            rempBBox14.Location = new System.Drawing.Point(594, 459);
            rempBBox14.Visible = false;
            // 
            // rempBBox15
            // 
            rempBBox15.Location = new System.Drawing.Point(594, 491);
            rempBBox15.Visible = false;
            // 
            // rempWBox1
            // 
            rempWBox1.Location = new System.Drawing.Point(22, 29);
            rempWBox1.Visible = false;
            // 
            // rempWBox2
            // 
            rempWBox2.Location = new System.Drawing.Point(22, 62);
            rempWBox2.Visible = false;
            // 
            // rempWBox3
            // 
            rempWBox3.Location = new System.Drawing.Point(22, 95);
            rempWBox3.Visible = false;
            // 
            // rempWBox4
            // 
            rempWBox4.Location = new System.Drawing.Point(22, 129);
            rempWBox4.Visible = false;
            // 
            // rempWBox5
            // 
            rempWBox5.Location = new System.Drawing.Point(22, 162);
            rempWBox5.Visible = false;
            // 
            // rempWBox6
            // 
            rempWBox6.Location = new System.Drawing.Point(22, 195);
            rempWBox6.Visible = false;
            // 
            // rempWBox7
            // 
            rempWBox7.Location = new System.Drawing.Point(22, 229);
            rempWBox7.Visible = false;
            // 
            // rempWBox8
            // 
            rempWBox8.Location = new System.Drawing.Point(22, 262);
            rempWBox8.Visible = false;
            // 
            // rempWBox9
            // 
            rempWBox9.Location = new System.Drawing.Point(22, 294);
            rempWBox9.Visible = false;
            // 
            // rempWBox10
            // 
            rempWBox10.Location = new System.Drawing.Point(22, 327);
            rempWBox10.Visible = false;
            // 
            // rempWBox11
            // 
            rempWBox11.Location = new System.Drawing.Point(22, 360);
            rempWBox11.Visible = false;
            // 
            // rempWBox12
            // 
            rempWBox12.Location = new System.Drawing.Point(22, 394);
            rempWBox12.Visible = false;
            // 
            // rempWBox13
            // 
            rempWBox13.Location = new System.Drawing.Point(22, 427);
            rempWBox13.Visible = false;
            // 
            // rempWBox14
            // 


            rempWBox14.Location = new System.Drawing.Point(22, 459);
            rempWBox14.Visible = false;
            // 
            // rempWBox15
            // 

            rempWBox15.Location = new System.Drawing.Point(22, 491);
            rempWBox15.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Mode.Visible = true;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Voulez vous Vraiment Quitter 'Jeu De Dame'","Quitter",
    MessageBoxButtons.YesNo);
            if(result1==DialogResult.Yes)
            Application.Exit();
            if (result1 == DialogResult.No)
            { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            acceuil.Visible = true;
            button6.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            acceuil.Visible = false;
        }


        void movementIA(int cordonné)
        {
        Grille.recherchepionXYB(cordonné / 1000, (cordonné / 100) % 10, bbox).Location = grille[(cordonné % 10), (cordonné / 10) % 10].Location;
        }

        private void acceuil_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void button7_Click_1(object sender, EventArgs e)
        {
            initall();
            Mode.Visible = false;
            acceuil.Visible = false;
            IAB = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            initall();
            Mode.Visible = false;
            acceuil.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mode.Visible = false;
            acceuil.Visible = true;
        }

        private void flash_Tick(object sender, EventArgs e)
        {
            if (mutexpr == false)
            {
                vertdroite.Visible = true;
                vertgauche.Visible = false;
            }
            if (mutexpr == true)
            {
                vertdroite.Visible = false;
                vertgauche.Visible = true;
            }


        }
    }
    
}
