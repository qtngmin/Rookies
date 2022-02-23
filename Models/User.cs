using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBFirst.Models
{
    public partial class User
    {
        public User()
        {
            Admins = new HashSet<Admin>();
            Customers = new HashSet<Customer>();
        }

        public string Username { get; set; }
        public string Passw { get; set; }
        public string RecoveryEmail { get; set; }
        public DateTime? ActiveDate { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
