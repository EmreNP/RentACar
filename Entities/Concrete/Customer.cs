using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string CompanyName { get; set; }

        //nav
        public User User { get; set; }
        public List<Rental> Rentals { get; set; } = new();
    }
}
