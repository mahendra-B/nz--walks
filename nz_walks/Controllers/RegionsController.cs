using DALayer.Repo;
using DALayer.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nz_walks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private IGenericRepo<Region> ser;

        public RegionsController(IGenericRepo<Region> serr)
        {
            ser = serr;
        }
        [HttpGet("showallreg")]
        public IActionResult GetRegion()
        {
            try
            {
                return Ok(ser.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("showregbyid")]
        public IActionResult GetRegionByid(Guid id)
        {
            try
            {
                return Ok(ser.GetById(id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("deletereg")]
        public IActionResult DeleteRegion(int id)
        {
            try
            {
                ser.Delete(id);
                return Ok("record deleted...");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
