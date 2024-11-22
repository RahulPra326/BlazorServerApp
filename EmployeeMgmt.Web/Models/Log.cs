using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Web.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; } = null!;
        public string Level { get; set; } = null!;
        public string Logger { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Exception { get; set; }
        public string? Userid { get; set; }
        public string? AuthToken { get; set; }
        public string? ConnectionId { get; set; }
        public string? GroupName { get; set; }
        public string? BroadcastToSpecificConnectionId { get; set; }
        public string? Name { get; set; }
        public string? Routine { get; set; }
        public string? UserHostAddress { get; set; }
        public string? UserAgent { get; set; }
    }
}
