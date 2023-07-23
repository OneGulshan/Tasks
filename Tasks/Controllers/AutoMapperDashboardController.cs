using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tasks.Data;
using Tasks.IRepository;
using Tasks.Models;
using Tasks.ViewModal;

namespace Tasks.Controllers
{
    public class AutoMapperDashboardController : Controller
    {
        private readonly ICustomer _repository;
        //private readonly ICountry _country;
        //private readonly IState _state;
        //private readonly ICity _city;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public AutoMapperDashboardController(ICustomer repository, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _dataContext = dataContext;
            //_country = country;
            //_state = state;
            //_city = city;
        }

        public IActionResult Index()
        {
            CustomerVM VModel = new CustomerVM();
            var data = _repository.Getall();
            VModel.ListCustomer = _mapper.Map<List<CustomerVM>>(data);
            var con = _dataContext.Countries.ToList();
            VModel.ListCountry = _mapper.Map<List<CountryVM>>(con);
            var sta = _dataContext.States.ToList();
            VModel.ListState = _mapper.Map<List<StateVm>>(sta);
            var city = _dataContext.Cities.ToList();
            VModel.ListCity = _mapper.Map<List<CityVm>>(city);
            return View(VModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CustomerVM CustomerVM = new CustomerVM();
            return PartialView("_PartialCreate", CustomerVM);
        }
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _repository.Get(id);
            CustomerVM Std = new CustomerVM();

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
        public JsonResult Country()
        {
            var con = _dataContext.Countries.ToList();
            return new JsonResult(con);
        }

        public JsonResult State(int id)
        {
            var con = _dataContext.States.Where(x => x.Cid == id).ToList();
            var data = _repository.Get(id);
            return new JsonResult(con);
        }

        public JsonResult City(int id)
        {
            var city = _dataContext.Cities.Where(x => x.S_Id == id).ToList();
            return new JsonResult(city);
        }
    }
}
