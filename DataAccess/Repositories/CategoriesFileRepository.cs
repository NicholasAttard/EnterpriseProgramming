using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    //This repository class will read Categories from a file and not from a database
    public class CategoriesFileRepository : ICategoriesRepository
    {
        private FileInfo fi;
        public CategoriesFileRepository(FileInfo _fi) 
        {
            fi = _fi;
        }
        public IQueryable<Category> GetCategories()
        {
            //StreamReader is a built in class which makes reading text from file easier
            List<Category> categories = new List<Category>();
            string line = "";
            using (StreamReader sr = fi.OpenText()) 
            {
                //sr.peek() returns next index of whats to be read next
                //meaning that it if returns -1 there is nothing left to read;
                while (sr.Peek() != -1) 
                {
                    line = sr.ReadLine();
                    categories.Add(new Category()
                        {
                            Id = Convert.ToInt32(line.Split(';')[0]),
                            Title = line.Split(';')[1].ToString()
                        });
                }
            }
            return categories.AsQueryable();
        }
    }
}
