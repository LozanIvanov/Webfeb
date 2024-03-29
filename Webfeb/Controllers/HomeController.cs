﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webfeb.Models;
using WEB.Database;
using Webfeb.Models.Admin;

namespace Webfeb.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _context=db;

            _logger = logger;
        }


        public IActionResult Index()
        {
            var model = new CategoryEditViewModel();
          

            model.CategoriesView = _context.Categories.Select(c=>new CategoryViewModel() 
                                      
                                      {
                                     Name=c.Name,
                                      ProductCount=c.Products.Count,      
                                    
                                     MainImages=c.MainImage
                                    
                                      }).ToList();
            model.TrandyProduct = _context.Products.Select(c => new ProductCreateModel()
            {
                Id=c.Id,
                Name = c.Name,
                Price=c.Price,
                MainImages=c.MainImage

            }).ToList();
            model.TrandyProduct = model.TrandyProduct.OrderByDescending(x => x.Id).Take(8).ToList();

            Random random = new Random();
  
           var products = _context.Products.Select(c => new ProductCreateModel()
           {
               Id = c.Id,
               Name = c.Name,
               Price = c.Price,
               MainImages = c.MainImage

             }).ToList();
            List<ProductCreateModel> p = new List<ProductCreateModel>();
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = random.Next(products.Count);
                var product = products[randomIndex];
                p.Add(product);
                products.RemoveAt(randomIndex);
            }
            model.RendomProduct= p;



            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}