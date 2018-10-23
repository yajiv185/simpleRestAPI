using Dapper;
using MySql.Data.MySqlClient;
using SimpleRestApiEntity;
using SimpleRestApiInterfaces.Cars;
using System.Configuration;
using System.Data;
using System.Linq;

namespace SimpleRestApiDAL
{
    public class CarsRepository : ICarsRepository
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        public CarBaseData GetCarData(int carId)
        {
            string query = $@"select c.id, c.makeId, c.modelId, c.fuel, c.price, c.km, c.year, c.sellerId, c.insertionTime, 
                                     m.Name as makeName, m.logoUrl as makeLogoUrl, mo.Name as modelName,
                                     s.cityId, ci.Name as cityname, ci.stateName, ci.pincode
                              from Cars as c inner join 
                                   Makes as m on m.id = c.makeId inner join
                                   Models as mo on mo.id = c.modelId inner join
                                   Sellers as s on s.id = c.sellerId inner join
                                   Cities as ci on ci.id = s.cityId
                              where c.id = @v_carId;";
            var dbParams = GetDbParamsFromCarId(carId);
            using (var connection = new MySqlConnection(_connString))
            {
                return connection.Query<CarBaseData>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
        }


        public int? InsertCarData(CarInputParams carInputParams)
        {
            int? lastInsertedId = -1;
            string query = $@"insert into Cars (makeId, modelId, fuel, price, km, year, sellerId)
                                          values (@v_makeId, @v_modelId, @v_fuel, @v_price, @v_km, @v_year, @v_sellerId);
                              select LAST_INSERT_ID();";
            var dbParams = GetDbParamsFromCarInputParams(-1, carInputParams);
            using (var connection = new MySqlConnection(_connString))
            {
                lastInsertedId = connection.Query<int>(query, dbParams, commandType: CommandType.Text)?.FirstOrDefault();
            }
            return lastInsertedId;
        }


        public bool UpdateCarData(int carId, CarInputParams carInputParams)
        {
            bool isSuccessfullyUpdated = false;
            string query = $@"update Cars as c
                              set c.makeId = ifnull(@v_makeId, c.makeId),
                                  c.modelId = ifnull(@v_modelId, c.modelId),
                                  c.fuel = ifnull(@v_fuel, c.fuel),
                                  c.price = ifnull(@v_price, c.price),
                                  c.km = ifnull(@v_km, c.km),
                                  c.year = ifnull(@v_year, c.year),
                                  c.sellerId = ifnull(@v_sellerId, c.sellerId),
                              where c.id = @v_carId;";
            var dbParams = GetDbParamsFromCarInputParams(carId, carInputParams);
            using (var connection = new MySqlConnection(_connString))
            {
                isSuccessfullyUpdated = connection.Execute(query, dbParams, commandType: CommandType.Text) > 0;
            }
            return isSuccessfullyUpdated;
        }

        public bool DeleteCarData(int carId)
        {
            bool isSuccessfullyDeleted = false;
            string query = $@"delete from Cars as c
                              where c.id = @v_carId;";
            var dbParams = GetDbParamsFromCarId(carId);
            using (var connection = new MySqlConnection(_connString))
            {
                isSuccessfullyDeleted = connection.Execute(query, dbParams, commandType: CommandType.Text) > 0;
            }
            return isSuccessfullyDeleted;
        }

        private object GetDbParamsFromCarInputParams(int carId, CarInputParams carInputParams)
        {
            return new
            {
                v_carId = carId,
                v_makeId = carInputParams.MakeId,
                v_modelId = carInputParams.ModelId,
                v_fuel = carInputParams.Fuel,
                v_price = carInputParams.Price,
                v_km = carInputParams.Km,
                v_year = carInputParams.Year,
                v_sellerId = carInputParams.SellerId
            };
        }

        private object GetDbParamsFromCarId(int carId)
        {
            return new
            {
                v_carId = carId
            };
        }
    }
}
