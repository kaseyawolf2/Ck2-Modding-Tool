using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Tool
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        #region Vars
        //Static Forms
        public static Launch_Page LP;
        public static MoreLangs EML;
        //Mod Loaded
        public static bool ModLoaded = false;
        //Debug
        public static bool DebugOn = false;
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



        //Instantiation of Lists
        public static List<ModInfoClass> ModInfo = new List<ModInfoClass>();
        public static List<EventGroupClass> EventInfo = new List<EventGroupClass>();
        public static List<LocalizationList> EventLocalizaion = new List<LocalizationList>();
        #endregion

        [STAThread]
        static void Main()
        {
            Prestart();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LP = new Launch_Page();
            EML = new MoreLangs();
            Application.Run(LP);
        }

        static void Prestart()
        {
            Ck2Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paradox Interactive\Crusader Kings II";


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
            Reader.SaveFileSting(CurrentModFolderPath + ".mod", MakeModfile(),false);

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



    }
}
