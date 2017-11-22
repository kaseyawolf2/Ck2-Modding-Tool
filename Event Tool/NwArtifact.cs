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
    public partial class NwArtifact : Form
    {
        //Only show modifiers needed
        public List<Program.WordList> ModifiersToShow = Program.BuildingsModi;
        //Modifiers String
        public string ModifiersString;
        public string PicPath;


        public NwArtifact()
        {
            InitializeComponent();
        }

        private void ModifierBt_Click(object sender, EventArgs e)
        {
            Program.MP = new ModifiersPage(ModifiersToShow);
            Program.MP.Show();
            Program.MP.FormClosed += new FormClosedEventHandler(MPClosed);
        }

        private void MPClosed(object sender, EventArgs e)
        {
            Program.MP.FormClosed -= new FormClosedEventHandler(MPClosed);
            ModifiersString = Program.MPOutput;
        }

        private void PicBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog EventFile = new OpenFileDialog
            {
                Filter = "PNG,JPEG|*.PNG;*.JPEG;*.JPG"
            };
            if (EventFile.ShowDialog() == DialogResult.OK)
            {
                PicPath = EventFile.FileName.ToString();
            }
        }
    }
}
