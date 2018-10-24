using SimpleRestApiDTOs;

namespace SimpleRestAPIs
{
    public static class CommonMethods
    {
        public static CommonApiDto GetCommonApiDto(string message)
        {
            return new CommonApiDto
            {
                Message = message
            };
        }
    }
}