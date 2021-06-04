using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeGameTracker.WebAPI.Controllers
{
    [Authorize]
    public class StorageAreaController : ApiController
    {
        /*public IHttpActionResult Get()
        {
            StorageAreaService storageAreaService = CreateStorageAreaService();
            var storageAreas = storageAreaService.GetStorageArea();
            return Ok(storageAreas);
        }*/

        public IHttpActionResult Post(StorageAreaCreate storageArea)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStorageAreaService();

            if (!service.CreateStorageArea(storageArea))
                return InternalServerError();

            return Ok();

        }
        
        private StorageAreaService CreateStorageAreaService()
        {
            var storageAreaService = new StorageAreaService();
            return storageAreaService;
        }
    }
}
