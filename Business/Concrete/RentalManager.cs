using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var rentals = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == DateTime.MinValue);
            if(rentals == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Success);
            }
            return new ErrorResult(Messages.Error);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(Messages.Success, _rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(Messages.Success, _rentalDal.Get(c => c.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.update(rental);
            return new SuccessResult(Messages.Success);

        }
    }
}
