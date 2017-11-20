using System;
using System.Windows.Forms;

namespace Ck2ModdingTool
{
    public partial class MoreLangs : Form
    {
        public MoreLangs()
        {
            InitializeComponent();
        }

        private void ExitBt_Click_1(object sender, EventArgs e)
        {
            
            Program.NE.DescText.Text = EnglishText.Text;
            Program.NE.Opt1BtText.Text = Eng1.Text;
            Program.NE.Opt2BtText.Text = Eng2.Text;
            Program.NE.Opt3BtText.Text = Eng3.Text;
            Program.NE.Opt4BtText.Text = Eng4.Text;

            Program.frdesc = FrenchText.Text;
            Program.fr1 = Fr1.Text;
            Program.fr2 = Fr2.Text;
            Program.fr3 = Fr3.Text;
            Program.fr4 = Fr4.Text;

            Program.grdesc = GermanText.Text;
            Program.gr1 = Gr1.Text;
            Program.gr2 = Gr2.Text;
            Program.gr3 = Gr3.Text;
            Program.gr4 = Gr4.Text;

            Program.spdesc = SpanishText.Text;
            Program.sp1 = Sp1.Text;
            Program.sp2 = Sp2.Text;
            Program.sp3 = Sp3.Text;
            Program.sp4 = Sp4.Text;
            
            this.Close();
        }
    }
}
