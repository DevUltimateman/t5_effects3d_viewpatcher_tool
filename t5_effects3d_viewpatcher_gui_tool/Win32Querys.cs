using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.WebRequestMethods;

namespace t5_effects3d_viewpatcher_gui_tool
{
    internal class Win32Querys
    {
        //GLOBALS
        public string BO_ROOT; //black ops root folder
        public string BO_ROOT_BIN_FOLDER; //blackops bin root folder
        public string BO_ROOT_BACKUP_INI_FILE; //backup ini file path

        public string fxViewerExe = "effectsed3.exe"; //fx3d exe
        public string fxViewerIni = "EffectsEd3--.ini"; //fx3d ini file we modify with the new paths to the assets
        DateTime dates = new DateTime();

        //Launch the fx3d viewer method
        public void LaunchFxViewer()
        {
            //MessageBox.Show("Trying to open fx3d next debug");
            if( BO_ROOT == null || BO_ROOT == "")
            {
                MessageBox.Show("Please select the Black Ops root folder first.");
                return;
            }

            string effects3dPath = Path.Combine(BO_ROOT, "bin\\");
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.UseShellExecute = true;
            pi.FileName = fxViewerExe;
            pi.WorkingDirectory = effects3dPath;
            //MessageBox.Show(pi.WorkingDirectory);
            MessageBox.Show("Launching Effects3D Viewer...");
            Process.Start(pi);
        }

        public void GetBlackOpsRootFolder()
        {
            OpenFolderDialog fs_open = new OpenFolderDialog
            {
                Title = "Select the Black Ops Root Folder"
            };

            //open the dialog window
            bool? ok = fs_open.ShowDialog();  // call once

            //we select a folder and click
            if (ok == true)
            {
                Console.WriteLine("Folder selected successfully.");
                string rootFolder = fs_open.FolderName;
                Console.WriteLine($"Selected path: {rootFolder}");
                MessageBox.Show("Black Ops Root Folder Selected as:\n" + rootFolder);
                BO_ROOT = rootFolder;

                string effects3dPath = Path.Combine(rootFolder, "bin\\");
                string effects3dFile = effects3dPath + "\\EffectsEd3--.ini";
                //MessageBox.Show("EFFECTS3D PATH?? = " + effects3dFile);
            }


            //we didnt select a folder and click cancel or close the dialog
            else if (ok == false)
            {
                MessageBox.Show("No folder selected.!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("No folder selected.");
                return;
            }
        }

        public string PassTheFolder(string folderPath)
        {
            return folderPath;
        }


        public void MakeBackUpOfIni()
        {
            //we must check if user has selected the black ops root folder first before we can make a backup of the ini file
            if ( BO_ROOT == null || BO_ROOT == "")
            {
                MessageBox.Show("Please select the Black Ops root folder first.");
                return;
            }

            else
            {
                //dummy paths for testing
                string dummyPath = Path.Combine(BO_ROOT, "bin\\EffectsEd3--.inis");

                string originalPath = Path.Combine(BO_ROOT, "bin\\EffectsEd3--.ini");
                string backupPath = Path.Combine(BO_ROOT, "bin\\EffectsEd3--.ini_backup_");
                try
                {
                    //check if effectsed3.ini file exists
                    if (System.IO.File.Exists(originalPath)) 
                    {
                        //grab the current date and time to append to the backup file name so we dont overwrite the old backup file
                        var timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                        System.IO.File.Copy(originalPath, backupPath + timeStamp);
                        BO_ROOT_BACKUP_INI_FILE = backupPath + timeStamp;
                        MessageBox.Show("Backup file already exists.\nCreating a new backup file at:\n" + BO_ROOT_BACKUP_INI_FILE );
                    }
                    else if( !System.IO.File.Exists(originalPath))
                    {
                        //Write default file settings to the ini file if one doesn't exist.
                        System.IO.File.WriteAllText(originalPath,
                           "[Mru]\n\n" +
                           "[Settings]\n" +
                           "PseudoEngine DrawAxes = 1\n" +
                           "PseudoEngine DrawWireframe = 0\n" +
                            "PseudoEngine ShowDistance = 1\n" +
                            "PseudoEngine ShowInfo = 0\n" +
                            "PseudoEngine ShowTimeLeft = 1\n" +
                            "Effect CameraLod 0 = 0\n" +
                            "Effect CameraLod 1 = 0\n" +
                            "Effect CameraLod 2 = 0\n" +
                            "Effect CameraLod 3 = 0\n" +
                            "PseudoEngine InvertCameraUp = 0\n" +
                            "PseudoEngine DrawGlow = 1\n" );

                        MessageBox.Show("Couldn't find initial EffectsEd3D.ini file.\nInitial ini file created at: \n" + originalPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating backup: " + ex.Message);
                }
            }
        }


        public void WriteToExistingFile( string[] files)
        {
            //we must check if user has selected the black ops root folder first before we can make a backup of the ini file
            
            if (BO_ROOT == null || BO_ROOT == "")
            {
                MessageBox.Show("Please select the Black Ops root folder first.");
                return;
            }

            else
            {
                string originalPath = Path.Combine(BO_ROOT, "bin\\EffectsEd3--.ini");
                if (System.IO.File.Exists(originalPath)) //change to new concurrent ini file name instead of backupPath()
                {
                    System.IO.File.WriteAllLines(originalPath, files);
                }
            }
        }

        public bool isRunning(string pName)
        {
            try
            {
                Process.GetProcessesByName(pName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool isRunningByID()
        {
            try
            {
                Process.GetProcessById(13944);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
