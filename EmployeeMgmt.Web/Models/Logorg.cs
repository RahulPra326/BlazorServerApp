using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Web.Models
{
    public partial class Logorg
    {
        public int Logorgid { get; set; }
        public int? Orgid { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Foreignsystemid { get; set; }
        public string? Foreignsystemuserid { get; set; }
        public string? Foreignsystempassword { get; set; }
        public int? Bluetoothpassword { get; set; }
        public string? Networkoperator { get; set; }
        public string? Networkmode { get; set; }
        public string? Phonelist { get; set; }
        public string? Emaillist { get; set; }
        public string? Shortname { get; set; }
        public string? Supportpayer { get; set; }
        public string? Supportamountperbot { get; set; }
        public string? Supportpaymentinterval { get; set; }
    }
}
