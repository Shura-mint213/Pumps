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
    /// Модель данных насоса
    /// </summary>
    public partial class Pump
    {
        /// <summary>
        /// ID насоса
        /// </summary>
        [Key]
        public long PumpId { get; set; }
        /// <summary>
        /// Название насоса
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Максимальное давление
        /// </summary>
        public float MaxPressure { get; set; }
        /// <summary>
        /// Максимальное допустимая температура жидкости
        /// </summary>
        public float MaxLiquidTemperature { get; set; }
        /// <summary>
        /// Вес 
        /// </summary>
        public float Weight { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }
        public virtual List<PumpDetail> PumpDetails { get; set; } = new();
        public virtual List<PumpFile> PumpFiles { get; set; } = new();
    }
}
