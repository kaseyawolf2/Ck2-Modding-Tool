using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Event_Tool
{
    public class Reader
    {
        // Use this for initialization
        #region Mod Info
                public static void LoadModInfo()
                {
                    //prevents the folder path being spamed with files if there is no file there
                    string dir = Program.ModsFolderPath + @"\" + Program.Modname + @"\ModInfo.xml";  
                    if (File.Exists(dir))
                    {
                        Program.ModInfo.Clear();
                        using (StreamReader sr = new StreamReader(dir))
                        {                    
                            Program.ModInfo.Add(new Program.ModInfoClass { ModInfoName = sr.ReadLine() });                    
                            Program.ModInfo[0].PicName = sr.ReadLine();                   
                            Program.ModInfo[0].Tags = sr.ReadLine();                  
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No File Path Found");
                        return;
                    }
                }

                public static void SaveModInfo(string dir, List<Program.ModInfoClass> list)
                {
                    if (File.Exists(dir))
                    {
                        using (StreamWriter sw = new StreamWriter(dir))
                        {
                            foreach (Program.ModInfoClass C in list)
                            {
                                sw.WriteLine(C.ToString());
                            }
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No File Path Found");
                        return;
                    }
                }
                #endregion

        #region Event Info
        public static void LoadEventInfo()
        {
            //prevents the folder path being spamed with files if there is no file there
            string dir = Program.CurrentModFolderPath + @"\events\Event-Groups.xml";
            if (File.Exists(dir))
            {
                
                using (StreamReader sr = new StreamReader(dir))
                {
                    string ign = sr.ReadLine();
                    int X = int.Parse(sr.ReadLine());
                    System.Diagnostics.Debug.WriteLine(ign + " : " + X);
                    if (X == 0)
                    {
                        return;
                    }

                    Program.EventInfo.Clear();
                    for (int i = 0; i < (X); i++)
                    {
                        Program.EventInfo.Add(new Program.EventGroupClass { EventGroup = sr.ReadLine() });
                        Program.EventInfo[i].NumInGroup = int.Parse(sr.ReadLine());
                        System.Diagnostics.Debug.WriteLine(Program.EventInfo[i].ToString());
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No File Path Found");
                return;
            }
        }

        public static void SaveEventInfo(string dir, List<Program.EventGroupClass> list)
        {
            if (File.Exists(dir))
            {
                using (StreamWriter sw = new StreamWriter(dir))
                {
                    sw.WriteLine("# of Event Groups");
                    sw.WriteLine(list.Count.ToString());
                    foreach (Program.EventGroupClass C in list)
                    {
                        sw.WriteLine(C.ToString());
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No File Path Found");
                return;
            }
        }
        #endregion

        #region Building Info

#endregion

        #region Localization
        public static void SaveLoc(string dir,List<Program.LocalizationList> list)
        {
            if (File.Exists(dir))
            {
                using (StreamWriter sw = new StreamWriter(dir,true))
                {
                    foreach (Program.LocalizationList C in list)
                    {
                        sw.WriteLine(C.ToString());
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No File Path Found");
                return;
            }
        }

        #endregion

        public static void CreateFileIfNotExist(string PathOfFolderItsIn, string FileName)
        {
            if (!File.Exists(PathOfFolderItsIn))
            {
                CreateFile(PathOfFolderItsIn, FileName);
            }
        }


        public static void SaveFileSting(string dir, string FileSting,bool AppendToEnd)
        {
            if (File.Exists(dir))
            {
                using (StreamWriter sw = new StreamWriter(dir, AppendToEnd))
                {
                    sw.WriteLine(FileSting);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No File Path Found");
                return;
            }
        }

        public static void CreateFile(string PathOfFolderItsIn, string FileName)
        {
            PathOfFolderItsIn = PathOfFolderItsIn + @"\" + FileName;
            if (!File.Exists(PathOfFolderItsIn))
            {
                using (StreamWriter sw = new StreamWriter(PathOfFolderItsIn))
                {
                    sw.Write("");
                }
            }
        }
        public static void CreateFolder(string Path)
        {
            Directory.CreateDirectory(Path);
        }
    }
}
