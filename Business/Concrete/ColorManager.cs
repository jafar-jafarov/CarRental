using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public IResult Add(Color color)
        {
            

            if (color.ColorName.Length < 2)
                _colordal.Add(color);
            else
                Console.WriteLine("Reng adi en azi 2 simvol olmalidir");
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            _colordal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll());
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            return new SuccessDataResult<List<Color>>(_colordal.GetAll(x => x.ColorId == id));
        }

        public IResult Update(Color color)
        {
            _colordal.Update(color);
            return new SuccessResult();
        }
    }
}
