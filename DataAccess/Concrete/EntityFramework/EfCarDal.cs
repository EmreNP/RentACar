using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtoS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EFEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetDtoAll(Expression<Func<Car, bool>> filter = null)
        {
            using (var context = new RentACarContext())
            {
                var list = filter==null? context.Cars.Include(c => c.ColorNav).Include(c => c.BrandNav).ToList(): context.Cars.Include(c => c.ColorNav).Include(c => c.BrandNav).Where(filter).ToList();
                List<CarDetailDto> cars = new List<CarDetailDto>();
                foreach (var item in list)
                {
                    cars.Add(new CarDetailDto()
                    {
                        CarName = item.CarName,
                        BrandName = item.BrandNav.BrandName,
                        ColorName = item.ColorNav.ColorName,
                        DailyPrice = item.DailyPrice
                    });
                }
                return cars;
            }
        }

        public CarDetailDto GetDto(Expression<Func<Car, bool>> filter)
        {
            using (var context = new RentACarContext())
            {
                var carsWithColorWithBrand = context.Cars.Include(c => c.ColorNav).Include(c => c.BrandNav).Single(filter);
                return new CarDetailDto()
                {
                    CarName = carsWithColorWithBrand.CarName,
                    BrandName = carsWithColorWithBrand.BrandNav.BrandName,
                    ColorName = carsWithColorWithBrand.ColorNav.ColorName,
                    DailyPrice = carsWithColorWithBrand.DailyPrice
                };

            }
        }
    }
}
