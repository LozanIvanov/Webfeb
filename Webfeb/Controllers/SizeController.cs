using Microsoft.AspNetCore.Mvc;
using WEB.Dal.Services;
using WEB.Database.Models;
using Webfeb.Models.Shop;

namespace Webfeb.Controllers
{
    [Route("/Size")]
    public class SizeController : Controller
    {
        private readonly SizeService sizeService;
       
        public SizeController(SizeService sizeService)
        {
            this.sizeService = sizeService;
         
        }
        [HttpGet]
        [Route("/Size")]
        public IActionResult Index()
        {
            var model=sizeService.GetSizes();
            return View("~/Views/Size/Index.cshtml",model);
        }
        [HttpGet]
        [Route("/Size/Create")]
        public IActionResult Create()
        {

            var m = new EditViewSize();
            return View("~/Views/Size/Create.cshtml",m);
        }
        [HttpPost]
        [Route("/Size/Create")]
        public IActionResult Create(Size size)
        {
            sizeService.Create(size);
            return Redirect("/Size");
        }
        [HttpGet]
        [Route("/Size/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var p = sizeService.GetSizeById(id);
            var m = new EditViewSize()
            {
                Name = p.Name
            };
           

            return View("~/Views/Size/Create.cshtml",m);
        }
        [HttpPost]
        [Route("/Size/Edit/{id}")]
        public IActionResult Edit(int id,Size size)
        {
            sizeService.Update(id,size);

            return Redirect("/Size");
        }
        [HttpGet]
        [Route("/Size/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            sizeService.Delete(id);

            return Redirect("/Size");
        }

    }
}
