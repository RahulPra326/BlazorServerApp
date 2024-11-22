using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Web.Models
{
    public partial class Buoy
    {
        public int Buoyid { get; set; }
        public int? Orgid { get; set; }
        public string? Name { get; set; }
        public string? Uniquekey { get; set; }
        public string? Monthlyfee { get; set; }
        public string Status { get; set; } = null!;
        public string? Latlong { get; set; }
        public DateTime? Latlongtimestamp { get; set; }
        public string? Docklatlong { get; set; }
        public string? Pronavguid { get; set; }
        public string? Sailbotguid { get; set; }
        public string? Sailtimerguid { get; set; }
        public string? Frameserial { get; set; }
        public string? Phonepin { get; set; }
        public string? Phoneimei { get; set; }
        public string? Phonename { get; set; }
        public string? Phonenumber { get; set; }
        public string? Batterymonitorguid { get; set; }
        public string? Hardwareversion { get; set; }
        public DateTime? Warrantyenddate { get; set; }
        public string? Batteryah { get; set; }
        public string? Motortype { get; set; }
        public string? Motorserial { get; set; }
        public DateTime? Motorfirstusagedate { get; set; }
        public string? Pronavserial { get; set; }
        public string? Visible { get; set; }
        public string? Role { get; set; }
        public string? Hull { get; set; }
        public string? Pronavupper { get; set; }
        public string? Pronavlower { get; set; }
        public string? Pronavuppermount { get; set; }
        public string? Pronavlowermount { get; set; }
        public string? Motormount { get; set; }
        public string? Topside { get; set; }
        public string? Phone { get; set; }
        public string? Switch { get; set; }
        public string? Charging { get; set; }
        public string? Spinprevention { get; set; }
        public string? Waterproofing { get; set; }
        public string? Assetvalue { get; set; }
        public string? Foreignsystemid { get; set; }
    }
}
