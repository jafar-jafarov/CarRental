using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.CCS;
using Business.Constants;
using Business.ValidatinRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
       

        public CarManager(ICarDal cardal,IBrandService brandService)
        {
            _carDal = cardal;
            _brandService = brandService;
       
        }
        //[Validate]
        //claim
       [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
           IResult result=BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId), CheckIfCarNameExsistsCorrect(car.CarName),CheckIfBrandLimitExceded());
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

            //ValidationTool.Validate(new CarValidator(), car);
            //loglama
            //cacheremove
            //performance
            //transac
            //business codes    
          
        }

        public IResult DeleteCar(Car car)
        {
           
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),"Tebrikler ehsen");
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
            var result = _carDal.GetAll(p => p.ColorId == car.ColorId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountError);
            }

            _carDal.Update(car);
            return new SuccessResult();
        }
        private IResult CheckIfCarCountOfColorCorrect(int colorId)
        {
            var result = _carDal.GetAll(p => p.ColorId == colorId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarNameExsistsCorrect(string carName)
        {
            var result = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result ==true)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
