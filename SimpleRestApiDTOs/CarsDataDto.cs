using SimpleRestApiEntity;

namespace SimpleRestApiDTOs
{
    public class CarsDataDto
    {
        public CommonApiDto CommonApiResponse { get; set; }
        public CarBaseData CarData { get; set; }
        public SellerInfo SellerInfo { get; set; }
    }
}
