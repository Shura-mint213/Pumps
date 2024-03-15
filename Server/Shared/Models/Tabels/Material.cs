using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Tabels
{
    [Table("Materials")]
    public class Material
    {
        [Key]
        public long  MaterialId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public List<Pump> Pumps { get; set; } = new();
    }
}
