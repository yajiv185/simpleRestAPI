﻿using SimpleRestApiEntity;

namespace SimpleRestApiInterfaces.Cars
{
    public interface ICarsRepository
    {
        CarBaseData GetCarData(int carId);
        int? InsertCarData(CarInputParams carInputParams);
        bool UpdateCarData(int carId, CarInputParams carInputParams);
        void DeleteCarData(int carId);
    }
}
