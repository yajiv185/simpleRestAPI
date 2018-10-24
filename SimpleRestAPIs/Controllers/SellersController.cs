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
    public class SellersController : ApiController
    {
        private readonly SellersBL _sellersBL = new SellersBL();
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        // GET: api/Sellers/5
        [Route("api/sellers/{sellerId}"), HandleException, ValidateId("sellerId")]
        public IHttpActionResult Get(int sellerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sellerInfo = _sellersBL.GetSellerInfo(sellerId);
            if (sellerInfo == null)
            {
                return Content(HttpStatusCode.NoContent, "Look like seller you are looking for does not exist or delted from our system. :(");
            }
            else
            {
                return Json(sellerInfo, _serializerSettings);
            }
        }

        // POST: api/Sellers
        [Route("api/sellers"), HandleException, ValidateModel("sellerInputParams")]
        public IHttpActionResult Post([FromBody]SellerInputParams sellerInputParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lastInsertedId = _sellersBL.InsertSellerInfo(sellerInputParams);
            if (lastInsertedId != null && lastInsertedId > 0)
            {
                var result = GetSellerInfoInsertionDto("Successfully inserted seller data.", lastInsertedId);
                return Json(result, _serializerSettings);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Look like something went wrong due to which we are not able to insert data, please try again");
            }
        }

        // PUT: api/Sellers/5
        [Route("api/sellers/{sellerId}"), HandleException, ValidateModel("sellerInputParams"), ValidateId("sellerId")]
        public IHttpActionResult Put(int sellerId, [FromBody]SellerInputParams sellerInputParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isSuccessfullyUpdated = _sellersBL.UpdateSellerInfo(sellerId, sellerInputParams);
            if (isSuccessfullyUpdated)
            {
                var result = CommonMethods.GetCommonApiDto("Successfully updated seller data.");
                return Json(result, _serializerSettings);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, "Look like something went wrong due to which we are not able to update data, please try again");
            }
        }

        // DELETE: api/Sellers/5
        [Route("api/sellers/{sellerId}"), HandleException, ValidateId("sellerId")]
        public IHttpActionResult Delete(int sellerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _sellersBL.DeleteSellerInfo(sellerId);
            var result = CommonMethods.GetCommonApiDto("Successfully deleted seller data.");
            return Json(result, _serializerSettings);
        }

        private SellerInfoInsertionDto GetSellerInfoInsertionDto(string message, int? id)
        {
            return new SellerInfoInsertionDto
            {
                CommonApiResponse = CommonMethods.GetCommonApiDto(message),
                SellerId = id
            };
        }
    }
}
