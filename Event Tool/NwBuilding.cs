using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Tool
{
    public partial class NwBuilding : Form
    {
        public NwBuilding()
        {
            InitializeComponent();
        }
        

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
    }
}
