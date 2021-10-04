using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
   public class Customer : IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public string CompanyName { get; set; }
    }
}
