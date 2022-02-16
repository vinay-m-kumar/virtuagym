using System;
using System.Collections.Generic;

namespace InvoiceManagementService.Models
{
    public partial class InvoiceState
    {
        public int StatusId { get; set; }
        public string? Description { get; set; }
    }
}
