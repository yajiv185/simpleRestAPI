using SimpleRestApiEntity;

namespace SimpleRestApiInterfaces.Cars
{
    public interface ICarsCache
    {
        CarBaseData GetCarData(int carId);
        bool UpdateCarData(int carId, CarInputParams carInputParams);
        bool DeleteCarData(int carId);
    }
}
