﻿using Microsoft.AspNetCore.Mvc;
using WEB.Database.Models;
using WEB.Dal.Services;
using Webfeb.Models.Admin;
using Microsoft.AspNetCore.Authorization;

namespace Webfeb.Controllers.Admin
{
    [Route("/Admin/Categories")]
    [Authorize(Roles="Admin")]
    public class CategoryController : Controller
    {
        private CategoryService service;
        public CategoryController(CategoryService service)
        {
            this.service = service;
        }
        [Route("/Admin/Categories")]
        public IActionResult Index()
        {
            List<Category> categories = service.GetCategories();
            return View("~/Views/Admin/Categories/Index.cshtml",categories);
        }

        [HttpGet]
        [Route("/Admin/Categories/Create")]
        public IActionResult Create()
        {
           List<Category> categories = service.GetCategories();
            return View("~/Views/Admin/Categories/Create.cshtml",categories);
        }
        [HttpPost]
        [Route("/Admin/Categories/Create")]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            string filePath = "no-image.png";
            if (category.MainImage != null)
            {
                filePath = await UploadFile(category.MainImage);
            }

            Category categorynew = new Category
            {
                Name = category.Name,
               
                MainImage = filePath,
                ParentId = category.ParentId,
              
            };
            service.Store(categorynew);
            return Redirect("/Admin/Categories");
        }
        [HttpGet]
        [Route("/Admin/Categories/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            CategoryEditViewModel model = new CategoryEditViewModel();
            model.Categories=service.GetCategories();
            model.SelectedCategory = service.GetCategoryById(id);
            return View("~/Views/Admin/Categories/Edit.cshtml", model);
        }
        [HttpPost]
        [Route("/Admin/Categories/Edit/{id}")]
        public async Task<IActionResult> Edit(int id,CategoryViewModel category)
        {
            string filePath = "no-image.png";
            if (category.MainImage != null)
            {
                filePath = await UploadFile(category.MainImage);
            }

            Category categorynew = new Category
            {
                Name = category.Name,

                MainImage = filePath,
                ParentId = category.ParentId,

            };
            service.Update(id,categorynew);
            return Redirect("/Admin/Categories");
        }
        [HttpGet]
        [Route("/Admin/Categories/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Redirect("/Admin/Categories");
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            var uniqueFileName = Guid.NewGuid() + "-" + file.FileName;
            var filePath = Path.Combine("wwwroot", "img", "products", uniqueFileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }

    }
    

}
