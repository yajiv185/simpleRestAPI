using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleRestApiBL;
using SimpleRestApiDTOs;
using SimpleRestApiEntity;
using SimpleRestApiUtility;
using System.Net;
using System.Web.Http;

namespace SimpleRestAPIs.Controllers
{
    public class CarsController : ApiController
    {
        private readonly CarsBL _carsBL = new CarsBL();
        private readonly SellersBL _sellersBL = new SellersBL();
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        // GET: api/Cars/5
        [Route("api/cars/{carId}"), HandleException, ValidateId("carId")]
        public IHttpActionResult Get(int carId, bool sendSellerInfo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var carBaseData = _carsBL.GetCarData(carId);
            if (carBaseData == null)
            {
                return Content(HttpStatusCode.NoContent, "Look like car you are looking for does not exist or delted from our system. :(");
            }
            else
            {
                var sellerInfo = sendSellerInfo ? _sellersBL.GetSellerInfo(carBaseData.SellerId) : null;
                var result = GetCarsDataDto("Succesfully fetched Data", carBaseData, sellerInfo);
                return Json(result, _serializerSettings);
            }
        }

        // POST: api/Cars
        [Route("api/cars"), HandleException, ValidateModel("carInputParams")]
        public IHttpActionResult Post([FromBody]CarInputParams carInputParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lastInsertedId = _carsBL.InsertCarData(carInputParams);
            if (lastInsertedId != null && lastInsertedId > 0)
            {
                var result = GetCarInfoInsertionDto("Successfully inserted car data.", lastInsertedId);
                return Json(result, _serializerSettings);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Look like something went wrong due to which we are not able to insert data, please try again. :(");
            }
        }

        // PUT: api/Cars/5
        [Route("api/cars/{carId}"), HandleException, ValidateModel("carInputParams"), ValidateId("carId")]
        public IHttpActionResult Put(int carId, [FromBody]CarInputParams carInputParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isSuccessfullyUpdated = _carsBL.UpdateCarData(carId, carInputParams);
            if (isSuccessfullyUpdated)
            {
                var result = CommonMethods.GetCommonApiDto("Successfully updated car data.");
                return Json(result, _serializerSettings);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Look like something went wrong due to which we are not able to update data, please try again. :(");
            }
        }

        // DELETE: api/Cars/5
        [Route("api/cars/{carId}"), HandleException, ValidateId("carId")]
        public IHttpActionResult Delete(int carId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _carsBL.DeleteCarData(carId);
            var result = CommonMethods.GetCommonApiDto("Successfully deleted car data.");
            return Json(result, _serializerSettings);
        }

        private CarInfoInsertionDto GetCarInfoInsertionDto(string message, int? id)
        {
            return new CarInfoInsertionDto
            {
                CommonApiResponse = CommonMethods.GetCommonApiDto(message),
                CarId = id
            };
        }
        private CarsDataDto GetCarsDataDto(string message, CarBaseData carBaseData, SellerInfo sellerInfo)
        {
            return new CarsDataDto
            {
                CommonApiResponse = CommonMethods.GetCommonApiDto(message),
                CarData = carBaseData,
                SellerInfo = sellerInfo
            };
        }
    }
}
