using System;
using System.Collections.Generic;

namespace myLibrary_api.Models
{
    public partial class User
    {
        public User()
        {
            Loans = new HashSet<Loan>();
            Reserves = new HashSet<Reserve>();
        }

        public int UseId { get; set; }
        public string UseName { get; set; }
        public string UseEmail { get; set; }
        public string UsePassword { get; set; }
        public bool? UseType { get; set; }
        public bool? UseStatus { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
