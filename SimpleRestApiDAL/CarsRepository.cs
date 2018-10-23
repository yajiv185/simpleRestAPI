using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Linq;

namespace SimpleRestApiDAL
{
    public class CarsRepository
    {
        private string _connString = ConfigurationManager.ConnectionStrings["DatabaseConncet"].ConnectionString;
        public void InsertCars()
        {
            //ReadStock stockDetail = new ReadStock();
            //try
            //{
            //    using (IDbConnection conn = new MySqlConnection(_connString))
            //    {
            //        stockDetail = conn.Query<ReadStock>("sp_UsedCarsCreate", stock, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //return stockDetail;
        }
    }
}
