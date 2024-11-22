using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Web.Models
{
    public partial class Orguser
    {
        public int Orguserid { get; set; }
        public int Orgid { get; set; }
        public string Aspnetusersid { get; set; } = null!;
        public bool? Defaultorg { get; set; }
    }
}
