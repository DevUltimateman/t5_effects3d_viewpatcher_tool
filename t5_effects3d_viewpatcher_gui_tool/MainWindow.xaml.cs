using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//necessary for file explorer dialog
using Microsoft.Win32;

namespace t5_effects3d_viewpatcher_gui_tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Win32Querys win32Querys = new Win32Querys();
            //get the black ops root folder path from the user using a file explorer dialog
            win32Querys.GetBlackOpsRootFolder();
            //update the on screen text box with the selected folder path
            txtGamePath.Text = win32Querys.BOROOT;

        }
    }
}