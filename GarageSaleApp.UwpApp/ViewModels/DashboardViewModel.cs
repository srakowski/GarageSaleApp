using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GarageSaleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GarageSaleApp.UwpApp.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IGarageSaleEventRepository _eventRepo;

        public DashboardViewModel(INavigationService navigationService,
            IGarageSaleEventRepository garageSaleEventRepository)
        {
            _navigationService = navigationService;
            _eventRepo = garageSaleEventRepository;
            NewGarageSaleCommand = new RelayCommand(NewGarageSale);
            this.GarageSaleEvents = _eventRepo.Events.ToList();
        }

        public List<GarageSaleEvent> GarageSaleEvents { get; set; }

        public ICommand NewGarageSaleCommand { get; set; }

        private void NewGarageSale()
        {
            _navigationService.NavigateTo(
                nameof(Views.GarageSaleEditorView),
                new GarageSaleEvent());
        }
    }
}
