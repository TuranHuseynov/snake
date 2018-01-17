using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class Form1 : Form
    {
        byte Dir = 1;
        byte score = 0;
        int ContPcb = 3;

        PictureBox[] pic = new PictureBox[100];
        PictureBox NovPcb = new PictureBox();



        public Form1()
        {
            InitializeComponent();
            IniciarLayout();

        }

        private void IniciarLayout()
        {
            for(byte cont = 1; cont <= 3; cont++)
            {
                pic[cont] = new PictureBox();
                pic[cont].Width = 20;
                pic[cont].Height = 20;
                pic[cont].Left = cont* 20;
                pic[cont].Top = 20;
                pic[cont].BackColor = Color.Black;

                this.panel1.Controls.Add(pic[cont]);
                
            }

            NovPcb.Width = 20;
            NovPcb.Height = 20;
            NovPcb.BackColor = Color.CornflowerBlue;

            RndNovoLoc();

            this.panel1.Controls.Add(NovPcb);
            timer1.Start();

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if(Dir != 2)
                    {
                        Dir = 1;
                    }
                    break;

                case Keys.Left:
                    if(Dir != 1)
                    {
                        Dir = 2;
                    }
                    break;

                case Keys.Down:
                    if(Dir != 4)
                    {
                        Dir = 3;
                    }
                    break;

                case Keys.Up:
                    if (Dir != 3)
                    {
                        Dir = 4;
                    }
                    break;
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Movimento();
            
        }
        private void Movimento()
        {
            Point[] pt = new Point[2];
            pt[0] = pic[1].Location;

            switch (Dir)
            {
                case 1:
                    pic[1].Left += 20;
                    break;
                case 2:
                    pic[1].Left -= 20;
                    break;
                case 3:
                    pic[1].Top += 20;
                    break;
                case 4:
                    pic[1].Top -= 20;
                    break;
            }

            for(int cont = 2; cont <= ContPcb; cont++)
            {
                pt[1] = pic[cont].Location;
                pic[cont].Location = pt[0];
                pt[0] = pt[1];

            }

            Condicoes();
        }

        private void Condicoes()
        {
            if (pic[1].Location == NovPcb.Location)
            {
                score += 1;
                label1.Text = score.ToString();
                RndNovoLoc();
                 AddPic();

            }
            else if (pic[1].Location.X < 0 || pic[1].Location.X > 400 || pic[1].Location.Y < 0 || pic[1].Location.Y > 300 )
            {
                timer1.Stop();
                button1.Enabled = true;
                MessageBox.Show("Oyun Bitti");

            }

        }

        private void RndNovoLoc()
        {
            Random random = new Random();
            Point RndPt = new Point(20 * random.Next(20), 20 * random.Next(15));
            NovPcb.Location = RndPt;
        }

        private void AddPic()
        {
            ContPcb += 1;
            
            pic[ContPcb] = new PictureBox();
            pic[ContPcb].Width = 20;
            pic[ContPcb].Height = 20;
            pic[ContPcb].BackColor = Color.Black;
            pic[ContPcb].Left = -20;

            this.panel1.Controls.Add(pic[ContPcb]);
        }

         private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Dir = 1;
            ContPcb = 3;
            IniciarLayout();
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
