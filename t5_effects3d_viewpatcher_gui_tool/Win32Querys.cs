using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace t5_effects3d_viewpatcher_gui_tool
{
    internal class Win32Querys
    {
        public string BOROOT;
        public string BOEFFECTS3DROOT;
        public string fxViewerExe = "effectsed3.exe";
        //public string BlackOpsRootFolder { get; set; }
        public void GetBlackOpsRootFolder()
        {
            OpenFolderDialog fs_open = new OpenFolderDialog
            {
                Title = "Select the Black Ops Root Folder"
            };

            bool? ok = fs_open.ShowDialog();  // call once

            if (ok == true)
            {
                Console.WriteLine("Folder selected successfully.");
                string rootFolder = fs_open.FolderName;
                Console.WriteLine($"Selected path: {rootFolder}");
                MessageBox.Show("SELECTED PATH?? = " + rootFolder);
                BOROOT = rootFolder;
                string effects3dPath = Path.Combine(rootFolder, "bin\\");
                string effects3dFile = effects3dPath + "\\EffectsEd3--.ini";
                string effects3dFileStart = "EffectsEd3--.ini";

                

                MessageBox.Show("EFFECTS3D PATH?? = " + effects3dFile);


                MessageBox.Show("Trying to open fx3d next debug");
                //WORKS NOW AND PASSES THE RIGHT PARAMS
                ProcessStartInfo pi = new ProcessStartInfo();
                pi.UseShellExecute = true;
                pi.FileName = fxViewerExe;
                pi.WorkingDirectory = effects3dPath;
                MessageBox.Show(pi.WorkingDirectory);
                Process.Start(pi);
                
            }
            else
            {
                Console.WriteLine("No folder selected.");
                return;
            }


            //fs_open.Title = "Select the Black Ops Root Folder";
            
            

            //string selectedFolder = fs_open.FolderName;
            //Console.WriteLine("Selected folder: " + selectedFolder);
            //BlackOpsRootFolder = selectedFolder;
        }

        public string PassTheFolder( string folderPath )
        {
            return folderPath;
        }
    }
}
