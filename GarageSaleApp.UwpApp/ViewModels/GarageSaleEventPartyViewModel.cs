using GalaSoft.MvvmLight;
using GarageSaleApp.Domain;

namespace GarageSaleApp.UwpApp.ViewModels
{
    public class GarageSaleEventPartyViewModel : ViewModelBase
    {
        private GarageSaleEventParty _model;

        public GarageSaleEventPartyViewModel(GarageSaleEventParty model)
        {
            this.Model = model;
        }

        public GarageSaleEventParty Model
        {
            get => _model;
            set => Set(ref _model, value);
        }

        public string Name
        {
            get => _model.Party?.Name;
            set
            {
                if (_model.Party != null)
                {
                    _model.Party.Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Color
        {
            get => _model.Color;
            set
            {
                _model.Color = value;
                RaisePropertyChanged();
            }
        }
    }
}
