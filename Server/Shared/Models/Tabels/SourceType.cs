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
    /// Модель данных источника данных
    /// </summary>
    [Table("SourceTypes")]
    public partial class SourceType
    {
        /// <summary>
        /// ID источника данных
        /// </summary>
        [Key]
        public byte SourcesId { get; set; }
        /// <summary>
        /// Название источника
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Описание источника
        /// </summary>
        public string? Description { get; set; }
        public virtual List<File> Files { get; set; } = new();
    }
}
