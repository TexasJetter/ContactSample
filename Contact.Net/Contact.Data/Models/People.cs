using System;
using System.Collections.Generic;

namespace Contact.Data.Models
{
    public partial class People
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
    }
}
