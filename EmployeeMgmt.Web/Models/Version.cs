using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Web.Models
{
    public partial class Version
    {
        public int Versionid { get; set; }
        public string? Parentvalue { get; set; }
        public string? Value { get; set; }
        public string? Text { get; set; }
    }
}
