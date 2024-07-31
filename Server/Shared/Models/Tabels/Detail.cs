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
    public partial class Detail
    {
        /// <summary>
        /// ID детали
        /// </summary>
        [Key]
        public int DetailId { get; set; }
        /// <summary>
        /// Название детали
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual List<PumpDetail> PumpDetails { get; set; } = new();
    }
}
