using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;
using Tasks.ViewModal;

namespace Tasks.Controllers
{
    public class AutoMapperController(IMapper mapper, ICountry country, DataContext dataContext) : Controller
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;
        private readonly ICountry _country = country;

        public IActionResult Index()
        {
            CustomerVM vm = new();
            var con = _country.CGetall();
            vm.ListCountry = _mapper.Map<List<CountryVm>>(con);
            var sta = _dataContext.States.AsNoTracking().ToList();
            vm.ListState = _mapper.Map<List<StateVm>>(sta);
            var city = _dataContext.Cities.AsNoTracking().ToList();
            vm.ListCity = _mapper.Map<List<CityVm>>(city);
            return View(vm);
        }

        public IActionResult CreateC() => PartialView("_PartialCcreate", new CountryVm());

        [HttpPost]
        public IActionResult CreateC(Country country)
        {
            _country.CInsert(country);
            _country.CSave();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult DeleteC(int id)
        {
            _country.CDelete(_country.CGet(id));
            _country.CSave();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult EditC(int id)
        {
            var data = _country.CGet(id);
            if (data != null)
            {
                return View("_PartialCcreate", new CountryVm()
                {
                    CName = data.CName,
                    Cid = data.Cid
                });
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult EditC(Country country)
        {
            _country.CUpdate(country);
            _country.CUpdate(country);
            _country.CSave();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult CreateS()
        {
            StateVm stateVm = new();
            return PartialView("_PartialScreate", stateVm);
        }

        [HttpPost]
        public IActionResult CreateS(State state)
        {
            _dataContext.States.Add(state);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult DeleteS(int id)
        {
            var data = _dataContext.States.Where(x => x.Sid == id).FirstOrDefault();
            _dataContext.States.Remove(data);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult EditS(int id)
        {
            var sta = _dataContext.States.Where(x => x.Sid == id).FirstOrDefault();
            if (sta != null)
            {
                StateVm stateVm = new()
                {
                    Sid = sta.Sid,
                    SName = sta.SName,
                    Cid = sta.Cid
                };
                return PartialView("_PartialScreate", stateVm);
            }
            return PartialView("_PartialScreate");
        }

        [HttpPost]
        public IActionResult EditS(State state)
        {
            _dataContext.States.Update(state);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult CreateCity() => PartialView("_PartialCreateCity", new CityVm());

        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            _dataContext.Cities.Add(city);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult DeleteCity(int id)
        {
            _dataContext.Cities.Remove(_dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault());
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapper");
        }

        public IActionResult EditCity(int id)
        {
            var city = _dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault();
            if (city != null)
            {
                var conid = _dataContext.States.Where(x => x.Sid == city.S_Id).Select(x => x.Cid).FirstOrDefault();
                return PartialView("_PartialCreateCity", new CityVm()
                {
                    City_Id = city.City_Id,
                    City_Name = city.City_Name,
                    S_Id = city.S_Id,
                    C_Id = conid
                });
            }
            return View(city);
        }

        [HttpPost]
        public IActionResult EditCity(City city)
        {
            _dataContext.Cities.Update(city);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapper");
        }
    }
}
