using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        // [LogAspect]-----AOP aspect oriented proggramming
        //[Validate] mehsullaria mecburiyyet qoymaq yeni simvol sayi adi falan
        //[cache] kesle
        //[removecache] mehsul yuklenende  kesi temizle
        // [Transaction] banklarda istifade olunur meselen pul kocurmek lazim olanda nese xeta bas verdi guncellemek ucun lazim olur
        //[performance] yeni sistemde proses zeif gederse 5 saniyeden artiq mene xeberdarliq et 
        //loosely couped

        ICarService _carService;  //naming convention
        //dependency injection
        //ioc container -inversion of control          new carmanager   new efcardal startup da  yaziriq bir daha istifade etmirik
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            //ICarService carService = new CarManager(new EfCarDal());
            var result = _carService.GetAll();  
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public ActionResult Add(Car car)
        {
            var result = _carService.AddCar(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public ActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
