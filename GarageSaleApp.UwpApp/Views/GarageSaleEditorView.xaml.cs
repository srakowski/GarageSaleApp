using GarageSaleApp.UwpApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GarageSaleApp.UwpApp.Views
{
    public sealed partial class GarageSaleEditorView : Page
    {
        public GarageSaleEditorView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.DataContext is IActivateable activateable)
            {
                activateable.Activate(e.Parameter);
            }
        }
    }
}
