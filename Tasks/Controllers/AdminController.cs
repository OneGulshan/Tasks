using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class AdminController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        /// <summary>
        /// Menu Curd
        /// </summary>        
        public IActionResult MenuIndex() => View(_context.Menus.AsNoTracking().ToList());

        public IActionResult MenuCreate(int id)
        {
            if (id > 0)
            {
                ViewBag.BT = "Update";
                return PartialView("_MenuPartial", _context.Menus.Where(x => x.MenuId == id).FirstOrDefault());
            }
            else
            {
                return PartialView("_MenuPartial", new Menu());
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
        public JsonResult GetMenu() => new(_context.Menus.AsNoTracking().ToList());

        public IActionResult CategoryIndex(Category category)
        {
            category.Menus = [.. _context.Menus.AsNoTracking()];
            category.Categories = [.. _context.Categories.AsNoTracking()];

            return View(category);
        }

        public IActionResult CategoryCreate(int id)
        {
            if (id > 0)
            {
                ViewBag.Main_Manu = new SelectList(_context.Menus, "MenuId", "MenuName");
                var data = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                if (data != null)
                {
                    Category category = new()
                    {
                        CategoryId = data.CategoryId,
                        CategoryName = data.CategoryName,
                        MenuId = data.MenuId
                    };
                    category.MenuName = _context.Menus.Where(x => x.MenuId == category.MenuId).Select(x => x.MenuName).ToString();
                    ViewBag.BT = "Update";
                    return PartialView("_CategoryPartial", category);
                }
                return View();
            }
            else
            {
                ViewBag.Main_Manu = new SelectList(_context.Menus, "MenuId", "MenuName");
                foreach (var item in ViewBag.Main_Manu)
                {
                    Category category = new()
                    {
                        MenuId = Convert.ToInt32(item.Value),
                        MenuName = item.Text
                    };

                    return PartialView("_CategoryPartial", category);
                }
                
                return PartialView("_CategoryPartial", new Category());
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
        public JsonResult GetCategory(int id) => new(_context.Categories.Where(x => x.MenuId == id).AsNoTracking().ToList());

        public IActionResult SubCategoryIndex(SubCategory subcategory)
        {
            subcategory.Menus = [.. _context.Menus.AsNoTracking()];
            subcategory.Categories = [.. _context.Categories.AsNoTracking()];
            subcategory.SubCategories = [.. _context.SubCategories.AsNoTracking()];

            return View(subcategory);
        }

        public IActionResult SubCategoryCreate(int id)
        {
            if (id > 0)
            {
                var data = _context.SubCategories.Where(x => x.SubCategoryId == id).FirstOrDefault();
                if (data != null)
                {
                    var menuId = _context.Categories.Where(x => x.CategoryId == data.CategoryId).Select(x => x.MenuId).FirstOrDefault();
                    ViewBag.BT = "Update";
                    return PartialView("_SubCategoryPartial", new SubCategory()
                    {
                        SubCategoryId = data.SubCategoryId,
                        SubCategoryName = data.SubCategoryName,
                        CategoryId = data.CategoryId,
                        MenuId = menuId
                    });
                }
                return View(data);
            }
            else
            {
                return PartialView("_SubCategoryPartial", new SubCategory());
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
