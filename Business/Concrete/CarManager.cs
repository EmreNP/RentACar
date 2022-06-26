using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtoS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       // [SecuredOperation("product.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            IResult result= BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfSameCarNameExist(car.CarName));
            if (result==null)
            {
                
                ValidationTool.Validate(new CarValidator(), car);
                _carDal.Add(car);
                return new SuccessResult(Messages.Success);
           
            }
            return result; 

        }


        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));

        }

        public IResult Update(Car car)
        {
            _carDal.update(car);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<CarDetailDto>> carDetailDtoGetAll()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDtoAll());

        }

        public IDataResult<CarDetailDto> GetDetailCarId(int id)
        {
            return new SuccessDataResult<CarDetailDto>(Messages.Success, _carDal.GetDto(c => c.Id == id));
        }

        private IResult CheckIfCarCountOfBrandCorrect(int categoryId)
        {
            var resultCount = _carDal.GetAll(c => c.BrandId == categoryId).Count;
            if (resultCount >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfSameCarNameExist(string carName)
        {
            var result = _carDal.GetAll().Where(c => c.Equals(carName)).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckIfSameCarNameExist);
            }
            return new SuccessResult();
        }
    }
}
