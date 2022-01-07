using DataAccess.Context;
using DataAccess.Repository.ContainerRepo;
using DataAccess.Repository.VehicleRepo;

namespace DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        
        public IVehicleRepo Vehicles { get; private set; }
        public IContainerRepo Containers { get; private set; }

        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            Vehicles = new VehicleRepo(context);
            Containers = new ContainerRepo(context);
            
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        
    }
}
