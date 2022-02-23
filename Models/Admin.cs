using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBFirst.Models
{
    public partial class Admin
    {
        public string Id { get; set; }
        public string NameAd { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
