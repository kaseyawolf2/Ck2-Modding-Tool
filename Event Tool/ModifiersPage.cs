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
        //vars
        //ints
        int NumCol;
        int Offset = 0;
        //Current List of Modifiers
        public List<Program.WordList> Modifiers;

        public ModifiersPage(List<Program.WordList> ModifiersToShow)
        {
            Modifiers = ModifiersToShow;
            InitializeComponent();
        }
            
        private void ModifiersPage_ResizeEnd(object sender, EventArgs e)
        {
            Program.MP.Controls.Clear();
            NumCol = (Modifiers.Count / (Program.MP.Height / 30)) + 1;
            DrawModifiers(Modifiers,Offset);
            DrawBt();
            Program.MP.Refresh();
        }
        

        public void DrawBt()
        {
            Button Okbutton = new Button { Text = "Save", Name = "SaveBt", Location = new Point(Program.MP.Size.Width - 95, Program.MP.Size.Height - 65) };
            Okbutton.Click += new EventHandler(SaveBt_Click);
            Program.MP.Controls.Add(Okbutton);
            NumCol = (Modifiers.Count / (Program.MP.Height / 30)) + 1;
            HScrollBar bar = new HScrollBar { Width = Program.MP.Size.Width - 150,Location = new Point( 10, Program.MP.Size.Height-55),Name = "ScrollBar1",Maximum = NumCol * 200, Minimum = 0,LargeChange = 100 };
            bar.DockChanged += new EventHandler(ScrollBar1_Update);
            Program.MP.Controls.Add(bar);
        }

        private void SaveBt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shit", "No Data Entered", MessageBoxButtons.OK);
        }

        private void ScrollBar1_Update(object sender, EventArgs e)
        {
            MessageBox.Show("Shit", "No Data Entered", MessageBoxButtons.OK);
            HScrollBar bar = (HScrollBar)sender;
            Offset = bar.Value;
            Program.MP.Controls.Clear();
            NumCol = (Modifiers.Count / (Program.MP.Height / 30)) + 1;
            DrawModifiers(Modifiers, Offset);
            DrawBt();
            Program.MP.Refresh();
        }

        public void DrawModifiers(List<Program.WordList> list, int offset)
        {
            int MaxY = Program.MP.Height / 30;


            int Y = 10;
            int X = -75;
            foreach (var item in list)
            {
                Label label = NewLabel(item.Word, X, Y);



                TextBox textBox = NewTextBox(item.Word, 10 + X + label.Width, Y - 3);


                Program.MP.Controls.Add(label);
                Program.MP.Controls.Add(textBox);


                Y += 28;
                if (Y >= (MaxY * 28) - 20)
                {
                    Y = 10;
                    X += 335;
                }

            }

        }

        private Label NewLabel(string Name, int x, int y)
        {
            Label label = new Label
            {
                Text = Name,
                Name = Name + "Lbl",
                Location = new Point(x, y),
                TextAlign = ContentAlignment.TopRight,
                Width = 200
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
