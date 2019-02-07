using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GarageSaleApp.UwpApp.Services
{
    class FrameNavigationService : INavigationService
    {
        private readonly Frame _frame;

        private readonly Dictionary<string, Type> _routes;

        public FrameNavigationService(Frame frame)
        {
            _frame = frame;
            _routes = new Dictionary<string, Type>();

            _routes[nameof(Views.DashboardView)] = typeof(Views.DashboardView);
            _routes[nameof(Views.GarageSaleEditorView)] = typeof(Views.GarageSaleEditorView);
        }

        public string CurrentPageKey => _frame.CurrentSourcePageType.Name;

        public void GoBack() => _frame.GoBack();

        public void NavigateTo(string pageKey) => NavigateTo(pageKey, null);

        public void NavigateTo(string pageKey, object parameter)
        {
            if (_routes.ContainsKey(pageKey))
            {
                _frame.Navigate(_routes[pageKey], parameter);
            }
        }
    }
}
