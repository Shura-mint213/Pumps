using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("FilesToTables")]
    public class FileToTable
    {
        [Key]
        public long FilesToTablesId { get; set; }
        public long RecordId { get; set; }
        public byte Table { get; set; }
    }
}
