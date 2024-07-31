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
    /// Модель данных файла
    /// </summary>
    [Table("Files")]
    public partial class File
    {
        /// <summary>
        /// ID файла
        /// </summary>
        [Key]
        public long FilesId { get; set; }
        /// <summary>
        /// Название файла
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Полное название файла с расширением
        /// </summary>
        public string OriginalName { get; set; }
        /// <summary>
        /// Путь до файла
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Время создания файла
        /// </summary>
        public DateTime? Created { get; set; }
        /// <summary>
        /// ID источника данных
        /// </summary>
        public byte SourceTypeId { get; set; }
        /// <summary>
        /// ID расширения файла
        /// </summary>
        public byte ExtensionId { get; set; }
        [ForeignKey(nameof(ExtensionId))]
        public virtual FileExtension? FileExtension { get; set; }
        [ForeignKey(nameof(SourceTypeId))]
        public virtual SourceType? SourceType { get; set; }
    }
}
