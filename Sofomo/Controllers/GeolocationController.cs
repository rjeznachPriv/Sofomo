using Microsoft.AspNetCore.Mvc;
using Sofomo.Data;
using Sofomo.Logic.DTOs;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Sofomo.Api.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GeolocationController : Base.ApiControllerBase
    {

        public GeolocationController(AppDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return DoQuery(queryFactory.GetAllGeolocationsQuery());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromUri] Guid id)
        {
            return DoQuery(queryFactory.GetGeolocationByIdQuery(id));
        }

        [HttpPost]
        public IActionResult Post(LocationDTO location)
        {
            return DoCommand(commandFactory.CreateGeolocationCommand(location));
        }

        [HttpPut]
        public IActionResult Put(LocationDTO location)
        {
            return DoCommand(commandFactory.UpdateGeolocationCommand(location));
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return DoCommand(commandFactory.DeleteGeolocationCommand(id));
        }
    } 
}
