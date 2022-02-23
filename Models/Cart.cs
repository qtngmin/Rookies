using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBFirst.Models
{
    public partial class Cart
    {
        public string IdCus { get; set; }
        public int? NumKind { get; set; }

        public virtual Customer IdCusNavigation { get; set; }
    }
}
