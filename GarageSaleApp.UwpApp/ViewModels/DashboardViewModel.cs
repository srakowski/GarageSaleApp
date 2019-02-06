using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;

namespace GarageSaleApp.UwpApp.ViewModels
{
    class DashboardViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ICommand NewGarageSaleEventCommand { get; set; }

        public DashboardViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NewGarageSaleEventCommand = new RelayCommand(NewGarageSaleEvent);
        }

        private void NewGarageSaleEvent()
        {
            _navigationService.NavigateTo(nameof(Views.GarageSaleEditorView),
                new GarageSaleEventViewModel(_navigationService));
        }
    }
}
