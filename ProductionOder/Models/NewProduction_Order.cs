using System.ComponentModel.DataAnnotations;

namespace ProductionOrder.Models
{
    public class NewProduction_Order
    {
        [Key]
        public Guid ProductionOrderID { get; set; }


        public string WIPOrderNo { get; set; }


        public string OrderType { get; set; }


        public string OrderStatus { get; set; }

        public string ExternalOrderNo { get; set; }

        public string Facility { get; set; }

        public string Priority { get; set; }

        public string Project { get; set; }

        public string Rank { get; set; }

        public string Process { get; set; }

        public string ProcessRev { get; set; }

        public string Recipe { get; set; }
    }
}
