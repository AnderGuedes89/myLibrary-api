using System;
using System.Collections.Generic;

namespace myLibrary_api.Models
{
    public partial class Book
    {
        public Book()
        {
            Loans = new HashSet<Loan>();
            Reserves = new HashSet<Reserve>();
        }

        public int BooId { get; set; }
        public string BooTitle { get; set; }
        public string BooAuthor { get; set; }
        public string BooGenre { get; set; }
        public int BooPages { get; set; }
        public int? BooEdition { get; set; }
        public string BooPublisher { get; set; }
        public DateTime BooYear { get; set; }
        public string BooLanguage { get; set; }
        public string BooCode { get; set; }
        public string BooImage { get; set; }
        public bool? BooAvailability { get; set; }
        public bool BooReserveSituation { get; set; }
        public bool BooLoanSituation { get; set; }
        public bool? BooStatus { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
