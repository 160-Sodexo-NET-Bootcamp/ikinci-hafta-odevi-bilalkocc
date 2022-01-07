using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class Container
    {
        [Key]
        public long Id { get; set; }
        public string ContainerName { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Longitude { get; set; }
        public long VehicleId { get; set; }
        //[ForeignKey("VehicleId")]
        //public Vehicle Vehicle { get; set; }
    }
}
