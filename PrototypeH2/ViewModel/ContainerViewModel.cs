using PrototypeH2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PrototypeH2.ViewModel
{
    class ContainerViewModel : ObservableObject, IPageDisplay
    {
        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        private readonly IViewService _viewService = new ContainerViewService();

        public ContainerViewModel()
        {
            // Add available pages
            PageViewModels.Add(new BookingViewModel());
            PageViewModels.Add(new RoomViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];

            // Start time update
            _currentTime = DateTime.Now.ToString("hh:mm tt");
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            _currentTime = DateTime.Now.ToString("hh:mm tt");
        }

        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set {
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
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

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public void ChangeViewModel(IPageViewModel newPage)
        {
            if (!PageViewModels.Contains(newPage))
                PageViewModels.Add(newPage);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == newPage);
        }

        public IPageViewModel GetCurrentPage()
        {
            return CurrentPageViewModel;
        }

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                if (_settingsCommand == null)
                {
                    _settingsCommand = new RelayCommand(
                        p => {
                            IsVisible = Visibility.Hidden;
                            _viewService.OpenView(new SettingsViewModel(), true);
                        });
                }

                return _settingsCommand;
            }
        }
    }
}
