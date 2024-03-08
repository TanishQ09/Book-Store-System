using BookStore.UserControls;
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

namespace BookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Initialization of main window
        public MainWindow()
        {
            InitializeComponent();
        }

        // function to navigate to the functionality page
        private void mainMenu(object sender, RoutedEventArgs e)
        {
            FunctionalityWindow window_obj = new FunctionalityWindow();
            Visibility = Visibility.Hidden;
            window_obj.Show();

        }

        // function to close the application
        private void quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}