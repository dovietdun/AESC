using System.ComponentModel.DataAnnotations;

namespace ProductionOrder.Models
{
    public class Orders
    {
        [Key]
        public Guid OrderID { get; set; }
        public string OrderStatus { get; set; }
        public string OrderNo { get; set; }
        public string OrderType { get; set; }
        public string Supplier { get; set; }
        public DateTime ScheduledReception { get; set; }
        public string Priority { get; set; }
        public int CompletedLines { get; set; }

    }
}
