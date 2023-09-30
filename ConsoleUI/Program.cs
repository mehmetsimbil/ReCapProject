using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
  
            
          
            foreach (var cars in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(cars.Description);
            }
        }
    }
}
