using GarageSaleApp.UwpApp.Commands;
using System.ComponentModel;

namespace GarageSaleApp.UwpApp.ViewModels
{
    public class ChangeCalculator : IAcceptsDigits, INotifyPropertyChanged
    {
        public decimal SaleTotal { get; set; }

        public string CashTendered { get; set; }

        public bool ShowTheChangeDue { get; set; }

        public decimal ChangeDue { get; set; }

        public EnterDigitCommand EnterDigitCommand { get; set; }

        public ChangeCalculator()
        {
            EnterDigitCommand = new EnterDigitCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Activate(decimal saleTotal)
        {
            SaleTotal = saleTotal;
            CashTendered = 0m.ToString();
            ChangeDue = 0m;
            ShowTheChangeDue = false;
        }

        public void CalculateChange()
        {
            ChangeDue = SaleTotal - decimal.Parse(CashTendered);
            ShowTheChangeDue = true;
        }

        public void PushDigit(string digit)
        {
            var newCashTendered = CashTendered + digit;
            CashTendered = decimal.TryParse(newCashTendered, out var _)
                    ? newCashTendered
                    : CashTendered;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashTendered"));
        }

        public void PopDigit()
        {
            if (CashTendered.Length > 1)
            {
                CashTendered = CashTendered.Substring(0, CashTendered.Length - 1);
            }
            else if (CashTendered.Length == 1)
            {
                CashTendered = "0";
            }
        }
    }
}
