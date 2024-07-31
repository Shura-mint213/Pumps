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
    /// Модель данных файла насоса
    /// </summary>
    [Table("PumpFiles")]
    public partial class PumpFile
    {
        public long FileId { get; set; }
        [ForeignKey(nameof(FileId))]
        public File? File { get; set; }
        public long PumpId { get; set; }

        [ForeignKey(nameof(PumpId))]
        public Pump? Pump { get; set; }
    }
}
