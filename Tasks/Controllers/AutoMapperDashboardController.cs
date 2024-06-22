using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;
using Tasks.ViewModal;

namespace Tasks.Controllers
{
    public class AutoMapperDashboardController(ICustomer repository, DataContext dataContext, IMapper mapper, ICountry country) : Controller
    {
        private readonly ICustomer _repository = repository;
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;
        private readonly ICountry _country = country;

        public IActionResult Index()
        {
            CustomerVM VModel = new();
            var data = _repository.Getall();
            VModel.ListCustomer = _mapper.Map<List<CustomerVM>>(data);
            var con = _dataContext.Countries.AsNoTracking().ToList();
            VModel.ListCountry = _mapper.Map<List<CountryVm>>(con);
            var sta = _dataContext.States.AsNoTracking().ToList();
            VModel.ListState = _mapper.Map<List<StateVm>>(sta);
            var city = _dataContext.Cities.AsNoTracking().ToList();
            VModel.ListCity = _mapper.Map<List<CityVm>>(city);
            return View(VModel);
        }

        public IActionResult Create() => PartialView("_PartialCreate", new CustomerVM());

        [HttpPost]
        public IActionResult Create(Customer Customer, IFormFile file)
        {
            string pth = Path.Combine("wwwroot/Images");
            string FN = Guid.NewGuid().ToString() + "-" + file.FileName;
            string filepath = Path.Combine(pth, FN);
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            Customer.Std_Image = FN;
            _repository.Insert(Customer);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _repository.Get(id);
            CustomerVM Std = new();

            if (data != null)
            {
                Std.S_Id = data.S_Id;
                Std.City_Id = data.City_Id;
                Std.C_Id = data.C_Id;
                Std.Std_Id = data.Std_Id;
                Std.Std_Name = data.Std_Name;
                Std.Std_School = data.Std_School;
                Std.Std_Class = data.Std_Class;
                Std.Std_Address = data.Std_Address;
                Std.Std_Image = data.Std_Image;
                Std.Std_Mobile = data.Std_Mobile;
                TempData["img"] = data.Std_Image;
                return PartialView("_PartialCreate", Std);
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Customer Customer, IFormFile file)
        {
            var data = _repository.Get(Customer.Std_Id);
            string filename = "";
            string pth = Path.Combine("wwwroot/Images");

            if (file == null)
            {
                filename = data.Std_Image;
            }
            else
            {
                filename = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filepath = Path.Combine(pth, filename);

                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                string delete = TempData["img"].ToString();
                string old = Path.Combine("wwwroot/Images", delete);
                if (System.IO.File.Exists(old))
                {
                    System.IO.File.Delete(old);
                }
                Customer.Std_Image = filename;
            }
            data.Std_Address = Customer.Std_Address;
            data.Std_School = Customer.Std_School;
            data.Std_Class = Customer.Std_Class;
            data.Std_Name = Customer.Std_Name;
            data.Std_Mobile = Customer.Std_Mobile;
            data.Std_Image = filename;
            data.C_Id = Customer.C_Id;
            data.Std_Id = Customer.Std_Id;
            data.City_Id = Customer.City_Id;
            _repository.Update(data);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _repository.Get(id);
            string old = Path.Combine("wwwroot/Images", data.Std_Image);
            if (System.IO.File.Exists(old))
            {
                System.IO.File.Delete(old);
            }
            _repository.Delete(data);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public JsonResult Country() => new(_dataContext.Countries.AsNoTracking().ToList());

        public JsonResult State(int id) => new(_dataContext.States.Where(x => x.Cid == id).AsNoTracking().ToList());

        public JsonResult City(int id) => new(_dataContext.Cities.Where(x => x.S_Id == id).AsNoTracking().ToList());

        public IActionResult CreateC() => PartialView("_PartialCcreate", new CountryVm());

        [HttpPost]
        public IActionResult CreateC(Country country)
        {
            _country.CInsert(country);
            _country.CSave();
            return RedirectToAction("Index", "AutoMapperDashboard");
        }

        public IActionResult DeleteC(int id)
        {
            _country.CDelete(_country.CGet(id));
            _country.CSave();
            return RedirectToAction("Index", "AutoMapperDashboard");
        }

        public IActionResult EditC(int id)
        {
            var data = _country.CGet(id);
            if (data != null)
            {
                return PartialView("_PartialCcreate", new CountryVm()
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
            _country.CSave();
            return RedirectToAction("Index", "AutoMapperDashboard");
        }

        public IActionResult CreateS() => PartialView("_PartialScreate", new StateVm());

        [HttpPost]
        public IActionResult CreateS(State state)
        {
            _dataContext.States.Add(state);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapperDashboard");
        }

        public IActionResult DeleteS(int id)
        {
            _dataContext.States.Remove(_dataContext.States.Where(x => x.Sid == id).FirstOrDefault());
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapperDashboard");
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
            return RedirectToAction("Index", "AutoMapperDashboard");
        }

        public IActionResult CreateCity() => PartialView("_PartialCreateCity", new CityVm());

        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            _dataContext.Cities.Add(city);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapperDashboard");
        }

        public IActionResult DeleteCity(int id)
        {
            var city = _dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault();
            _dataContext.Cities.Remove(city);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "AutoMapperDashboard");
        }

        public IActionResult EditCity(int id)
        {
            var city = _dataContext.Cities.Where(x => x.City_Id == id).FirstOrDefault();
            CityVm cityVm = new();
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
            return RedirectToAction("Index", "AutoMapperDashboard");
        }
    }
}
