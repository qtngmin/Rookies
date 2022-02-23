using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBFirst.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string IdCustomer { get; set; }
        public string NameCus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TypeCus { get; set; }
        public string Username { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
