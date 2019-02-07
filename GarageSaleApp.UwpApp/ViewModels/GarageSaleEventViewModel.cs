using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GarageSaleApp.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GarageSaleApp.UwpApp.ViewModels
{
    public class GarageSaleEventViewModel : ViewModelBase
    {
        private bool _isModified;
        private GarageSaleEvent _model;
        private readonly INavigationService _navigationService;

        public GarageSaleEventViewModel(GarageSaleEvent @event,
            INavigationService navigationService)
        {
            _navigationService = navigationService;
            Model = @event;
            Model.StartDate = Model.StartDate ?? DateTime.UtcNow;
            Model.EndDate = Model.EndDate ?? DateTime.UtcNow;
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

        public void SaveAsync()
        {
            //await Task.Delay(TimeSpan.FromSeconds(30));

            IsModified = false;

            // TODO: actually save this to the repository.

            _navigationService.NavigateTo(nameof(Views.DashboardView));
        }
    }
}
