using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDb
{
    public class DeviceReturn
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DeviceNO { get; set; }
        public string ReturnBy { get; set; }
        public string Submitter { get; set; }
        public DateTime Date { get; set; }
        public virtual Device Device { get; set; }
    }
}
