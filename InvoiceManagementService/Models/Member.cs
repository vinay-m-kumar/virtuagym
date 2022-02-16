using System;
using System.Collections.Generic;

namespace InvoiceManagementService.Models
{
    public partial class Member
    {
        public Member()
        {
            Memberships = new HashSet<Membership>();
        }

        public long MemberId { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
