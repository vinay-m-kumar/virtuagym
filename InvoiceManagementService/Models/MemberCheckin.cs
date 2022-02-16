using System;
using System.Collections.Generic;

namespace InvoiceManagementService.Models
{
    public partial class MemberCheckin
    {
        public long? MembershipId { get; set; }
        public int? ClubId { get; set; }
        public DateTime? CheckinDate { get; set; }
        public DateTime? CheckoutDate { get; set; }

        public virtual Membership? Membership { get; set; }
    }
}
