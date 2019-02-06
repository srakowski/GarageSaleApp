using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GarageSaleApp.Domain;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GarageSaleApp.UwpApp.ViewModels
{
    public class GarageSaleEventViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _isModified;
        private GarageSaleEvent _model;

        public GarageSaleEventViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Model = new GarageSaleEvent();
            Model.StartDate = DateTime.UtcNow;
            Model.EndDate = DateTime.UtcNow;
            SaveAsyncCommand = new RelayCommand(SaveAsync);
        }

        public GarageSaleEvent Model
        {
            get => _model;
            set => Set(ref _model, value);
        }

        public bool IsModified
        {
            get => _isModified;
            set => Set(ref _isModified, value);
        }

        public string Name
        {
            get => Model.Name;
            set
            {
                _model.Name = value;
                RaisePropertyChanged();
                IsModified = true;
            }
        }

        public DateTimeOffset? FirstDay
        {
            get => Model.StartDate;
            set
            {
                _model.StartDate = value?.DateTime;

                if (_model.EndDate < _model.StartDate)
                {
                    LastDay = _model.StartDate?.AddDays(1);
                }

                RaisePropertyChanged();
                IsModified = true;
            }
        }

        public DateTimeOffset? LastDay
        {
            get => Model.EndDate;
            set
            {
                _model.EndDate = value?.DateTime;
                RaisePropertyChanged();
                IsModified = true;
            }
        }

        public string Notes
        {
            get => Model.Notes;
            set
            {
                _model.Notes = value;
                RaisePropertyChanged();
                IsModified = true;
            }
        }

        public ICommand SaveAsyncCommand { get; }

        public async void SaveAsync()
        {
            IsModified = false;
            await Task.CompletedTask;
            // TODO: actually save this to the repository.
            _navigationService.NavigateTo(nameof(Views.DashboardView));
        }
    }
}
