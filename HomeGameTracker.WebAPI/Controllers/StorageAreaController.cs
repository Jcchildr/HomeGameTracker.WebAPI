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
        public IHttpActionResult Get()
        {
            StorageAreaService storageAreaService = CreateStorageAreaService();
            var storageAreas = storageAreaService.GetAllStorageAreas();
            return Ok(storageAreas);
        }

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

        public IHttpActionResult Get(int id)
        {
            StorageAreaService storageAreaService = CreateStorageAreaService();
            var storageArea = storageAreaService.GetStorageAreaById(id);
            return Ok(storageArea);
        }

        public IHttpActionResult Put(StorageAreaEdit storageArea)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStorageAreaService();

            if (!service.UpdateStorageArea(storageArea))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateStorageAreaService();

            if (!service.DeleteStorageArea(id))
                return InternalServerError();

            return Ok();
        }
    }
}
