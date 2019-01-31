using System;

namespace GarageSaleApp.Domain
{
    public class Payout
    {
        public GarageSaleEventParty EventParty { get; set; }

        public decimal Amount { get; set; }

        public DateTime DatePaid { get; set; }
    }
}
