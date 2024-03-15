using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("Files")]
    public class File
    {
        [Key]
        public long FilesId { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public string Source { get; set; }
        public byte SourceTypeId { get; set; }
        public byte TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public FileType? FileType { get; set; }
        [ForeignKey(nameof(SourceTypeId))]
        public SourceType? SourceType { get; set; }

    }
}
