using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    /// <summary>
    /// Модель данных материала
    /// </summary>
    [Table("Materials")]
    public partial class Material
    {
        /// <summary>
        /// ID материала
        /// </summary>
        [Key]
        public long MaterialId { get; set; }
        /// <summary>
        /// Название материала
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Описание материала
        /// </summary>
        public string? Description { get; set; }
        public virtual List<PumpDetail> PumpDetails { get; set; } = new()!;
    }
}
