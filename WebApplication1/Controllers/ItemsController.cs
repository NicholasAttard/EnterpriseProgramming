using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //are going to handel the incoming requests and outgoing responses
    public class ItemsController : Controller
    {
        public ItemsServices itemsService;
        private IWebHostEnvironment host;
        private CategoriesServices categoriesServices;
        public ItemsController(ItemsServices _itemsService, IWebHostEnvironment _host,CategoriesServices _categoriesServices) 
        {
            itemsService = _itemsService;
            host = _host;
            categoriesServices = _categoriesServices;
        }
        //A mthod to open the page
        [HttpGet]
        public IActionResult Create() 
        {
            var categories = categoriesServices.GetCategories();
            CreateItemViewModel myModel = new CreateItemViewModel();
            myModel.Categories = categories.ToList();
            return View(myModel);
        }
        //A method to handele the submission of the form
        [HttpPost]
        public IActionResult Create(CreateItemViewModel data, IFormFile file)
        {
            try
            {
                if (file != null) 
                {
                    //1.Change fileName
                    string uniqueFileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);

                    //2. I need the absolute path of the folder were the image is going
                    string absolutePath = host.WebRootPath;

                    //3.Saving the file
                    using (System.IO.FileStream fsOut = new System.IO.FileStream(absolutePath + "\\Images\\" + uniqueFileName, System.IO.FileMode.CreateNew)) 
                    {
                        file.CopyTo(fsOut);
                    }

                    //4.Save the path to the image to the database
                    data.PhotoPath = "/Images/" + uniqueFileName;
                }

                itemsService.AddItem(data);
                //dynamic object - it builds the declared properties on-the-fly i.e the moment you declare the property
                //"Message" it builds in realtime in memory
                ViewBag.Message = "Item Successfully inserted in database";
            }
            catch (Exception ex) 
            {
                ViewBag.Error = "Item wasn't inserted Successfully. Please check your inputs!";
            }

            var categories = categoriesServices.GetCategories();
            data.Categories = categories.ToList();
            return View(data);
        }

        public IActionResult List() 
        {
            var list = itemsService.GetItems();
            return View(list);
        }
        public IActionResult Details(int id)
        {
            var myItem = itemsService.GetItem(id);
            return View(myItem);
        }
    }
}
