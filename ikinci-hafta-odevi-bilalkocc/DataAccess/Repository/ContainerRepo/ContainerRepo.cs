using DataAccess.Context;
using DataAccess.DataModels;
using DataAccess.Repository.GenericRepo;

namespace DataAccess.Repository.ContainerRepo
{
    public class ContainerRepo:GenericRepo<Container>,IContainerRepo
    {
        
        public ContainerRepo(AppDbContext context):base(context)
        {

        }
    }
}
