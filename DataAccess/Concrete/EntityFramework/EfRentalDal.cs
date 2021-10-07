using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        //public List<RentalDetailDto> GetRentalDetail()
        //{
        //    using (CarRentalContext context = new CarRentalContext())
        //    {
        //        var result = from r in context.Rentals
        //                     join c in context.Cars
        //                     o
        //    }
        //}
    }
}
