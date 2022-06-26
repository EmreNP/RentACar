using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        string _defaultImage = String.Concat(PathConstants.ImagesPath, "Default.png");
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(int carId, IFormFile file)
        {
            BusinessRules.Run(CheckIfCarImageOfCarIdCount(carId));
            var carImage = new CarImage
            {
                CarId = carId,
                ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath)
            };

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }
        private IResult CheckIfCarImageOfCarIdCount(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId).Count;
            if (result >= 5) return new ErrorResult();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var carImage = _carImageDal.Get(c => c.Id == id);
            if (carImage == null) throw new Exception();

            _fileHelper.Delete(PathConstants.ImagesPath + carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count == 0) result.Add(new CarImage { ImagePath = _defaultImage });
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(int id, IFormFile file)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            if (result == null) throw new Exception();
            result.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath, result.ImagePath);
            _carImageDal.update(result);
            return new SuccessResult();



        }
    }
}
