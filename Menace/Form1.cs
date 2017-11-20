using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ruaraidheulib;
using Ruaraidheulib.Games;

namespace Menace
{
    public partial class Form1 : Form
    {
        bool playingx = true;
        bool playersgo = false;
        public Form1()
        {
            InitializeComponent();
            Board b = new Board(3,3);

            //List<MenaceAI> mai = new List<MenaceAI>();
            //Loop.For(()=>
            //{
            //    mai.Add(new MenaceAI(b.Width,b.Height));
            //}, 2);
            //ThueMorse tm = new ThueMorse();
            //int x = 0, y = 0;
            //Loop.While(() => { return !b.IsWon(); }, (i) =>
            //{
            //    mai[i%2].Play(b);
            //    b.Play((Board.Players)((i % 2)+1), x, y);
            //});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (playersgo)
            {
                if (playingx)
                {
                    button1.Text = "X";
                }
                else
                {
                    button1.Text = "O";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (playersgo)
            {
                if (playingx)
                {
                    button2.Text = "X";
                }
                else
                {
                    button2.Text = "O";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
            {
            if (playersgo)
            {
                if (playingx)
                {
                    button3.Text = "X";
                }
                else
                {
                    button3.Text = "O";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
                {
            if (playersgo)
            {
                if (playingx)
                {
                    button4.Text = "X";
                }
                else
                {
                    button4.Text = "O";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
                    {
            if (playersgo)
            {
                if (playingx)
                {
                    button5.Text = "X";
                }
                else
                {
                    button5.Text = "O";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
                        {
            if (playersgo)
            {
                if (playingx)
                {
                    button6.Text = "X";
                }
                else
                {
                    button6.Text = "O";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
                            {
            if (playersgo)
            {
                if (playingx)
                {
                    button7.Text = "X";
                }
                else
                {
                    button7.Text = "O";
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
                                {
            if (playersgo)
            {
                if (playingx)
                {
                    button8.Text = "X";
                }
                else
                {
                    button8.Text = "O";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (playersgo)
            {
                if (playingx)
                {
                    button9.Text = "X";
                }
                else
                {
                    button9.Text = "O";
                }
            }
        }
    }
}
