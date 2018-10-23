using SimpleRestApiCache;
using SimpleRestApiDAL;
using SimpleRestApiEntity;
using SimpleRestApiInterfaces.Cars;

namespace SimpleRestApiBL
{
    public class CarsBL : ICarsBL
    {
        private readonly ICarsRepository _carsRepository = new CarsRepository();
        private readonly ICarsCache _carsCache = new CarsCache();

        public CarBaseData GetCarData(int carId)
        {
            //Currently we don't have any business logic, that's why directly calling cache layer and returning object from there
            return _carsCache.GetCarData(carId);
        }

        public int? InsertCarData(CarInputParams carInputParams)
        {
            //No need to go through cache layer as we are inserting new object(databse row) and there is nothing in cache
            //although we can go through cache layer, if we want to store object in cache as soon as we add data into database
            return _carsRepository.InsertCarData(carInputParams);
        }

        public bool UpdateCarData(int carId, CarInputParams carInputParams)
        {
            //Currently we don't have any business logic, that's why calling cache layer and deleteing object from there and updating
            //data into database
            return _carsCache.UpdateCarData(carId, carInputParams);
        }

        public bool DeleteCarData(int carId)
        {
            //Calling cache, it will delete cache object from cache and also delete object(row) from database 
            return _carsCache.DeleteCarData(carId);
        }
    }
}
