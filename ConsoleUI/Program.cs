using Business.Concretes;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car = new Car();
            car.Id = 1;
            car.ColorId = 1;
            car.BrandId = 1;
            car.DailyPrice = 1200;
            car.Description = "Clio";
            car.ModalYear = 2022;
            carManager.Add(car);
            
            var Result = carManager.GetAll();
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
        }
    }
}
