using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;
using Tasks.ViewModal;

namespace Tasks.Controllers
{
    public class AutoMapperController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ICountry _country;
        public AutoMapperController(IMapper mapper, ICountry country, DataContext dataContext)
        {
            _mapper = mapper;
            _country = country;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            CustomerVM vm = new CustomerVM();
            var con = _country.CGetall();
            vm.ListCountry = _mapper.Map<List<CountryVM>>(con);
            var sta = _dataContext.States.ToList();
            vm.ListState = _mapper.Map<List<StateVm>>(sta);
            var city = _dataContext.Cities.ToList();
            vm.ListCity = _mapper.Map<List<CityVm>>(city);
            return View(vm);
        }
        [HttpGet]
        public IActionResult CreateC()
        {
            CountryVM modelmodel = new CountryVM();
            return PartialView("_PartialCcreate", modelmodel);
        }
        [HttpPost]
        public IActionResult CreateC(Country country)
        {
            _country.CInsert(country);
            _country.CSave();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult DeleteC(int id)
        {
            var data = _country.CGet(id);
            _country.CDelete(data);
            _country.CSave();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult EditC(int id)
        {
            var data = _country.CGet(id);
            CountryVM con = new CountryVM();
            if (data != null)
            {
                con.CName = data.CName;
                con.Cid = data.Cid;
                return View("_PartialCcreate", con);
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult EditC(Country country)
        {
            _country.CUpdate(country);
            _country.CUpdate(country);
            _country.CSave();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreateS()
        {
            StateVm stateVm = new StateVm();
            return PartialView("_PartialScreate", stateVm);
        }
        [HttpPost]
        public IActionResult CreateS(State state)
        {
            _dataContext.States.Add(state);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteS(int id)
        {
            var data = _dataContext.States.Where(x => x.Sid == id).FirstOrDefault();
            _dataContext.States.Remove(data);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult EditS(int id)
        {
            var sta = _dataContext.States.Where(x => x.Sid == id).FirstOrDefault();
            StateVm stateVm = new StateVm();
            if (sta != null)
            {
                stateVm.Sid = sta.Sid;
                stateVm.SName = sta.SName;
                stateVm.Cid = sta.Cid;
            }
            return PartialView("_PartialScreate", stateVm);
        }
        [HttpPost]
        public IActionResult EditS(State state)
        {
            _dataContext.States.Update(state);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult CreateCity()
        {
            CityVm cityVm = new CityVm();
            return PartialView("_PartialCreateCity", cityVm);
        }
        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            _dataContext.Cities.Add(city);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteCity(int id)
        {
            var city = _dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault();
            _dataContext.Cities.Remove(city);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult EditCity(int id)
        {
            var city = _dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault();
            CityVm cityVm = new CityVm();
            if (city != null)
            {
                var conid = _dataContext.States.Where(x => x.Sid == city.S_Id).Select(x => x.Cid).FirstOrDefault();
                cityVm.City_Id = city.City_Id;
                cityVm.City_Name = city.City_Name;
                cityVm.S_Id = city.S_Id;
                cityVm.C_Id = conid;
                return PartialView("_PartialCreateCity", cityVm);
            }
            return View(city);
        }
        [HttpPost]
        public IActionResult EditCity(City city)
        {
            _dataContext.Cities.Update(city);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
