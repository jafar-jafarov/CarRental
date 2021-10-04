using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult("Marka adi en azi 2 simvol olmalidir");
            }
                _brandDal.Add(brand);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(x => x.BrandId == id));
        }

      
    }
}
