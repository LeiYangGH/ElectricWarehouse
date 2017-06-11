using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDb
{
    public class Category2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Category1Id { get; set; }
        public string Name { get; set; }
        public virtual Category1 Category1 { get; set; }
        public virtual List<Device> Devices { get; set; }
    }
}
