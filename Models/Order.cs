using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBFirst.Models
{
    public partial class Order
    {
        public string IdCus { get; set; }
        public string IdOrder { get; set; }
        // public string StatusOrder { get; set; }
        public string AddressOrder { get; set; }
        // public int NumKind { get; set; }
        // public double TotalPrice { get; set; }
        // public string PaymentMethod { get; set; }
        public double ShippingFee { get; set; }

        public virtual Customer IdCusNavigation { get; set; }
    }
}
