using System.ComponentModel.DataAnnotations;

namespace ProductionOrder.Models
{
    public class OrderLines
    {
        [Key]
        public Guid OrderLineID { get; set; }
        public Guid OrderID { get; set; }
        public string OrderLineNo { get; set; }
        public string OrderLineStatus { get; set; }
        public string Facility { get; set; }
        public string Warehouse { get; set; }
        public string Location { get; set; }
        public string ProductID { get; set; }
        public string Priority { get; set; }
        public string CompletedQuantity { get; set; }
        public string UOM { get; set; }
        public string Lot { get; set; }

    }
}
