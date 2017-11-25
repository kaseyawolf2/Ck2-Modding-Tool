using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ck2ModdingTool
{
    public partial class NwEvent : Form
    {
        public NwEvent()
        {
            InitializeComponent();
        }


        string NameSpaceText = Program.Namespace;

        private void Save_Click(object sender, EventArgs e)
        {
            if (Requiredinfo())
            {
                MessageBox.Show("Please Enter a Namespace, Id, Event Group, and Event Type", "No Data Entered", MessageBoxButtons.OK);
                return;
            }
            


            Reader.CreateFileIfNotExist(Program.CurrentModFolderPath + @"\events", EveGroupBox.Text + ".txt");

            string dir = Program.CurrentModFolderPath + @"\events\" + EveGroupBox.Text + ".txt";
            //Save Event
            Reader.SaveFileSting(dir, ParseEvent(),true,0);
            Program.EventInfo.Find(x => x.EventGroup == EveGroupBox.Text).NumInGroup ++;

            //Adding Localization
            #region Building Localization
            Program.EventLocalizaion = new List<Program.LocalizationList>
                {
                    //add description to localization
                    new Program.LocalizationList
                    {
                        Name = "EVTDESC" + NameSpaceText + "." + IdText.Text,
                        English = DescText.Text,
                        French = Program.frdesc,
                        German = Program.grdesc,
                        Spanish = Program.spdesc
                    }
                };
            if (Opt1BtText.Text != "Button Text")
            {
                Program.EventLocalizaion.Add(new Program.LocalizationList
                {
                    Name = "EVTOPTA" + NameSpaceText + "." + IdText.Text,
                    English = Opt1BtText.Text,
                    French = Program.fr1,
                    German = Program.gr1,
                    Spanish = Program.sp1
                });
            }
            if (Opt2BtText.Text != "Button Text")
            {
                Program.EventLocalizaion.Add(new Program.LocalizationList
                {
                    Name = "EVTOPTB" + NameSpaceText + "." + IdText.Text,
                    English = Opt2BtText.Text,
                    French = Program.fr2,
                    German = Program.gr2,
                    Spanish = Program.sp2
                });
            }
            if (Opt3BtText.Text != "Button Text")
            {
                Program.EventLocalizaion.Add(new Program.LocalizationList
                {
                    Name = "EVTOPTC" + NameSpaceText + "." + IdText.Text,
                    English = Opt3BtText.Text,
                    French = Program.fr3,
                    German = Program.gr3,
                    Spanish = Program.sp3
                });
            }
            if (Opt4BtText.Text != "Button Text")
            {
                Program.EventLocalizaion.Add(new Program.LocalizationList
                {
                    Name = "EVTOPTD" + NameSpaceText + "." + IdText.Text,
                    English = Opt4BtText.Text,
                    French = Program.fr4,
                    German = Program.gr4,
                    Spanish = Program.sp4
                });
            }
            #endregion

            dir = Program.LocalizationDir + @"\" + EveGroupBox.Text + ".csv";
            Reader.CreateFileIfNotExist(Program.LocalizationDir, EveGroupBox.Text + ".csv");
            Reader.SaveLoc(dir, Program.EventLocalizaion);

            //Saving Event Groups
            Program.SaveEventGroups();

        }

        private void ParseBT_Click(object sender, EventArgs e)
        {
            if (Requiredinfo())
            {
                MessageBox.Show("Please Enter a Namespace, Id, Event Group, and Event Type", "No Data Entered", MessageBoxButtons.OK);
                return;
            }

            Output FRM = new Output();
            FRM.OutputText.Text = ParseEvent();
            FRM.Show();
        }

        public bool Requiredinfo()
        {
            if (NameSpaceText == "")
            {
                return true;
            }
            if (IdText.Text == "")
            {
                return true;
            }
            if (EveTypeBox.Text == "")
            {
                return true;
            }
            if (EveGroupBox.Text == "")
            {
                return true;
            }


            return false;
        }


        public string ParseEvent()
        {
            string Event_String;
            string[] Formatinfo = new string[22];
            //{0} = Namespace
            Formatinfo[0] = NameSpaceText;
            //{1} = Event type
            Formatinfo[1] = EveTypeBox.Text;
            //{2} = Id
            Formatinfo[2] = IdText.Text;
            //{3} = Fast Trggers
            Formatinfo[3] = FastTrigText.Text;
            //{4} = Trigger
            Formatinfo[4] = TrigText.Text;
            //{5} = Mean Time
            Formatinfo[5] = MeanText.Text;
            //{6} = immediate
            Formatinfo[6] = ImmText.Text;
            //{7} = opt1 trig
            Formatinfo[7] = Opt1TrigText.Text;
            //{8} = opt1 ai chan
            Formatinfo[8] = Opt1AiChanText.Text;
            //{9} = opt 1 command
            Formatinfo[9] = Option1Text.Text;
            //{10} = opt2 trig
            Formatinfo[10] = Opt2TrigText.Text;
            //{11} = opt2 ai chan
            Formatinfo[11] = Opt2AiChanText.Text;
            //{12} = opt2 command
            Formatinfo[12] = Option2Text.Text;
            //{13} = opt3 trig
            Formatinfo[13] = Opt3TrigText.Text;
            //{14} = opt3 ai chan
            Formatinfo[14] = Opt3AiChanText.Text;
            //{15} = opt3 command
            Formatinfo[15] = Option3Text.Text;
            //{16} = opt4 trig
            Formatinfo[16] = Opt4TrigText.Text;
            //{17} = opt4 ai chan
            Formatinfo[17] = Opt4AiChanText.Text;
            //{18} = opt4 command
            Formatinfo[18] = Option4Text.Text;
            //{19} = After Commands
            Formatinfo[19] = AfterText.Text;
            //{20} = Picture
            Formatinfo[20] = PictureText.Text;
            //{21} = Border
            Formatinfo[21] = BorderText.Text;



            Event_String = @"{1} = {{
    id = {0}.{2}
    desc = EVTDESC{0}.{2}";
            Reader.LoadEventInfo();
            if (Program.EventInfo.Find(x => x.EventGroup == EveGroupBox.SelectedText).NumInGroup == 0)
            {
                string Nms = @"namespace = {0}
";
                Event_String = Nms + Event_String;
            }

            if (PictureText.Text != "")
            {
                string Pic = @"
picture = {20}";
                Event_String = Event_String + Pic;
            }

            if (BorderText.Text != "")
            {
                string Brd = @"
border = {21}";
                Event_String = Event_String + Brd;
            }





            if (HideWindow.Checked)
            {
                string hid = @"
    hide_window = yes";
                Event_String = Event_String + hid;
            }


            if (FastTrigText.Text != "")
            {
                string fst = @"


    #Fast event triggers/Flags
{3}";
                Event_String = Event_String + fst;
            }
            if (TrigText.Text != "")
            {
                string trg = @"
    trigger = {{
{4}
    }}";
                Event_String = Event_String + trg;
            }
            if (MeanText.Text != "")
            {
                string men = @"
    mean_time_to_happen = {{
{5}
    }}";
                Event_String = Event_String + men;
            }
            if (ImmText.Text != "")
            {
                string imm = @"
    immediate = {{
{6}
    }}";
                Event_String = Event_String + imm;
            }
            if (Option1Text.Text != "")
            {
                string opt1str = @"
    option = {{
        name = EVTOPTA{0}.{2}";
                if (Opt1TrigText.Text != "")
                {
                    string opt1trg = @"
        trigger = {{
{7}
        }}";
                    opt1str = opt1str + opt1trg;
                }
                if (Opt1AiChanText.Text != "")
                {
                    string opt1ai = @" 
        ai_chance = {{
{8}
        }}";
                    opt1str = opt1str + opt1ai;
                }
                opt1str = opt1str + @"
{9}
    }}";
                Event_String = Event_String + opt1str;
            }

            if (Option2Text.Text != "")
            {
                string opt2str = @"
    option = {{
        name = EVTOPTB{0}.{2}";
                if (Opt2TrigText.Text != "")
                {
                    string opt2trg = @"
        trigger = {{
{10}
        }}";
                    opt2str = opt2str + opt2trg;
                }
                if (Opt2AiChanText.Text != "")
                {
                    string opt2ai = @" 
        ai_chance = {{
{11}
        }}";
                    opt2str = opt2str + opt2ai;
                }
                opt2str = opt2str + @"
{12}
    }}";
                Event_String = Event_String + opt2str;
            }

            if (Option3Text.Text != "")
            {
                string opt3str = @"
    option = {{
        name = EVTOPTC{0}.{2}";
                if (Opt3TrigText.Text != "")
                {
                    string opt3trg = @"
        trigger = {{
{13}
        }}";
                    opt3str = opt3str + opt3trg;
                }
                if (Opt3AiChanText.Text != "")
                {
                    string opt3ai = @" 
        ai_chance = {{
{14}
        }}";
                    opt3str = opt3str + opt3ai;
                }
                opt3str = opt3str + @"
{15}
    }}";
                Event_String = Event_String + opt3str;
            }

            if (Option4Text.Text != "")
            {
                string opt4str = @"
    option = {{
        name = EVTOPTD{0}.{2}";
                if (Opt4TrigText.Text != "")
                {
                    string opt4trg = @"
        trigger = {{
{16}
        }}";
                    opt4str = opt4str + opt4trg;
                }
                if (Opt4AiChanText.Text != "")
                {
                    string opt4ai = @" 
        ai_chance = {{
{17}
        }}";
                    opt4str = opt4str + opt4ai;
                }
                opt4str = opt4str + @"
{18}
    }}";
                Event_String = Event_String + opt4str;
            }


            if (AfterText.Text != "")
            {
                string aft = @"
    after = {{
{19}
    }}";
                Event_String = Event_String + aft;
            }
            Event_String = Event_String + @"
}}";







            Event_String = string.Format(Event_String, Formatinfo);
            return Event_String;
        }

        private void MoreLangs_Click(object sender, EventArgs e)
        {
            Program.ML = new MoreLangs();
            Program.ML.EnglishText.Text = DescText.Text;
            Program.ML.Eng1.Text = Opt1BtText.Text;
            Program.ML.Eng2.Text = Opt2BtText.Text;
            Program.ML.Eng3.Text = Opt3BtText.Text;
            Program.ML.Eng4.Text = Opt4BtText.Text;
            Program.ML.Show();
        }
        public static void UpdateFromLoc()
        {

        }

        private void NewEveGroupBt_Click(object sender, EventArgs e)
        {
            New_Event_Group NwGroup = new New_Event_Group();
            NwGroup.Show();
        }

        private void NwEventBt_Click(object sender, EventArgs e)
        {
            if (EveGroupBox.Text == "")
            {
                MessageBox.Show("Please Select a Event Group", "No Data Entered", MessageBoxButtons.OK);
                return;
            }
            IdText.Text = Program.EventInfo.Find(x => x.EventGroup == EveGroupBox.Text).NumInGroup.ToString();
            

        }

        private void RenameGroupBt_Click(object sender, EventArgs e)
        {
            Rename_Group ReGroup = new Rename_Group();
            ReGroup.SelBox.Items.Clear();
            foreach (var item in Program.EventInfo)
            {
                ReGroup.SelBox.Items.Add(item.EventGroup.ToString());
            }
            ReGroup.Show();
        }

    }
}
