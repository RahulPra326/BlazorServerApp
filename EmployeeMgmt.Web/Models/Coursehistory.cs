using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Web.Models
{
    public partial class Coursehistory
    {
        public int Coursehistoryid { get; set; }
        public int? Orgid { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Coursedirection { get; set; }
        public string? Courselength { get; set; }
        public string? Coursestartlinelengthm { get; set; }
        public string? Courseoffsetlengthm { get; set; }
        public string? Coursefinishtype { get; set; }
        public string? Coursestartlat { get; set; }
        public string? Coursestartlong { get; set; }
    }
}
