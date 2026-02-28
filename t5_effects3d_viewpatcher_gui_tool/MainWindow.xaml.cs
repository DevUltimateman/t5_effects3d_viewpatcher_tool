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

        public List<string> INI_FILE_STRUCT = new();
        public List<string> NEW_FILES = new();
        public MainWindow()
        {
            InitializeComponent();

            //check if we have root checker file, if so then populate txtGamePath

        }

        private void btnBackUp_Click(object sender, RoutedEventArgs e)
        {
            win32Querys.MakeBackUpOfIni();
            txtBackUpPath.Text = win32Querys.BO_ROOT_BACKUP_INI_FILE;
            txtBackUpPath.Foreground = new SolidColorBrush(Colors.DarkSeaGreen);
        }

        private void btnFolderPicker_Click(object sender, RoutedEventArgs e)
        {
            //get the black ops root folder path from the user using a file explorer dialog
            win32Querys.GetBlackOpsRootFolder();
            //update the on screen text box with the selected folder path
            txtGamePath.Text = win32Querys.BO_ROOT;
            txtGamePath.Foreground = new SolidColorBrush(Colors.DarkSeaGreen);
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            if( e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //ADD A CHECK IF ROOT IS SELECTED, OTHERWISE IT WILL DO FUCKUPS
                if( win32Querys.BO_ROOT == null ||win32Querys.BO_ROOT == "" )
                {
                    MessageBox.Show("Please select your Black Ops root folder first.");
                    return;
                }
                //FILES DROPPED IN, STORE EACH PATH TO FILES IN AN ARRAY
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                //WE HAVE DROPPED FILES HERE
                if ( files.Length > 0 )
                {

                   

                    if (NEW_FILES.Count() > 0)
                    {
                        NEW_FILES.Clear();
                    }
                    if(lstDroppedFiles.Items.Count > 0 )
                    {
                        lstDroppedFiles.Items.Clear();
                    }
                    if ( files.Length > 7 )
                    {
                        //List<string> NEW_FILES = new();
                        for ( int u = 0; u < 7; u++ )
                        {
                            NEW_FILES.Add( files[u] );
                            
                        }
                        MessageBox.Show("Removed " + ( files.Length - NEW_FILES.Count() ) + " files from the loader pipeline.\nYou can load only 8 files at a time.");
                        for (int s = 0; s < NEW_FILES.Count(); s++)
                        {
                            //MessageBox.Show("ADDING FILE " + s + " / " + NEW_FILES.Count() );
                            lstDroppedFiles.Items.Add(NEW_FILES[s]);

                        }
                        INI_FILE_STRUCT.Add("[Mru]");

                        for (int i = 0; i < NEW_FILES.Count(); i++)
                        {

                            //ini fx file format = "0=C:\path\to\file.fx"
                            INI_FILE_STRUCT.Add(i + "=" + NEW_FILES[i]);
                        }

                        //WE WANT TO WRITE THE FXVIEWER SETTINGS HERE IN THE END!! 
                        INI_FILE_STRUCT.Add("[Settings]");
                        INI_FILE_STRUCT.Add("PseudoEngine DrawAxes = 1");
                        INI_FILE_STRUCT.Add("PseudoEngine DrawWireframe = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine ShowDistance = 1");
                        INI_FILE_STRUCT.Add("PseudoEngine ShowInfo = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine ShowTimeLeft = 1");
                        INI_FILE_STRUCT.Add("Effect CameraLod 0 = 0");
                        INI_FILE_STRUCT.Add("Effect CameraLod 1 = 0");
                        INI_FILE_STRUCT.Add("Effect CameraLod 2 = 0");
                        INI_FILE_STRUCT.Add("Effect CameraLod 3 = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine InvertCameraUp = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine DrawGlow = 1");
                        INI_FILE_STRUCT.Add("");
                        INI_FILE_STRUCT.Add("");

                        win32Querys.WriteToExistingFile(INI_FILE_STRUCT.ToArray());
                        //MessageBox.Show("Fx files added to dropdown list successfully!\nAdded a total of: " + files.Length + " files.");  
                    }
                    else
                    {

                        for (int u = 0; u < files.Length; u++)
                        {
                            NEW_FILES.Add(files[u]);

                        }
                        for (int s = 0; s < NEW_FILES.Count(); s++)
                        {
                            //MessageBox.Show("ADDING FILE " + s + " / " + NEW_FILES.Count() );
                            lstDroppedFiles.Items.Add(NEW_FILES[s]);

                        }
                        INI_FILE_STRUCT.Add("[Mru]");

                        for (int i = 0; i < NEW_FILES.Count(); i++)
                        {

                            //ini fx file format = "0=C:\path\to\file.fx"
                            INI_FILE_STRUCT.Add(i + "=" + NEW_FILES[i]);
                        }

                        //WE WANT TO WRITE THE FXVIEWER SETTINGS HERE IN THE END!! 
                        INI_FILE_STRUCT.Add("[Settings]");
                        INI_FILE_STRUCT.Add("PseudoEngine DrawAxes = 1");
                        INI_FILE_STRUCT.Add("PseudoEngine DrawWireframe = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine ShowDistance = 1");
                        INI_FILE_STRUCT.Add("PseudoEngine ShowInfo = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine ShowTimeLeft = 1");
                        INI_FILE_STRUCT.Add("Effect CameraLod 0 = 0");
                        INI_FILE_STRUCT.Add("Effect CameraLod 1 = 0");
                        INI_FILE_STRUCT.Add("Effect CameraLod 2 = 0");
                        INI_FILE_STRUCT.Add("Effect CameraLod 3 = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine InvertCameraUp = 0");
                        INI_FILE_STRUCT.Add("PseudoEngine DrawGlow = 1");
                        INI_FILE_STRUCT.Add("");
                        INI_FILE_STRUCT.Add("");

                        win32Querys.WriteToExistingFile(INI_FILE_STRUCT.ToArray());
                        //MessageBox.Show("Fx files added to dropdown list successfully!\nAdded a total of: " + files.Length + " files.");  
                    }





                }

                //clear the list so that it doesnt grow indefinitely
                

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

        private void btnBackUp_MouseEnter(object sender, MouseEventArgs e)
        {   
        }

        private void btnBackUp_MouseLeave(object sender, MouseEventArgs e)
        {
            sender.GetType().GetProperty("Effect").SetValue(sender, new DropShadowEffect
            {
                Color = Colors.Transparent,
                Direction = 0,
                ShadowDepth = 0,
                Opacity = 0,
                BlurRadius = 0
            });
        }

        private void btnLaunchFxStandalone_Click(object sender, RoutedEventArgs e)
        {
            win32Querys.LaunchFxViewer();
        }

        private void btnCloseFxStandalone_Click(object sender, RoutedEventArgs e)
        {
            win32Querys.CloseFxViewer();
        }

        private void btnDonateFxStandalone_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.paypal.com/donate/?hosted_button_id=WM4SLXZWT99Y4",
                UseShellExecute = true
            });
        }
    }
}