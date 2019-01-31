using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public class GarageSaleEventParty
    {
        public GarageSaleEvent Event { get; set; }

        public Party Party { get; set; }

        public string Color { get; set; }

        public ICollection<Payout> Payouts { get; set; }
    }
}
