using SimpleRestApiBL;
using SimpleRestApiEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleRestAPIs.Controllers
{
    public class CarsController : ApiController
    {
        private readonly CarsBL _carsBL = new CarsBL();

        // GET: api/Cars/5
        [Route("api/cars/{carId}")]
        public IHttpActionResult Get(int carId, bool sendSellerInfo)
        {
            var carBaseData = _carsBL.GetCarData(carId);
            return Ok(carBaseData);
        }

        // POST: api/Cars
        [Route("api/cars")]
        public IHttpActionResult Post([FromBody]CarInputParams carInputParams)
        {
            var lastInsertedId = _carsBL.InsertCarData(carInputParams);
            if (lastInsertedId != null && lastInsertedId > 0)
            {
                return Ok(lastInsertedId);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Cars/5
        [Route("api/cars/{carId}")]
        public IHttpActionResult Put(int carId, [FromBody]CarInputParams carInputParams)
        {
            var isSuccessfullyUpdated = _carsBL.UpdateCarData(carId, carInputParams);
            if (isSuccessfullyUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Cars/5
        [Route("api/cars/{carId}")]
        public IHttpActionResult Delete(int carId)
        {
            var isSuccessfullyDeleted = _carsBL.DeleteCarData(carId);
            if (isSuccessfullyDeleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
