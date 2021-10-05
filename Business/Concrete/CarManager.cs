using Business.Abstract;
using Business.Constants;
using Business.ValidatinRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }
        //[Validate]
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {

            //ValidationTool.Validate(new CarValidator(), car);
            //loglama
            //cacheremove
            //performance
            //transac
            //business codes    
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
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

        public IResult UpdateCar(Car car)
        {
           
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
