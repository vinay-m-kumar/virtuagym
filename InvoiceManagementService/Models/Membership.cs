using System;
using System.Collections.Generic;

namespace InvoiceManagementService.Models
{
    public partial class Membership
    {
        public Membership()
        {
            Invoices = new HashSet<Invoice>();
        }

        public long MembershipId { get; set; }
        public long? MemberId { get; set; }
        public bool Active { get; set; }
        public int Credits { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Member? Member { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
