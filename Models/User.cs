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
        public int Id { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string MiddleName { get; internal set; }
        public string Contact { get; internal set; }
    }
}
