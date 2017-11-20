using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ck2ModdingTool
{
    public partial class ModifiersPage : Form
    {
        public ModifiersPage()
        {
            InitializeComponent();
        }



        public void ModifiersPage_Resize(Object sender, EventArgs e)
        {
            Program.NB.Controls.Clear();
            Program.NB.Refresh();
            Program.NB.DrawModifiers();
            Program.NB.Refresh();
        }
    }
}
