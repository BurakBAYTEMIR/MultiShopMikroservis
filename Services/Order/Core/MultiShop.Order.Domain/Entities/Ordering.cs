namespace MultiShop.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrederDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
