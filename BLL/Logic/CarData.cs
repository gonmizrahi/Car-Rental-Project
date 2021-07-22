using DAL.Databases;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Logic
{
    // car functions thats connecting the controller to the DB
    public class CarData
    {
        private ICar cars = new DAL.functions.CarFunctions();


        public List<CarsInventory> GetCars()
        {
            return cars.GetCars();
        }
        public CarsInventory GetCarsById(int id)
        {
            return cars.GetCarsById(id);
        }

        public List<CarsInventory> GetAvailableCars()
        {

            return cars.GetAvailableCars();
        }

        public CarsInventory GetCarBySearch(CarsInventory quary)
        {
            return cars.GetCarBySearch(quary);
        }

        public CarsInventory UpdateCarAvailable(CarsInventory UpdateAvailable, int id)
        {
            return cars.UpdateCarAvailable(UpdateAvailable, id);
        }

        public CarsInventory UpdateCarById(CarsInventory UpdateCar, int id)
        {
            return cars.UpdateCarById(UpdateCar, id);
        }

        public CarsInventory AddNewCar(CarsInventory car)
        {
            return cars.AddNewCar(car);
        }
        public CarsInventory DeleteCar(int id)
        {
            return cars.DeleteCar(id);
        }

    }
}
