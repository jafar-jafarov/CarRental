using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
  public  class Program
    {
      public  static void Main(string[] args)
        {
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    foreach (var car in carManager.GetCarDetail())
        //    {
        //        Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.DailyPrice);
        //    }
            //static void TestCarGetAll()
            //{
            //    CarManager carManager = new CarManager(new EfCarDal());
            //    foreach (var c in carManager.GetAll())
            //    {
            //        Console.WriteLine(c.Description);
            //    }
            //}
            //private static void CarAddedd()
            //{
            //    CarManager carManager = new CarManager(new EfCarDal());

            //    var result = carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2021, DailyPrice = 20000, Description = "m" });

            //    if (result.Success)
            //    {
            //        System.Console.WriteLine(result.Message);
            //    }
            //    else
            //    {
            //        System.Console.WriteLine(result.Message);
            //    }
            //}


        }


    }
}
