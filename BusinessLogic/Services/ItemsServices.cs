using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.ViewModels;
using DataAccess.Repositories;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ItemsServices
    {
        //Contructor Injection
        private ItemsRepository ir;
        public ItemsServices(ItemsRepository _itemRepository)
        {
            ir = _itemRepository;
        }
        public void AddItem(CreateItemViewModel item)
        {
            if (ir.GetItems().Any(i => i.Name == item.Name))
                throw new Exception("Item with the same name already exits");
            else
            {
                ir.AddItem(new Domain.Models.Item()
                {
                    CategoryId = item.CategoryId,
                    Description = item.Description,
                    Name = item.Name,
                    PhotoPath = item.PhotoPath,
                    Price = item.Price

                });
            }
        }

        public void DeleteItem(int id)
        {
        }

        //It is not recommended to use the domain.Models as a return type
        //In other words do not use the classes that model the database to transfer data into the presentation layer
        public IQueryable<ItemViewModel> GetItems()
        {
            var list = from i in ir.GetItems()
                       select new ItemViewModel()
                       {
                           Id = i.Id,
                           Category = i.Category.Title,
                           Description = i.Description,
                           Name = i.Name,
                           PhotoPath = i.PhotoPath,
                           Price = i.Price
                       };
            return list;
            }
        }
    }
