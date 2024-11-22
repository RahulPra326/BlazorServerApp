using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Web.Models
{
    public partial class Note
    {
        public int Noteid { get; set; }
        public int? Buoyid { get; set; }
        public int? Orgid { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Phonename { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? Component { get; set; }
        public string? Componentserial { get; set; }
        public string? Note1 { get; set; }
        public string? Userid { get; set; }
    }
}
