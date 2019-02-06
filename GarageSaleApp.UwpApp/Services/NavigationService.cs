using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GarageSaleApp.UwpApp.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;

        public string CurrentPageKey => _frame.CurrentSourcePageType.Name;

        public NavigationService(Frame frame)
        {
            this._frame = frame;
        }

        public void GoBack()
        {
            this._frame.GoBack();
        }

        public void NavigateTo(string pageKey) => NavigateTo(pageKey, null);

        public void NavigateTo(string pageKey, object parameter)
        {
            var pageType = pageKey == nameof(Views.DashboardView)
                    ? typeof(Views.DashboardView)
                    : pageKey == nameof(Views.GarageSaleEditorView)
                    ? typeof(Views.GarageSaleEditorView)
                    : null;

            this._frame.Navigate(pageType, parameter);
        }
    }
}
