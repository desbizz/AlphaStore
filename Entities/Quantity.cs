namespace AlphaStore.Entities
{
    public class Quantity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int TotalBought { get; set; }

        public int TotalSold { get; set; }

        public int Balance { get; set; }
    }
}