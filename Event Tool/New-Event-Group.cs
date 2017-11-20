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
    public partial class New_Event_Group : Form
    {
        public New_Event_Group()
        {
            InitializeComponent();
        }

        private void SaveBt_Click(object sender, EventArgs e)
        {
            Program.NE.EveGroupBox.Items.Add(NameTxt.Text);
            Program.EventInfo.Add(new Program.EventGroupClass { EventGroup = NameTxt.Text });
            Program.SaveEventGroups();
            Close();
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            AcceptButton = SaveBt;
        }
    }
}
