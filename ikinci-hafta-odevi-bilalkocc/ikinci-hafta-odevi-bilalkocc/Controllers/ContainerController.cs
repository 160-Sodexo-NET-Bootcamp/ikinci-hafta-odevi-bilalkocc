using DataAccess.DataModels;
using DataAccess.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ikinci_hafta_odevi_bilalkocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ContainerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allContainers = await unitOfWork.Containers.GetAll();
            if (allContainers is null)
                return NoContent();
            return Ok(allContainers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Container container)
        {
            if (container is null)
                return BadRequest();
            else
            {
                unitOfWork.Containers.Add(container);
                unitOfWork.Complete();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Container container)
        {
            if (container is null)
                return BadRequest();
            Container temp = await unitOfWork.Containers.GetByExp(x => x.Id == container.Id);
            temp.Latitude = container.Latitude;
            temp.Longitude = container.Longitude;
            temp.ContainerName = container.ContainerName;
            unitOfWork.Containers.Update(temp);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deleted = await unitOfWork.Containers.GetByExp(x => x.Id == id);
            if (deleted is null)
                return BadRequest();
            unitOfWork.Containers.Delete(deleted);
            unitOfWork.Complete();
            return Ok();
        }


        [HttpGet]
        [Route("clustered")]//verilen VehicleId'ye ve bölünmek istenen küme sayısına göre containerların içiçe liste şeklinde döndürülmesi
        public async Task<IActionResult> GetContainersWithCluster(long vehicleId,int clusterCount)
        {
            var containers =  unitOfWork.Containers.GetContainersWithVehicleId(vehicleId).ToList();
            if (containers is null)
                return BadRequest();
            double result = containers.Count() / (double)clusterCount;
            int clusterLength = (int)Math.Round(result);
            List<List<Container>> clustered = new List<List<Container>>();
            
            while (containers.Any())
            {
                clustered.Add(containers.Take(clusterLength).ToList());
                containers = containers.Skip(clusterLength).ToList();
            }
            return Ok(clustered);
        }
    }
}
