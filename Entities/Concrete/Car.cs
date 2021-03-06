using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Car:IEntity
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<CarImage> CarImages { get; set; }
    }
}
