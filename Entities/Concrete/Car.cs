
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        //Id, BrandId, ColorId, ModelYear, DailyPrice, Description

        public int Id { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public String Description { get; set; }

        // navigation property

        public virtual Brand? BrandNav { get; set; }
        public virtual Color? ColorNav { get; set; }
        public virtual List<Rental>? Rentals { get; set; } = new();
        public virtual List<CarImage>? CarImages { get; set; } = new();

    }
}
