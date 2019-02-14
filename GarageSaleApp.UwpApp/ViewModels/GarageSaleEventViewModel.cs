using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GarageSaleApp.Domain;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GarageSaleApp.UwpApp.ViewModels
{
    public class GarageSaleEventViewModel : ViewModelBase
    {
        private bool _isModified;
        private string _partyName;
        private GarageSaleEvent _model;
        private readonly INavigationService _navigationService;
        private readonly GarageSaleEventManager _garageSaleEventManager;

        public GarageSaleEventViewModel(INavigationService navigationService,
            GarageSaleEventManager garageSaleEventManager)
        {
            _navigationService = navigationService;
            _garageSaleEventManager = garageSaleEventManager;
            SaveAsyncCommand = new RelayCommand(SaveAsync);
            AddPartyCommand = new RelayCommand(AddParty);
            Parties = new ObservableCollection<GarageSaleEventPartyViewModel>
            {
                new GarageSaleEventPartyViewModel(new GarageSaleEventParty
                {
                    Party = new Party
                    {
                        Name = "Rakowski Family",
                    }
                }),
                new GarageSaleEventPartyViewModel(new GarageSaleEventParty
                {
                    Party = new Party
                    {
                        Name = "Harry Henderson",
                    },
                }),
            };
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

        public string PartyName
        {
            get => _partyName;
            set => Set(ref _partyName, value);
        }

        public ObservableCollection<GarageSaleEventPartyViewModel> Parties { get; set; }

        public ICommand AddPartyCommand { get; }

        public ICommand SaveAsyncCommand { get; }

        public void AddParty()
        {
            var party = new GarageSaleEventParty
            {
                Event = this.Model,
                Party = new Party
                {
                    Name = this.PartyName
                }
            };

            Parties.Add(new GarageSaleEventPartyViewModel(party));
        }

        public void SaveAsync()
        {
            IsModified = false;

            _garageSaleEventManager.CreateEvent(Model);

            _navigationService.NavigateTo(nameof(Views.DashboardView));
        }

        public void Load(object model)
        {
            Model = model as GarageSaleEvent ?? new GarageSaleEvent();
            Model.StartDate = Model.StartDate ?? DateTime.UtcNow;
            Model.EndDate = Model.EndDate ?? DateTime.UtcNow;
        }
    }
}
