using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModels
{
    public class Vehicle
    {
        [Key]
        public long Id { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
        //public List<Container> Container { get; set; }
    }
}
