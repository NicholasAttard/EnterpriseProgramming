using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //are going to handel the incoming requests and outgoing responses
    public class ItemsController : Controller
    {
        public ItemsServices itemsService;

        public ItemsController(ItemsServices _itemsService) 
        {
            itemsService = _itemsService;
        }
        //A mthod to open the page
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        //A method to handele the submission of the form
        [HttpPost]
        public IActionResult Create(CreateItemViewModel data)
        {
            try
            {
                itemsService.AddItem(data);
                //dynamic object - it builds the declared properties on-the-fly i.e the moment you declare the property
                //"Message" it builds in realtime in memory
                ViewBag.Message = "Item Successfully inserted in database";
            }
            catch (Exception ex) 
            {
                ViewBag.Error = "Item wasn't inserted Successfully. Please check your inputs!";
            }
            return View();
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
