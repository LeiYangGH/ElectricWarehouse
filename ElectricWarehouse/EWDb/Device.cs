using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDb
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime InStoreDate { get; set; }
    }
}
