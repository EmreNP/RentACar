using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var color = new Entities.Concrete.Color()
            {
                ColorName = "Beyaz"
            };
            var brand = new Entities.Concrete.Brand()
            {
                BrandName = "Mercedes"
            };
        #region car
        CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Entities.Concrete.Car
            {
                CarName = "cls350",
                DailyPrice = 150,
                ModelYear=2005,
                Description="sadfasfs",
                BrandNav=brand,
                ColorNav=color

            });

            #endregion

            #region color
            //var colorManager = new ColorManager(new EfColorDal);
            //colorManager.Add(new Entities.Concrete.Color
            //{
            //    ColorName = "White"
            //});

            #endregion


        }

    }
}