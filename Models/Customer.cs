using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBFirst.Models
{
    public class NewBaseType
    {
        public string IdCustomer { get; set; }
        public string NameCus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TypeCus { get; set; }
        public string Username { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public partial class Customer : NewBaseType
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
