using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiddlewareDemo.Repositories;
using MiddlewareDemo.ViewModels;

namespace MiddlewareDemo.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var repository = new ImageRepository();
            var model = repository.GetImages().Select(i => new ImageModel
            {
                ImageId = i.ImageId,
                ImageName = i.ImageName
            }).ToList();
            return View(model);
        }
    }
}