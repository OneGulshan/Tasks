using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Menu Curd
        /// </summary>        
        public IActionResult MenuIndex()
        {
            var result = _context.Menus.ToList();
            return View(result);
        }

        public IActionResult MenuCreate(int id)
        {
            if (id > 0)
            {
                var menu = _context.Menus.Where(x => x.MenuId == id).FirstOrDefault();
                ViewBag.BT = "Update";
                return PartialView("_MenuPartial", menu);
            }
            else
            {
                Menu menu = new();
                return PartialView("_MenuPartial", menu);
            }
        }

        [HttpPost]
        public IActionResult MenuCreate(Menu menu)
        {
            if (menu.MenuId > 0)
            {
                _context.Menus.Update(menu);
                _context.SaveChanges();
                return RedirectToAction("MenuIndex");
            }
            else
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return RedirectToAction("MenuIndex");
            }
        }

        public IActionResult MenuDelete(int id)
        {
            var menu = _context.Menus.Where(x => x.MenuId == id).FirstOrDefault();
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                _context.SaveChanges();
            }
            return RedirectToAction("MenuIndex");
        }

        /// <summary>
        /// Category Curd
        /// </summary>        
        public JsonResult GetManu_Name()
        {
            var menus = _context.Menus.ToList();
            return new JsonResult(menus);
        }

        public IActionResult CategoryIndex(Category category)
        {
            category.Menus = _context.Menus.ToList();
            category.Categories = _context.Categories.ToList();

            return View(category);
        }

        public IActionResult CategoryCreate(int id)
        {
            if (id > 0)
            {
                ViewBag.Main_Manu = new SelectList(_context.Menus, "MenuId", "MenuName");
                Category category = new();
                var data = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                if (data != null)
                {
                    category.CategoryId = data.CategoryId;
                    category.CategoryName = data.CategoryName;
                    category.MenuId = data.MenuId;
                    ViewBag.BT = "Update";
                    return PartialView("_CategoryPartial", category);
                }
                return View();
            }
            else
            {
                Category category = new();
                return PartialView("_CategoryPartial", category);
            }
        }

        [HttpPost]
        public IActionResult CategoryCreate(Category category)
        {
            if (category.CategoryId > 0)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("CategoryIndex");
            }
            else
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("CategoryIndex");
            }
        }

        public IActionResult CategoryDelete(int id)
        {
            var data = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (data != null)
            {
                _context.Categories.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToAction("CategoryIndex");
        }

        /// <summary>
        /// SubCategory Curd
        /// </summary>        
        public JsonResult Categoray(int id)
        {
            var ct = _context.Categories.Where(x => x.MenuId == id).ToList();
            return new JsonResult(ct);
        }

        public IActionResult SubCategoryIndex(SubCategory subcategory)
        {
            subcategory.Menus = _context.Menus.ToList();
            subcategory.Categories = _context.Categories.ToList();
            subcategory.SubCategories = _context.SubCategories.ToList();

            return View(subcategory);
        }

        public IActionResult SubCategoryCreate(int id)
        {
            if (id > 0)
            {
                SubCategory subcategory = new();
                var data = _context.SubCategories.Where(x => x.SubCategoryId == id).FirstOrDefault();
                if (data != null)
                {
                    var menuId = _context.Categories.Where(x => x.CategoryId == data.CategoryId).Select(x => x.MenuId).FirstOrDefault();
                    subcategory.SubCategoryId = data.SubCategoryId;
                    subcategory.SubCategoryName = data.SubCategoryName;
                    subcategory.CategoryId = data.CategoryId;
                    subcategory.MenuId = menuId;
                    ViewBag.BT = "Update";
                    return PartialView("_SubCategoryPartial", subcategory);
                }
                return View(data);
            }
            else
            {
                SubCategory category = new();
                return PartialView("_SubCategoryPartial", category);
            }
        }

        [HttpPost]
        public IActionResult SubCategoryCreate(SubCategory subcategory)
        {
            if (subcategory.SubCategoryId > 0)
            {
                _context.SubCategories.Update(subcategory);
                _context.SaveChanges();
                return RedirectToAction("SubCategoryIndex");
            }
            else
            {
                _context.SubCategories.Add(subcategory);
                _context.SaveChanges();
                return RedirectToAction("SubCategoryIndex");
            }
        }

        public IActionResult SubCategoryDelete(int id)
        {
            var data = _context.SubCategories.Where(x => x.SubCategoryId == id).FirstOrDefault();
            if (data != null)
            {
                _context.SubCategories.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToAction("SubCategoryIndex");
        }
    }
    }
