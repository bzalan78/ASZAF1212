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

namespace ASZAF
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

        private void UserMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlUsers());
        }

        private void CustomerMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlCustomers());
        }

        private void ProductMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlProducts());
        }

        private void kilepesMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}