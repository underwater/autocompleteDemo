using System;
using System.Linq;
using backend.DataTransferObjects;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _service;

        public CitiesController(ICitiesService service) 
            => _service = service ?? throw new ArgumentNullException(nameof(service));

        [HttpGet]
        [Route("search")]
        public ActionResult Search([FromQuery(Name = "q")] string searchText)
        {
            if(string.IsNullOrEmpty(searchText)) 
            {
                return Ok(Enumerable.Empty<CityDto>());
            }
            return Ok(_service.GetCitiesByName(searchText));
        }

        [HttpGet]
        [Route("favorite")]
        public ActionResult Favorite()
        {
            return Ok(_service.GetFavoriteCities());
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CityDto cityDto)
        {
            _service.UpdateCity(cityDto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
