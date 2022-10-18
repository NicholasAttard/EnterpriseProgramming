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
            itemsService.AddItem(data);
            return View();
        }
    }
}
