using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDb
{
    public class Device
    {
        [Key]
        public int NO { get; set; }
        public int Category2Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime InStoreDate { get; set; }
        public virtual Category2 Category2 { get; set; }
        public virtual List<DeviceBorrow> DeviceBorrows { get; set; }
        public virtual List<DeviceReturn> DeviceReturns { get; set; }
    }
}
