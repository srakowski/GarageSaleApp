using System.Collections.Generic;

namespace GarageSaleApp.Domain
{
    public class Party
    {
        public string Name { get; set; }

        public ICollection<GarageSaleEventParty> GarageSalesEventParties { get; set; }
    }
}
