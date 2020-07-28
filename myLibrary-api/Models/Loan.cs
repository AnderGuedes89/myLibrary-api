using System;
using System.Collections.Generic;

namespace myLibrary_api.Models
{
    public partial class Loan
    {
        public int LoaId { get; set; }
        public DateTime LoaDateLoad { get; set; }
        public DateTime LoaDateReturn { get; set; }
        public bool? LoaStatus { get; set; }
        public bool LoaRenovation { get; set; }
        public int UseId { get; set; }
        public int BooId { get; set; }

        public virtual Book Boo { get; set; }
        public virtual User Use { get; set; }
    }
}
