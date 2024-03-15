using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("PumpsDetails")]
    public class PumpDetail
    {
        [Key]
        public long PumpDetailId { get; set; }
        public long PumpId { get; set; }
        public int DetailId { get; set; }
        [ForeignKey(nameof(DetailId))]
        public Detail? Detail { get; set; }
        [ForeignKey(nameof(PumpId))]
        public Pump? Pump { get; set; }
    }
}
