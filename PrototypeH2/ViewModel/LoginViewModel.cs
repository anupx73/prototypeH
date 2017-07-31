using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrototypeH2.Common;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Security;
using System.Windows.Controls;
using PrototypeH2.Model;
using System.Windows;

namespace PrototypeH2.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        private string _loadingText = String.Empty;
        private ImageSource _loadingImage = null;
        private ICommand _loginCommand;
        private string _userId = String.Empty;
        public SecureString SecurePassword { private get; set; }
        private readonly IViewService _viewService = new ContainerViewService();

        public string UserId { get { return _userId; } set { _userId = value; } }

        public string LoadingText
        {
            get { return _loadingText; }
            set
            {
                _loadingText = value;
                OnPropertyChanged("LoadingText");
            }
        }

        public ImageSource LoadingImage
        {
            get { return _loadingImage; }
            set
            {
                _loadingImage = value;
                OnPropertyChanged("LoadingImage");
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(Login, CanLogin);

                return _loginCommand;
            }
        }

        private Visibility _isVisible = Visibility.Visible;
        public Visibility IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }

        private bool CanLogin(object param)
        {
            PasswordBox pwd = param as PasswordBox;
            return (!(String.IsNullOrEmpty(UserId) || String.IsNullOrEmpty(pwd.Password)));
        }

        private async void Login(object param)
        {
            LoadingImage = new BitmapImage(new Uri("pack://application:,,,/PrototypeH2;component/Resources/gif-load.gif", UriKind.Absolute));
            LoadingText = "Please wait...";

            Task<bool> result = Auth(param);
            bool res = await result;
            if (res)
            {
                IsVisible = Visibility.Hidden;
                _viewService.OpenView(new ContainerViewModel());
            }
        }

        private async Task<bool> Auth(object param)
        {
            PasswordBox pwdBox = param as PasswordBox;
            string UserPwd = pwdBox.Password;
            bool res = true;

            await Task.Run(() =>
            { 
                using (var context = new Booking())
                {
                    var result = (from e in context.Credentials
                                  where e.username == UserId && e.userpwd == UserPwd
                                  select e).FirstOrDefault();

                    if (result == null)
                        res = false;
                }
            });

            LoadingImage = null;
            LoadingText = "";
            return res;
        }
    }
}
