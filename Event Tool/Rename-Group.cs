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
    public partial class Rename_Group : Form
    {
        public Rename_Group()
        {
            InitializeComponent();
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            AcceptButton = SaveBt;
        }

        private void SaveBt_Click(object sender, EventArgs e)
        {
            Program.EventInfo.Find(x => x.EventGroup == SelBox.Text).EventGroup = NameTxt.Text;
            
            SelBox.SelectedItem = NameTxt.Text;
            
            Program.NE.EveGroupBox.Items.Clear();
            foreach (var item in Program.EventInfo)
            {
                Program.NE.EveGroupBox.Items.Add(item.EventGroup.ToString());
            }
            Program.SaveEventGroups();
            Close();
        }
    }
}
