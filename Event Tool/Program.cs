using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ck2ModdingTool
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        #region Vars
        //Static Forms
        public static Launch_Page LP;
            public static NwEvent NE;
                public static MoreLangs EML;
            public static NwBuilding NB;
        public static ModifiersPage MP;

        //Mod Loaded
        public static bool ModLoaded = false;
        //Debug
        public static bool DebugOn = true;
        //Mod Info
        public static string Modname;
        public static string Namespace;
        public static string Tags;
        //Paths
        public static string Ck2Path;
        public static string PicPath;
        public static string ModsFolderPath;
        public static string CurrentModFolderPath;
        public static string LocalizationDir;
        //Modifers Page Output
        public static string MPOutput;
        //More Language Vars
        public static string fr1;
        public static string fr2;
        public static string fr3;
        public static string fr4;
        public static string frdesc;
        public static string gr1;
        public static string gr2;
        public static string gr3;
        public static string gr4;
        public static string grdesc;
        public static string sp1;
        public static string sp2;
        public static string sp3;
        public static string sp4;
        public static string spdesc;
        //List Types

        public class ModInfoClass
        {
            public string ModInfoName;
            public string PicName;
            public string Tags;

            public override string ToString()
            {
                return ModInfoName + @"
" + PicName + @"
" + Tags;
            }
        }

        public class EventGroupClass
        {
            public string EventGroup;
            public int NumInGroup;

            public override string ToString()
            {
                return EventGroup + @"
" + NumInGroup;
            }
        }

        public class LocalizationList
        {
            public string Name;
            public string English;
            public string French;
            public string German;
            public string Spanish;


            public override string ToString()
            {
                return Name + ";" + English + ";" + French + ";" + German + ";;" + Spanish + ";;;;;;;;;x";
            }
        }
        public class WordList
        {
            public string Word;
        }



        //Instantiation of Lists
        public static List<ModInfoClass> ModInfo = new List<ModInfoClass>();
        public static List<EventGroupClass> EventInfo = new List<EventGroupClass>();
        public static List<LocalizationList> EventLocalizaion = new List<LocalizationList>();
        public static List<WordList> Modifiers = new List<WordList>();
        public static List<WordList> BuildingsModi = new List<WordList>();
        public static List<WordList> ArtifactModi = new List<WordList>();

        #endregion

        [STAThread]
        static void Main()
        {
            Prestart();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LP = new Launch_Page();
        Application.Run(LP);
        }

        static void Prestart()
        {
            Ck2Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paradox Interactive\Crusader Kings II";
            #region Adding Modifiers to List
            #region Full modifiers

            //Character attribute modifiers
            Modifiers.Add(new WordList() { Word = "diplomacy" });
            Modifiers.Add(new WordList() { Word = "diplomacy_penalty" });
            Modifiers.Add(new WordList() { Word = "stewardship" });
            Modifiers.Add(new WordList() { Word = "stewardship_penalty" });
            Modifiers.Add(new WordList() { Word = "martial" });
            Modifiers.Add(new WordList() { Word = "martial_penalty" });
            Modifiers.Add(new WordList() { Word = "intrigue" });
            Modifiers.Add(new WordList() { Word = "intrigue_penalty" });
            Modifiers.Add(new WordList() { Word = "learning" });
            Modifiers.Add(new WordList() { Word = "learning_penalty" });
            Modifiers.Add(new WordList() { Word = "fertility" });
            Modifiers.Add(new WordList() { Word = "fertility_penalty" });
            Modifiers.Add(new WordList() { Word = "health" });
            Modifiers.Add(new WordList() { Word = "health_penalty" });
            Modifiers.Add(new WordList() { Word = "combat_rating" });
            Modifiers.Add(new WordList() { Word = "threat_decay_speed" });
            //Realm modifiers
            Modifiers.Add(new WordList() { Word = "demesne_size" });
            Modifiers.Add(new WordList() { Word = "vassal_limit" });
            Modifiers.Add(new WordList() { Word = "global_revolt_risk" });
            Modifiers.Add(new WordList() { Word = "local_revolt_risk" });
            Modifiers.Add(new WordList() { Word = "disease_defence" });
            Modifiers.Add(new WordList() { Word = "culture_flex" });
            Modifiers.Add(new WordList() { Word = "religion_flex" });
            Modifiers.Add(new WordList() { Word = "short_reign_length" });
            Modifiers.Add(new WordList() { Word = "moved_capital_months_mult" });
            //Intrigue modifiers
            Modifiers.Add(new WordList() { Word = "assassinate_chance_modifier" });
            Modifiers.Add(new WordList() { Word = "arrest_chance_modifier" });
            Modifiers.Add(new WordList() { Word = "plot_power_modifier" });
            Modifiers.Add(new WordList() { Word = "murder_plot_power_modifier" });
            Modifiers.Add(new WordList() { Word = "defensive_plot_power_modifier" });
            Modifiers.Add(new WordList() { Word = "plot_discovery_chance" });
            //Wealth, prestige, and piety
            Modifiers.Add(new WordList() { Word = "tax_income" });
            Modifiers.Add(new WordList() { Word = "global_tax_modifier" });
            Modifiers.Add(new WordList() { Word = "local_tax_modifier" });
            //Modifiers.Add(new WordList() { Word = "<holding_type>_tax_modifier" });
            //Modifiers.Add(new WordList() { Word = "<holding_type>_vassal_tax_modifier" });
            Modifiers.Add(new WordList() { Word = "nomad_tax_modifier" });
            Modifiers.Add(new WordList() { Word = "monthly_character_prestige" });
            Modifiers.Add(new WordList() { Word = "liege_prestige" });
            Modifiers.Add(new WordList() { Word = "add_prestige_modifier" });
            Modifiers.Add(new WordList() { Word = "monthly_character_piety" });
            Modifiers.Add(new WordList() { Word = "liege_piety" });
            Modifiers.Add(new WordList() { Word = "add_piety_modifier" });
            Modifiers.Add(new WordList() { Word = "monthly_character_wealth" });
            //AI behavior modifiers
            Modifiers.Add(new WordList() { Word = "ai_rationality" });
            Modifiers.Add(new WordList() { Word = "ai_zeal" });
            Modifiers.Add(new WordList() { Word = "ai_greed" });
            Modifiers.Add(new WordList() { Word = "ai_honor" });
            Modifiers.Add(new WordList() { Word = "ai_ambition" });
            //AI construction modifiers
            Modifiers.Add(new WordList() { Word = "ai_feudal_modifier" });
            Modifiers.Add(new WordList() { Word = "ai_republic_modifier" });
            //Construction modifiers
            Modifiers.Add(new WordList() { Word = "build_cost_modifier" });
            Modifiers.Add(new WordList() { Word = "build_cost_castle_modifier" });
            Modifiers.Add(new WordList() { Word = "build_cost_city_modifier" });
            Modifiers.Add(new WordList() { Word = "build_cost_temple_modifier" });
            Modifiers.Add(new WordList() { Word = "build_cost_tribal_modifier" });
            Modifiers.Add(new WordList() { Word = "build_time_modifier" });
            Modifiers.Add(new WordList() { Word = "build_time_castle_modifier" });
            Modifiers.Add(new WordList() { Word = "build_time_city_modifier" });
            Modifiers.Add(new WordList() { Word = "build_time_temple_modifier" });
            Modifiers.Add(new WordList() { Word = "build_time_tribal_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_cost_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_cost_castle_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_cost_city_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_cost_temple_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_cost_tribal_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_time_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_time_castle_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_time_city_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_time_temple_modifier" });
            Modifiers.Add(new WordList() { Word = "local_build_time_tribal_modifier" });
            //Opinion modifiers
            Modifiers.Add(new WordList() { Word = "ambition_opinion" });
            Modifiers.Add(new WordList() { Word = "vassal_opinion" });
            Modifiers.Add(new WordList() { Word = "sex_appeal_opinion" });
            Modifiers.Add(new WordList() { Word = "same_opinion" });
            Modifiers.Add(new WordList() { Word = "same_opinion_if_same_religion" });
            Modifiers.Add(new WordList() { Word = "opposite_opinion" });
            Modifiers.Add(new WordList() { Word = "liege_opinion" });
            Modifiers.Add(new WordList() { Word = "general_opinion" });
            Modifiers.Add(new WordList() { Word = "twin_opinion" });
            Modifiers.Add(new WordList() { Word = "dynasty_opinion" });
            Modifiers.Add(new WordList() { Word = "male_dynasty_opinion" });
            Modifiers.Add(new WordList() { Word = "female_dynasty_opinion" });
            Modifiers.Add(new WordList() { Word = "child_opinion" });
            Modifiers.Add(new WordList() { Word = "oldest_child_opinion" });
            Modifiers.Add(new WordList() { Word = "youngest_child_opinion" });
            Modifiers.Add(new WordList() { Word = "spouse_opinion" });
            //Modifiers.Add(new WordList() { Word = "<religion>_opinion" });
            //Modifiers.Add(new WordList() { Word = "<religion_group>_opinion" });
            Modifiers.Add(new WordList() { Word = "same_religion_opinion" });
            Modifiers.Add(new WordList() { Word = "infidel_opinion" });
            Modifiers.Add(new WordList() { Word = "christian_opinion" });
            Modifiers.Add(new WordList() { Word = "christian_church_opinion" });
            Modifiers.Add(new WordList() { Word = "church_opinion" });
            Modifiers.Add(new WordList() { Word = "temple_opinion" });
            Modifiers.Add(new WordList() { Word = "temple_all_opinion" });
            Modifiers.Add(new WordList() { Word = "town_opinion" });
            Modifiers.Add(new WordList() { Word = "city_opinion" });
            Modifiers.Add(new WordList() { Word = "castle_opinion" });
            Modifiers.Add(new WordList() { Word = "feudal_opinion" });
            Modifiers.Add(new WordList() { Word = "tribal_opinion" });
            Modifiers.Add(new WordList() { Word = "unreformed_tribal_opinion" });
            Modifiers.Add(new WordList() { Word = "rel_head_opinion" });
            Modifiers.Add(new WordList() { Word = "free_invest_vassal_opinion" });
            Modifiers.Add(new WordList() { Word = "clan_sentiment" });
            //Warfare modifiers
            Modifiers.Add(new WordList() { Word = "levy_size" });
            //Modifiers.Add(new WordList() { Word = "<holding_type>_levy_size" });
            Modifiers.Add(new WordList() { Word = "global_levy_size" });
            Modifiers.Add(new WordList() { Word = "levy_reinforce_rate" });
            //Modifiers.Add(new WordList() { Word = "<unit>" });
            //Modifiers.Add(new WordList() { Word = "<unit>_max_levy" });
            //Modifiers.Add(new WordList() { Word = "<unit>_min_levy" });
            //Modifiers.Add(new WordList() { Word = "<unit>_offensive" });
            //Modifiers.Add(new WordList() { Word = "<unit>_defensive" });
            //Modifiers.Add(new WordList() { Word = "<unit>_morale" });
            //Modifiers.Add(new WordList() { Word = "<holding_type>_vassal_min_levy" });
            //Modifiers.Add(new WordList() { Word = "<holding_type>_vassal_max_levy" });
            Modifiers.Add(new WordList() { Word = "land_morale" });
            Modifiers.Add(new WordList() { Word = "land_organisation" });
            Modifiers.Add(new WordList() { Word = "regiment_reinforcement_speed" });
            Modifiers.Add(new WordList() { Word = "garrison_size" });
            Modifiers.Add(new WordList() { Word = "global_garrison_size" });
            Modifiers.Add(new WordList() { Word = "garrison_growth" });
            Modifiers.Add(new WordList() { Word = "fort_level" });
            Modifiers.Add(new WordList() { Word = "global_defensive" });
            Modifiers.Add(new WordList() { Word = "land" });
            Modifiers.Add(new WordList() { Word = "global_supply_limit" });
            Modifiers.Add(new WordList() { Word = "global_winter_supply" });
            Modifiers.Add(new WordList() { Word = "supply_limit" });
            Modifiers.Add(new WordList() { Word = "max_attrition" });
            Modifiers.Add(new WordList() { Word = "siege_defence" });
            Modifiers.Add(new WordList() { Word = "siege_speed" });
            Modifiers.Add(new WordList() { Word = "global_movement_speed" });
            Modifiers.Add(new WordList() { Word = "local_movement_speed" });
            Modifiers.Add(new WordList() { Word = "galleys_perc" });
            Modifiers.Add(new WordList() { Word = "retinuesize" });
            Modifiers.Add(new WordList() { Word = "retinuesize_perc" });
            Modifiers.Add(new WordList() { Word = "retinue_maintenence_cost" });
            Modifiers.Add(new WordList() { Word = "horde_maintenence_cost" });
            //Technology modifiers
            Modifiers.Add(new WordList() { Word = "tech_growth_modifier" });
            Modifiers.Add(new WordList() { Word = "commander_limit" });
            //Modifiers.Add(new WordList() { Word = "tech_growth_modifier_<tech_type>" });
            //Modifiers.Add(new WordList() { Word = "<tech_type>_techpoints" });
            //Trade modifiers
            Modifiers.Add(new WordList() { Word = "max_tradeposts" });
            Modifiers.Add(new WordList() { Word = "tradevalue" });
            Modifiers.Add(new WordList() { Word = "trade_route_wealth" });
            Modifiers.Add(new WordList() { Word = "trade_route_value" });
            Modifiers.Add(new WordList() { Word = "global_trade_route_wealth" });
            Modifiers.Add(new WordList() { Word = "global_trade_route_value" });
            Modifiers.Add(new WordList() { Word = "global_tradevalue" });
            Modifiers.Add(new WordList() { Word = "global_tradevalue_mult" });
            //Population modifiers
            Modifiers.Add(new WordList() { Word = "population_growth" });
            Modifiers.Add(new WordList() { Word = "manpower_growth" });
            Modifiers.Add(new WordList() { Word = "max_population_mult" });
            Modifiers.Add(new WordList() { Word = "max_manpower_mult" });
            Modifiers.Add(new WordList() { Word = "max_population" });

            #endregion



            #region Adding to Building Modi


            //for now just copy full list
            BuildingsModi = Modifiers;

            #endregion
            #region Adding to Artifact Modi
            #endregion
            #region Adding to ?? Modi
            #endregion
            #region Adding to ?? Modi
            #endregion
            #region Adding to ?? Modi
            #endregion
            #endregion

            //debug
            if (DebugOn)
            {
                
                Ck2Path = Ck2Path + @"\MOD-TOOL-DEBUG";
            }
            ModsFolderPath = Ck2Path + @"\mod";
            //MessageBox.Show(Ck2Path, "No Data Entered", MessageBoxButtons.OK);

        }


        #region New/Save/Load Mod Info

        static public void Makenamespace()
        {
            int length = 5;
            if (Modname.Length < 5)
            {
                length = Modname.Length;
            }
            Namespace = Modname.Substring(0, length);
            Namespace = Namespace.Replace(" ", "");
        }

        static public void NewMod(bool Overwrite)
        {
            string ModFileName = Modname + @".mod";
            CurrentModFolderPath = ModsFolderPath + @"\" + Modname;
            LocalizationDir = CurrentModFolderPath + @"\localisation";

            // creating mod/Modname folder
            if (!Overwrite)
            {
                Reader.CreateFolder(CurrentModFolderPath);
            }
            // Creating mod/Modname.mod File
            if (!Overwrite)
            {
                Reader.CreateFile(ModsFolderPath, ModFileName);
            }
            Reader.SaveFileSting(CurrentModFolderPath + ".mod", MakeModfile(),false,0);

            // Creating ModInfo File
            MakeModInfo();
            if (!Overwrite)
            {
                Reader.CreateFile(CurrentModFolderPath, "ModInfo.xml");
            }
            string ModInfoPath = CurrentModFolderPath + @"\ModInfo.xml";
            Reader.SaveModInfo(ModInfoPath, ModInfo);

            ModLoaded = true;
            MessageBox.Show("Mod Created", "Debug", MessageBoxButtons.OK);
        }

        static public string MakeModfile()
        {
            string ModFile;
            ModFile = @"name=""" + Modname + @"""";
            ModFile = ModFile + @"
path=""mod\" + Modname + @"""";
            if (Tags != "")
            {
                ModFile = ModFile + @"
tags=""" + Tags + @"""";
            }
            if (PicPath != null)
            {
                ModFile = ModFile + @"
picture=""" + PicPath + @"""";
            }


            MessageBox.Show(ModFile, "Debug", MessageBoxButtons.OK);
            return ModFile;
        }

        static public void MakeModInfo()
        {
            ModInfo.Clear();
            ModInfo.Add(new ModInfoClass
            {
                ModInfoName = Modname,
                Tags = Tags,
                PicName = PicPath
            });
        }

        static public void LoadModinfo()
        {
            
            Reader.LoadModInfo();

            //Mod Name
            Modname = ModInfo[0].ModInfoName;
            LP.ModNameText.Text = Modname;
            //Pic Path
            PicPath = ModInfo[0].PicName;
            //Tags
            Tags = ModInfo[0].Tags;
            LP.TagText.Text = Tags;
            //Mod Paths
            CurrentModFolderPath = ModsFolderPath + @"\" + Modname;
            LocalizationDir = CurrentModFolderPath + @"\localisation";

            ModLoaded = true;
        }

        static public void SaveEventGroups ()
        {
            Reader.CreateFileIfNotExist(CurrentModFolderPath + @"\events", "Event-Groups.xml");
            Reader.SaveEventInfo(CurrentModFolderPath + @"\events\Event-Groups.xml", EventInfo);
        }

        #endregion

        #region Modifiers list






        #endregion

    }
}
