﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DtoS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailDto>> carDetailDtoGetAll();
        IDataResult<CarDetailDto> GetDetailCarId(int id);

    }
}
