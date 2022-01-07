using DataAccess.Context;
using DataAccess.DataModels;
using DataAccess.Repository.GenericRepo;

namespace DataAccess.Repository.VehicleRepo
{
    public class VehicleRepo:GenericRepo<Vehicle>,IVehicleRepo
    {
        public VehicleRepo(AppDbContext context):base(context)
        {

        }
    }
}
