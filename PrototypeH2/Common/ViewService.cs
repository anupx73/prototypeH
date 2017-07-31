using PrototypeH2.View;

namespace PrototypeH2.Common
{
    class ContainerViewService : IViewService
    {
        public void OpenView(object viewModel, bool isModal = false)
        {
            var win = new ContainerView()
            {
                DataContext = viewModel
            };
            if (isModal)
                win.ShowDialog();
            else
                win.Show();
        }
    }
}
