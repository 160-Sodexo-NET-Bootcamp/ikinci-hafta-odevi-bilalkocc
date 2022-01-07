using DataAccess.Context;
using DataAccess.DataModels;
using DataAccess.Repository.GenericRepo;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository.ContainerRepo
{
    public class ContainerRepo:GenericRepo<Container>,IContainerRepo
    {
        
        public ContainerRepo(AppDbContext context):base(context)
        {
            
        }
        public AppDbContext context { get { return _context as AppDbContext; } }
        public void DeleteContainerWithVehicleId(long id)// vehicle id'sine göre baglı container'ları silme
        {
            var temp = context.Containers.Where(x => x.VehicleId == id).ToList();
            context.Containers.RemoveRange(temp);
        }
        public IEnumerable<Container> GetContainersWithVehicleId(long id)// vehicle id'sine göre containerları getirme
        {
            return context.Containers.Where(x => x.VehicleId == id).ToList();
        }
    }
}
