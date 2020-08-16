using Prism.Regions;
using System.Windows.Controls;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    public partial class ViewA : UserControl, INavigationAware
    {
        int _count = 0;
        public ViewA()
        {
            InitializeComponent();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _txtPageViews.Text = $"{++_count}";
        }
    }
}
