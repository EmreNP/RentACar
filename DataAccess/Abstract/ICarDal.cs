using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using Entities.DtoS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        public List<CarDetailDto> GetDtoAll(Expression<Func<Car,bool>> filter=null);
        public CarDetailDto GetDto(Expression<Func<Car, bool>> filter);
    }
}
