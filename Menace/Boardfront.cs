using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menace
{
    public partial class Boardfront : UserControl
    {
        Board b;
        public Boardfront()
        {
            InitializeComponent();
            b = new Board(3, 3);

        }
    }
}
