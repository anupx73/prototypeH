using System.Windows;

namespace PrototypeH2.View
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnSysMinClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnSysCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
} 
