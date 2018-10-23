using SimpleRestApiBL;
using SimpleRestApiEntity;
using System.Web.Http;

namespace SimpleRestAPIs.Controllers
{
    public class SellersController : ApiController
    {
        private readonly SellersBL _sellersBL = new SellersBL();

        // GET: api/Sellers/5
        [Route("api/sellers/{sellerId}")]
        public IHttpActionResult Get(int sellerId)
        {
            var sellerInfo = _sellersBL.GetSellerInfo(sellerId);
            return Ok(sellerInfo);
        }

        // POST: api/Sellers
        [Route("api/sellers")]
        public IHttpActionResult Post([FromBody]SellerInputParams sellerInputParams)
        {
            var lastInsertedId = _sellersBL.InsertSellerInfo(sellerInputParams);
            if (lastInsertedId != null && lastInsertedId > 0)
            {
                return Ok(lastInsertedId);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Sellers/5
        [Route("api/sellers/{sellerId}")]
        public IHttpActionResult Put(int sellerId, [FromBody]SellerInputParams sellerInputParams)
        {
            var isSuccessfullyUpdated = _sellersBL.UpdateSellerInfo(sellerId, sellerInputParams);
            if (isSuccessfullyUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Sellers/5
        [Route("api/sellers/{sellerId}")]
        public IHttpActionResult Delete(int sellerId)
        {
            var isSuccessfullyDeleted = _sellersBL.DeleteSellerInfo(sellerId);
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
