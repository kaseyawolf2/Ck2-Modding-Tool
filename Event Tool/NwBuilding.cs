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

        //Only show modifiers needed
        public List<Program.WordList> ModifiersToShow = Program.BuildingsModi;
        //Modifiers String
        public string ModifiersString;


        private void SaveBt_Click(object sender, EventArgs e)
        {
            if (CheckRequiments())
            {
                return;
            }

            string FileName = Program.Namespace + "_" + HoldingCB.Text + ".txt";
            Reader.CreateFileIfNotExist(Program.CurrentModFolderPath + @"\common\buildings", FileName);

            #region Building String
            string BuildingStr;
            //Required
            BuildingStr = HoldingCB.SelectedText + @" = {
    " + BuildingNameText.Text + @" = {
        " + "desc = " + BuildingNameText.Text + @"_desc
        " + "trigger = {" + TrigText.Text + "}" + @"
        " + "potential = {" + PotentialText.Text + "}" + @"
        " + "build_time = " + BuildTimeText.Text +  @"
        " + "ai_creation_factor = " + AiCreationFactorText.Text + @"
        ";
            //needs one
            if (GoldCostText.Text != "") {
                BuildingStr += "gold_cost = " + GoldCostText.Text + @"
        ";
            }
            if (PrestigeCostText.Text != "")
            {
                BuildingStr += "prestige_cost = " + PrestigeCostText.Text + @"
        ";
            }


            //non manditory
            if (PortChck.Checked)
            {
                BuildingStr += "port = yes" + @"
        ";
            }
            if (PreReqText.Text != "")
            {
                BuildingStr += "prerequisites = " + PreReqText.Text + @"
        ";
            }
            if (NotXText.Text != "")
            {
                BuildingStr += "not_if_x_exists = {" + NotXText.Text + @"}
        ";
            }
            if (AddNumberChck.Checked)
            {
                BuildingStr += "add_number_to_name = yes" + @"
        ";
            }
            if (ReplaceText.Text != "")
            {
                BuildingStr += "replaces = " + ReplaceText.Text + @"
        ";
            }
            if (ActiveTrigText.Text != "")
            {
                BuildingStr += "is_active_trigger = " + ActiveTrigText.Text + @"
        ";
            }
            if (UpgradeText.Text != "")
            {
                BuildingStr += "upgrades_from = " + UpgradeText.Text + @"
        ";
            }
            if (AiFeudalModifierText.Text != "")
            {
                BuildingStr += "ai_feudal_modifier = " + AiFeudalModifierText.Text + @"
        ";
            }
            if (AiRepublicModifierText.Text != "")
            {
                BuildingStr += "ai_republic_modifier = " + AiRepublicModifierText.Text + @"
        ";
            }
            if (ReplaceText.Text != "")
            {
                BuildingStr += "replaces = " + ReplaceText.Text + @"
        ";
            }
            if (ExtraTechText.Text != "")
            {
                BuildingStr += "extra_tech_building_start = " + ExtraTechText.Text + @"
        ";
            }
            if (ScoutingChck.Checked)
            {
                BuildingStr += "scouting = yes" + @"
        ";
            }
            if (CityConvertText.Text != "")
            {
                BuildingStr += "convert_to_city = " + CityConvertText.Text + @"
        ";
            }
            if (CastleConvertText.Text != "")
            {
                BuildingStr += "convert_to_castle = " + CastleConvertText.Text + @"
        ";
            }
            if (TempleConvertText.Text != "")
            {
                BuildingStr += "convert_to_temple = " + TempleConvertText.Text + @"
        ";
            }
            if (TribalConvertText.Text != "")
            {
                BuildingStr += "convert_to_tribal = " + TribalConvertText.Text + @"
        ";
            }


            if (ModifiersString != "")
            {
                BuildingStr += ModifiersString; 
            }
            BuildingStr += @"
    }
}";
            #endregion

            
            Reader.SaveFileSting(Program.CurrentModFolderPath + @"\common\buildings\" + FileName, BuildingStr, true, 2);
        }

        private bool CheckRequiments()
        {
            bool TF = true;
            string missing = "Missing : ";

            if (HoldingCB.Text == "")
            {
                missing += "Holding Type, ";
                TF = false;
            }
            if (BuildingNameText.Text == "")
            {
                missing += "Building Name, ";
                TF = false;
            }
            if (DescText.Text == "")
            {
                missing += "Description, ";
                TF = false;
            }
            if (TrigText.Text == "")
            {
                missing += "Trigger, ";
                TF = false;
            }
            if (PotentialText.Text == "")
            {
                missing += "Potential, ";
                TF = false;
            }
            if (BuildTimeText.Text == "")
            {
                missing += "Build Time, ";
                TF = false;
            }
            if (AiCreationFactorText.Text == "")
            {
                missing += "Ai Creation Factor, ";
                TF = false;
            }
            if (GoldCostText.Text == "" && PrestigeCostText.Text == "")
            {
                missing += "Gold or Prestige Cost ";
                TF = false;
            }


            
            if (TF == false)
            {
                MessageBox.Show(missing, "Missing Data", MessageBoxButtons.OK);
            }
            return !TF;
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
            ModiText.Text = Program.MPOutput;
        }





    }
}
