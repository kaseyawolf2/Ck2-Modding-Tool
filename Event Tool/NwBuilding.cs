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
    public partial class NwBuilding : Form
    {
        public NwBuilding()
        {
            InitializeComponent();
        }

        //Only show modis needed
        public List<Program.WordList> ModifiersToShow = Program.BuildingsModi;

        private void SaveBt_Click(object sender, EventArgs e)
        {
            
            Reader.CreateFileIfNotExist(Program.CurrentModFolderPath + @"\common\buildings","Test_Buildings.txt");

            #region Building String
            string Building;
            Building = HoldingCB.SelectedText +  @" = {
    " + BuildingNameText.Text + @" = {
        " + "desc = ";





            #endregion
            
        }

        

        private void ModifierBt_Click(object sender, EventArgs e)
        {
            Program.MP = new ModifiersPage(ModifiersToShow);
            Program.MP.DrawModifiers(ModifiersToShow,0);
            Program.MP.DrawBt();
            Program.MP.Show();
        }

        


        

    }
}
