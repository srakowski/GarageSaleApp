namespace GarageSaleApp.Domain
{
    public class SaleLineItem
    {
        public Sale Sale { get; set; }

        public Party Party { get; set; }

        public decimal Price { get; set; }
    }
}
