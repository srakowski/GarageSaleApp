using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GarageSaleApp.Domain;
using System;
using System.Windows.Input;

namespace GarageSaleApp.UwpApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DashboardViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NewGarageSaleCommand = new RelayCommand(NewGarageSale);
        }

        public ICommand NewGarageSaleCommand { get; set; }

        private void NewGarageSale()
        {
            _navigationService.NavigateTo(
                nameof(Views.GarageSaleEditorView),
                new GarageSaleEvent());
        }
    }
}
