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
    /// Модель данных расширения файла
    /// </summary>
    [Table("FileExtensions")]
    public partial class FileExtension
    {
        /// <summary>
        /// ID файла расширение
        /// </summary>
        [Key]
        public byte FileExtensionId { get; set; }
        /// <summary>
        /// Название расширения
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }
        public virtual List<File> File { get; set; } = new();
    }
}
