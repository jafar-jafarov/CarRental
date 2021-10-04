using Business.Abstract;
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

        public void Add(Color color)
        {
            

            if (color.ColorName.Length < 2)
                _colordal.Add(color);
            else
                Console.WriteLine("Reng adi en azi 2 simvol olmalidir");
        }

        public void Delete(Color color)
        {
            _colordal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colordal.GetAll();
        }

        public List<Color> GetById(int id)
        {
            return _colordal.GetAll(x => x.ColorId == id);
        }

        public void Update(Color color)
        {
            _colordal.Update(color);
        }
    }
}
