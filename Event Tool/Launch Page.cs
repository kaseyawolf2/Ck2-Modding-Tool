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
    public partial class Launch_Page : Form
    {
        public Launch_Page()
        {
            InitializeComponent();
        }
        #region Mod Saving/Loading

        private void SaveModBt_Click(object sender, EventArgs e)
        {
            if (ModNameText.Text == "")
            {
                MessageBox.Show("Please Enter Mod Name", "No Data Entered", MessageBoxButtons.OK);
                return;
            }
            ModNameText.Text = ModNameText.Text.Replace(" ", "_");
            Program.Tags = TagText.Text;
            Program.Modname = ModNameText.Text.Replace(" ", "_");

            string ModPath = Program.ModsFolderPath + @"\" + Program.Modname + @".mod";


            if (!System.IO.File.Exists(ModPath))
            {
                Program.NewMod(false);
            }
            else
            {
                DialogResult dResult = MessageBox.Show("File Already Exists, Overwrite", "Debug", MessageBoxButtons.YesNo);
                if (dResult == DialogResult.Yes)
                {
                    Program.NewMod(true);
                }
            }
        }

        private void LoadModBt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Mod = new FolderBrowserDialog { SelectedPath = Program.ModsFolderPath };
            if (Mod.ShowDialog() == DialogResult.OK && Mod.SelectedPath != Program.ModsFolderPath)
            {
                if (!System.IO.File.Exists(Mod.SelectedPath + @"\ModInfo.xml"))
                {
                    MessageBox.Show("Please Select a Mod With a Modinfo.xml", "No Modinfo.xml", MessageBoxButtons.OK);
                    return;
                }
                Program.Modname = System.IO.Path.GetFileName(Mod.SelectedPath);

                Reader.LoadModInfo();

                Program.LoadModinfo();

            }
        }


        #endregion

        #region Mod Info
        
        private void PicBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog EventFile = new OpenFileDialog
            {
                Filter = "PNG,JPEG|*.PNG;*.JPEG;*.JPG"
            };
            if (EventFile.ShowDialog() == DialogResult.OK)
            {
                Program.PicPath = EventFile.FileName.ToString();
            }
        }

        private void ModFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ModFolder = new FolderBrowserDialog { SelectedPath = Program.Ck2Path };
            if (ModFolder.ShowDialog() == DialogResult.OK)
            {
                Program.Ck2Path = ModFolder.SelectedPath;
            }
        }

        #endregion

        #region New Mod Parts

        private void BtNwEvent_Click(object sender, EventArgs e)
        {
            Program.NE = new NwEvent();
            if (!Program.ModLoaded)
            {
                MessageBox.Show("Please Load/Create a Mod", "No Mod Data", MessageBoxButtons.OK);
                return;
            }
            if (!System.IO.File.Exists(Program.CurrentModFolderPath + @"\events"))
            {
                Reader.CreateFolder(Program.CurrentModFolderPath + @"\events");
            }
            if (!System.IO.File.Exists(Program.CurrentModFolderPath + @"\localisation"))
            {
                Reader.CreateFolder(Program.CurrentModFolderPath + @"\localisation");
            }

            Program.Makenamespace();

            Reader.LoadEventInfo();


            Program.NE.EveGroupBox.Items.Clear();
            foreach (var item in Program.EventInfo)
            {
                Program.NE.EveGroupBox.Items.Add( item.EventGroup.ToString() );
            }
            Program.NE.Show();
        }

        private void BtNwBuilding_Click(object sender, EventArgs e)
        {
            Program.NB = new NwBuilding();
            if (!Program.ModLoaded)
            {
                MessageBox.Show("Please Load/Create a Mod", "No Mod Data", MessageBoxButtons.OK);
                return;
            }
            if (!System.IO.File.Exists(Program.CurrentModFolderPath + @"\common"))
            {
                Reader.CreateFolder(Program.CurrentModFolderPath + @"\common");
            }
            if (!System.IO.File.Exists(Program.CurrentModFolderPath + @"\common\buildings"))
            {
                Reader.CreateFolder(Program.CurrentModFolderPath + @"\common\buildings");
            }
            if (!System.IO.File.Exists(Program.CurrentModFolderPath + @"\localisation"))
            {
                Reader.CreateFolder(Program.CurrentModFolderPath + @"\localisation");
            }

            Program.NB.Show();



        }


        #endregion

        private void BtNwArtifact_Click(object sender, EventArgs e)
        {

        }
    }
}
