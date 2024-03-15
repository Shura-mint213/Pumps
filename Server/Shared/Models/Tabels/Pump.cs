using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    public class Pump
    {
        [Key]
        public long PumpId { get; set; }
        [MaxLength(100)]
        public string Name { get; set;}
        public float MaxPressure { get; set; }
        public float LiquidTemperature { get; set; }
        public float Weight { get; set; }
        public long MaterialHousingId { get; set; }
        public long ImpellerMaterialId { get; set; }
        public string? Description { get; set; }
        public long? PumpPhotos { get; set; }
        public decimal Price { get; set; }
        public int MotorId { get; set; }
        [ForeignKey(nameof(MotorId))]
        public Motor? Motors { get; set; }
        public List<PumpDetail> PumpDetails { get; set; } = new();
        //[ForeignKey(nameof(MaterialHousingId))]
        //public Material? MaterialsHousing { get; set; }
        //[ForeignKey(nameof(ImpellerMaterialId))]
        //public Material? ImpellerMaterial { get; set; }
    }
}
