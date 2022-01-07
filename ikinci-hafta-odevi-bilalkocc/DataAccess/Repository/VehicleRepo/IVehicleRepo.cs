using DataAccess.DataModels;
using DataAccess.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.VehicleRepo
{
    public interface IVehicleRepo:IGenericRepo<Vehicle>
    {
    }
}
