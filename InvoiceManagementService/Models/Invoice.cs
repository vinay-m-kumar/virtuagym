using System;
using System.Collections.Generic;

namespace InvoiceManagementService.Models
{
    public partial class Invoice
    {
        public long InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public long? MembershipId { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public int? StatusId { get; set; }

        public virtual Membership? Membership { get; set; }
    }
}
