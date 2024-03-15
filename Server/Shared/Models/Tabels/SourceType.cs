using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("SourceTypes")]
    public class SourceType
    {
        [Key]
        public byte SourcesId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<File> Files { get; set; } = new();
    }
}
