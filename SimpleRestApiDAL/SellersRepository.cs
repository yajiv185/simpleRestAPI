using Dapper;
using MySql.Data.MySqlClient;
using SimpleRestApiEntity;
using SimpleRestApiInterfaces.Seller;
using System.Configuration;
using System.Data;
using System.Linq;

namespace SimpleRestApiDAL
{
    public class SellersRepository : ISellersRepository
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        public SellerInfo GetSellerInfo(int sellerId)
        {
            string query = $@"select s.id as sellerID, s.Name as sellerName, s.contactNumber, s.email, s.address, s.cityId,
                                     c.Name as cityName, c.stateName, c.pincode
                              from Sellers as s inner join Cities as c on s.cityId = c.Id
                              where s.id = @v_sellerId;";
            var dbParams = GetDbParamsFromSellerId(sellerId);
            using (var connection = new MySqlConnection(_connString))
            {
                return connection.Query<SellerInfo>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
        }

        public int? InsertSellerInfo(SellerInputParams sellerInputParams)
        {
            int? lastInsertedId = -1;
            string query = $@"insert into Sellers (name, contactNo, email, address, cityId)
                                          values (@v_name, @v_contactNumber, @v_email, @v_address, @v_cityId);
                              select LAST_INSERT_ID();";
            var dbParams = GetDbParamsFromSellerInputParams(-1, sellerInputParams);
            using (var connection = new MySqlConnection(_connString))
            {
                lastInsertedId = connection.Query<int>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
            return lastInsertedId;
        }

        public bool UpdateSellerInfo(int sellerId, SellerInputParams sellerInputParams)
        {
            bool isSuccessfullyUpdated = false;
            string query = $@"update Sellers as s
                              set s.name = ifnull(@v_name, s.name),
                                  s.contactNumber = ifnull(@v_contactNumber, s.contactNumber),
                                  s.email = ifnull(@v_email, s.email),
                                  s.address = ifnull(@v_address, s.address),
                                  s.cityId = ifnull(@v_cityId, s.cityId)
                              where s.id = @v_sellerId;";
            var dbParams = GetDbParamsFromSellerInputParams(sellerId, sellerInputParams);
            using (var connection = new MySqlConnection(_connString))
            {
                isSuccessfullyUpdated = connection.Execute(query, dbParams, commandType: CommandType.Text) > 0;
            }
            return isSuccessfullyUpdated;
        }

        public bool DeleteSellerInfo(int sellerId)
        {
            bool isSuccessfullyDeleted = false;
            string query = $@"delete from Sellers as s
                              where s.id = @v_sellerId;";
            var dbParams = GetDbParamsFromSellerId(sellerId);
            using (var connection = new MySqlConnection(_connString))
            {
                isSuccessfullyDeleted = connection.Execute(query, dbParams, commandType: CommandType.Text) > 0;
            }
            return isSuccessfullyDeleted;
        }

        private object GetDbParamsFromSellerInputParams(int sellerId, SellerInputParams sellerInputParams)
        {
            return new
            {
                v_sellerId = sellerId,
                v_name = sellerInputParams.SellerName,
                v_contactNumber = sellerInputParams.ContactNumber,
                v_email = sellerInputParams.Email,
                v_address = sellerInputParams.SellerAddress,
                v_cityId = sellerInputParams.CityId
            };
        }
        private object GetDbParamsFromSellerId(int sellerId)
        {
            return new
            {
                v_sellerId = sellerId
            };
        }
    }
}
