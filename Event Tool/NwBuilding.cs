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
            Program.MP = new ModifiersPage();
            DrawModifiers();

            Program.MP.Show();
        }

        public void DrawModifiers()
        {
            int MaxY = Program.MP.Height / 30;

            int Y = 10;
            int X = 14;
            foreach (var item in Program.Modifiers)
            {
                Label label = NewLabel(item.Word, X, Y, item.Word.Length);
                Program.MP.Controls.Add(label);


                TextBox textBox = NewTextBox(item.Word, 125 + X, Y - 3);
                Program.MP.Controls.Add(textBox);


                Y += 28;
                if (Y >= (MaxY * 28) + 10)
                {
                    Y = 10;
                    X += 235;
                }

            }
        }


        private Label NewLabel(string Name, int x, int y, int CharCount)
        {
            Label label = new Label
            {
                Text = Name,
                Location = new Point(x, y),
                Name = Name + "Lbl",
                Width = (CharCount * 6)+7,
            };
            return label;
        }

        private TextBox NewTextBox(string Name, int x, int y)
        {
            TextBox textbox = new TextBox
            {
                Location = new Point(x, y),
                Name = Name + "TxtBx",
            };
            return textbox;
        }

    }
}
