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
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allVehicles = await unitOfWork.Vehicles.GetAll();
            if (allVehicles is null)
                return NoContent();
            return Ok(allVehicles);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Vehicle vehicle)
        {
            if (vehicle is null)
                return BadRequest();
            else
            {
                unitOfWork.Vehicles.Add(vehicle);
                unitOfWork.Complete();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Vehicle vehicle)
        {
            if (vehicle is null)
                return BadRequest();
            unitOfWork.Vehicles.Update(vehicle);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deleted = await unitOfWork.Vehicles.GetByExp(x => x.Id == id);
            if (deleted is null)
                return BadRequest();
            unitOfWork.Vehicles.Delete(deleted);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        [Route("Containers")]
        public async Task<IActionResult> GetContainersOfVehicle([FromQuery] long id)
        {
            var allContainers = await unitOfWork.Containers.GetAll();
            return Ok(allContainers.Where(x => x.VehicleId == id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByVehicleIdOfContainers(long id)
        { 
            var containers = await unitOfWork.Containers.GetAll();
            var result = containers.Where(x => x.VehicleId == id).ToList();

            return Ok(result);
        }

    }
}
