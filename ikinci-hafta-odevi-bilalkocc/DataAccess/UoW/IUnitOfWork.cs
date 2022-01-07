using DataAccess.Repository.ContainerRepo;
using DataAccess.Repository.VehicleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UoW
{
    public interface IUnitOfWork
    {
        IVehicleRepo Vehicles { get; }
        IContainerRepo Containers { get; }

        int Complete();
    }
}
