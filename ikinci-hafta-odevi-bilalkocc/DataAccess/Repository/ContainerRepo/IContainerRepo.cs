using DataAccess.DataModels;
using DataAccess.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ContainerRepo
{
    public interface IContainerRepo : IGenericRepo<Container>
    {
        void DeleteContainerWithVehicleId(long id);
        public IEnumerable<Container> GetContainersWithVehicleId(long id);
    }
}
