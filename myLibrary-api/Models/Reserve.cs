using System;
using System.Collections.Generic;

namespace myLibrary_api.Models
{
    public partial class Reserve
    {
        public int ResId { get; set; }
        public DateTime ResDateReservation { get; set; }
        public DateTime ResDateWithdrawal { get; set; }
        public bool? ResStatus { get; set; }
        public int UseId { get; set; }
        public int BooId { get; set; }

        public virtual Book Boo { get; set; }
        public virtual User Use { get; set; }
    }
}
