using DataAccess.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ItemsRepository
    {
        //Dependency Injection: it centrelizes the creation of instances to manage effeciently these inside memory

        private ShoppingCartContext context { get; set; }

        //Constructor Injection - we are shifting creation of instances such as ShoppingCartContext to a more centrelised place i.e. StartUp.cs
        //Declaring by using constructor injection that the ItemRepository when consumed, it must be given an instance of ShoppingCartContext
        public ItemsRepository(ShoppingCartContext _context) 
        {
            context = _context;
        }

        //In the data access we code methods that add/read data to/from the db
        public IQueryable<Item> GetItems()
        { 
            return context.Items; 
        }

        public void AddItem(Item i) 
        {
            context.Items.Add(i);
            context.SaveChanges();
        }
        public void DeleteItem(Item i)
        {
            context.Items.Remove(i);
            context.SaveChanges();
        }

        public Item GetItem(int id) 
        {
            return context.Items.SingleOrDefault(x => x.Id == id);
        }
    }
}
