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
    /// Модель данных связачной таблицы деталей и насосов
    /// </summary>
    [Table("PumpsDetails")]
    public partial class PumpDetail
    {
        /// <summary>
        /// ID связки детали и насоса
        /// </summary>
        [Key]
        public long PumpDetailId { get; set; }
        /// <summary>
        /// ID насоса к которому относится деталь
        /// </summary>
        public long PumpId { get; set; }
        /// <summary>
        /// ID детали
        /// </summary>
        public int DetailId { get; set; }
        /// <summary>
        /// ID материала детали
        /// </summary>
        public long MaterialId { get; set; }
        [ForeignKey(nameof(MaterialId))]
        public Material? Material { get; set; }
        [ForeignKey(nameof(DetailId))]
        public Detail? Detail { get; set; }
        [ForeignKey(nameof(PumpId))]
        public Pump? Pump { get; set; }
    }
}
