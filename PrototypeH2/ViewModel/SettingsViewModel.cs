using PrototypeH2.Common;
using System.Windows;
using System.Windows.Input;

namespace PrototypeH2.ViewModel
{
    public class SettingsViewModel : ObservableObject
    {
        public SettingsViewModel()
        {
        }

        public static readonly ICommand CloseCommand = new RelayCommand(o => ((Window)o).Close());
    }
}
