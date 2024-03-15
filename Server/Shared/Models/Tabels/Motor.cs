using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("Motors")]
    public class Motor
    {
        [Key]
        public int MotorsId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Power { set; get; }
        public float Current { get; set; }
        public float Speed { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<Pump> Pumps { get; set; } = new();
    }
}
