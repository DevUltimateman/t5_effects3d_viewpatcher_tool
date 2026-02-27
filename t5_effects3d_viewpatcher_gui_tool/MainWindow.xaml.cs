//necessary for file explorer dialog
using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace t5_effects3d_viewpatcher_gui_tool
{
    public partial class MainWindow : Window
    {
        //grab win32 class once
        Win32Querys win32Querys = new Win32Querys();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            win32Querys.MakeBackUpOfIni();
            txtBackUpPath.Text = win32Querys.BO_ROOT_BACKUP_INI_FILE;
        }

        private void btnFolderPicker_Click(object sender, RoutedEventArgs e)
        {
            //get the black ops root folder path from the user using a file explorer dialog
            win32Querys.GetBlackOpsRootFolder();
            //update the on screen text box with the selected folder path
            txtGamePath.Text = win32Querys.BO_ROOT;
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            if( e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //FILES DROPPED IN, STORE EACH PATH TO FILES IN AN ARRAY
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                //THIS IS THE LIST WE POPULATE AND READ FROM, TO WRITE TO THE INI FILE.
                List<string> iniFileStruct = new();

                //WE HAVE PLENTY OF FILES
                if( files.Length > 0 )
                {
                    //initial "MRU" section so that the fxviewer can read the files we add to the ini file
                    iniFileStruct.Add("[Mru]");

                    for (int i = 0; i < files.Length; i++)
                    {
                        //ini fx file format = "0=C:\path\to\file.fx"
                        iniFileStruct.Add(i + "=" + files[i]);
                    }

                    //WE WANT TO WRITE THE FXVIEWER SETTINGS HERE IN THE END!! 
                    iniFileStruct.Add("[Settings]");
                    iniFileStruct.Add("PseudoEngine DrawAxes = 1");
                    iniFileStruct.Add("PseudoEngine DrawWireframe = 0");
                    iniFileStruct.Add("PseudoEngine ShowDistance = 1");
                    iniFileStruct.Add("PseudoEngine ShowInfo = 0");
                    iniFileStruct.Add("PseudoEngine ShowTimeLeft = 1");
                    iniFileStruct.Add("Effect CameraLod 0 = 0");
                    iniFileStruct.Add("Effect CameraLod 1 = 0");
                    iniFileStruct.Add("Effect CameraLod 2 = 0");
                    iniFileStruct.Add("Effect CameraLod 3 = 0");
                    iniFileStruct.Add("PseudoEngine InvertCameraUp = 0");
                    iniFileStruct.Add("PseudoEngine DrawGlow = 1");
                    iniFileStruct.Add("");
                    iniFileStruct.Add("");
                    
                    win32Querys.WriteToExistingFile(iniFileStruct.ToArray() );
                    MessageBox.Show("Fx files added to dropdown list successfully!\nAdded a total of: " + files.Length + " files."); 

                }

                //clear the list so that it doesnt grow indefinitely
                iniFileStruct.Clear();


                //lets boot into the fx viewer after we drop the files in

                //first check if we are already running the fxviewer process, if so we dont want to launch another instance of it before closing it.
                //bool isFxViewerRunning = win32Querys.isRunning("effectsed3");
                if (win32Querys.isRunning("effectsed3"))
                {
                    var progma = Process.GetProcessesByName("effectsed3");
                    if( progma.Length > 0 )
                    {
                        progma[0].Kill();
                    }
                    else { /*MessageBox.Show("NO PROCESS 'effectsEd3D' FOUND"); */ }
                    win32Querys.LaunchFxViewer();
                }
            }
        }
    }
}