using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("FileTypes")]
    public class FileType
    {
        [Key]
        public byte FileTypesId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public List<File> File { get; set; } = new();
    }
}
