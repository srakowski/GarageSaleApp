using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public class GarageSaleEventParty
    {
        public int Id { get; set; }

        public GarageSaleEvent Event { get; set; }

        public Party Party { get; set; }

        public string Color { get; set; }

        public ICollection<Payout> Payouts { get; set; }
    }
}
