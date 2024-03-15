using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("Details")]
    public class Detail
    {
        [Key]
        public int PumpDetailId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public long MaterialId { get; set; }
        public Material? Material { get; set; } 
        public List<PumpDetail> PumpDetails { get; set; } = new();
    }
}
