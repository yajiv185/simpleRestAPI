using SimpleRestApiDAL;
using SimpleRestApiEntity;
using SimpleRestApiInterfaces.Cars;

namespace SimpleRestApiCache
{
    public class CarsCache : ICarsCache
    {
        private readonly ICarsRepository _carsRepository = new CarsRepository();

        public CarBaseData GetCarData(int carId)
        {
            //Here currently I don't have cache so I am just returning object by calling database, in case of cache
            //first look into cache if you don't find it in cache then pass database method as callback which will fetch 
            //info from database and store into cache and return that object
            return _carsRepository.GetCarData(carId);
        }

        public bool UpdateCarData(int carId, CarInputParams carInputParams)
        {
            //In case of cache server, after updating info to the database, just delete cache key from cache,
            //So next time it will try to fetch info it will not get from cache and database will be called and 
            //it will store the object return by database into cache(so that way cache has updated data)
            return _carsRepository.UpdateCarData(carId, carInputParams);
        }

        public bool DeleteCarData(int carId)
        {
            //In case of cache server, after updating info to the database, just delete cache key from cache.
            return _carsRepository.DeleteCarData(carId);
        }
    }
}
